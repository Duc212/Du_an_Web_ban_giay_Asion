using BUS.Services.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    /// <summary>
    /// Service mô phỏng việc chuyển đổi trạng thái GHN tự động
    /// Fake GHN status progression, sau đó update Order status theo GHN
    /// Logic: Admin gửi GHN → GHN status tự động chuyển → Order status theo GHN status
    /// </summary>
    public class OrderStatusSimulationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<OrderStatusSimulationService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(2); // Chạy mỗi 2 phút
        private readonly Random _random = new Random();

        public OrderStatusSimulationService(
            IServiceProvider serviceProvider,
            ILogger<OrderStatusSimulationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("📦 GHN Status Simulation Service started at {Time}", DateTime.Now);

            // Đợi 30 giây sau khi app start
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("🔄 GHN Status Simulation job triggered at {Time}", DateTime.Now);

                    await SimulateGhnStatusProgressAsync(stoppingToken);

                    _logger.LogInformation("✅ GHN Status Simulation completed. Next run in {Interval} minutes",
                        _interval.TotalMinutes);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error in GHN Status Simulation Service");
                }

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("GHN Status Simulation Service stopped");
        }

        private async Task SimulateGhnStatusProgressAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var revenueService = scope.ServiceProvider.GetRequiredService<IRevenueService>();

            try
            {
                // Lấy các đơn hàng có GhnOrderCode và GhnStatus chưa kết thúc
                var ordersWithGhn = await context.Orders
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Variant)
                    .Include(o => o.OrderPayments)
                        .ThenInclude(op => op.Payment)
                    .Where(o =>
                        !string.IsNullOrEmpty(o.GhnOrderCode) &&
                        o.GhnStatus != "delivered" &&
                        o.GhnStatus != "cancel" &&
                        o.GhnStatus != "return" &&
                        o.Status != (int)OrderStatusEnums.Delivered &&
                        o.Status != (int)OrderStatusEnums.Cancelled &&
                        o.Status != (int)OrderStatusEnums.Returned)
                    .OrderBy(o => o.GhnCreatedAt ?? o.OrderDate)
                    .ToListAsync(cancellationToken);

                if (!ordersWithGhn.Any())
                {
                    _logger.LogInformation("No GHN orders to simulate");
                    return;
                }

                _logger.LogInformation("Found {Count} GHN orders to simulate", ordersWithGhn.Count);

                foreach (var order in ordersWithGhn)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    await ProcessGhnStatusTransition(order, context, revenueService, cancellationToken);
                }

                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SimulateGhnStatusProgressAsync");
                throw;
            }
        }

        private async Task ProcessGhnStatusTransition(Order order, AppDbContext context, IRevenueService revenueService, CancellationToken cancellationToken)
        {
            try
            {
                var currentGhnStatus = order.GhnStatus ?? "ready_to_pick";
                var oldGhnStatus = currentGhnStatus;

                // Tính thời gian đơn hàng đã được gửi GHN
                var ghnAge = DateTime.Now - (order.GhnCreatedAt ?? order.OrderDate);

                // Quyết định GHN status tiếp theo
                var nextGhnStatus = DetermineNextGhnStatus(currentGhnStatus, ghnAge);

                if (nextGhnStatus != currentGhnStatus)
                {
                    order.GhnStatus = nextGhnStatus;
                    order.GhnUpdatedAt = DateTime.Now;

                    _logger.LogInformation(
                        "📦 Order #{OrderId} ({OrderCode}): GHN Status {OldStatus} → {NewStatus} (Age: {Hours}h {Minutes}m)",
                        order.OrderID, order.OrderCode, oldGhnStatus, nextGhnStatus,
                        (int)ghnAge.TotalHours, ghnAge.Minutes);

                    // Update Order Status dựa trên GHN Status (giống logic GHN thật)
                    UpdateOrderStatusByGhnStatus(order, nextGhnStatus);

                    // Xử lý logic nghiệp vụ
                    await HandleGhnStatusChangeBusinessLogic(order, nextGhnStatus, context, revenueService);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing GHN status for order {OrderId}", order.OrderID);
            }
        }

        /// <summary>
        /// Xác định GHN status tiếp theo (mô phỏng flow GHN thật)
        /// Flow: ready_to_pick → picking → picked → storing → transporting → delivering → delivered/return
        /// </summary>
        private string DetermineNextGhnStatus(string currentGhnStatus, TimeSpan ghnAge)
        {
            var successRate = _random.Next(100);
            var status = currentGhnStatus?.ToLower() ?? "ready_to_pick";

            switch (status)
            {
                case "ready_to_pick":
                    if (ghnAge.TotalMinutes >= 3)
                    {
                        if (successRate < 5) return "cancel"; // 5% hủy ngay
                        return "picking";
                    }
                    break;

                case "picking":
                    if (ghnAge.TotalMinutes >= 5)
                    {
                        if (successRate < 5) return "cancel";
                        return "picked";
                    }
                    break;

                case "picked":
                    if (ghnAge.TotalMinutes >= 8)
                    {
                        return "storing";
                    }
                    break;

                case "storing":
                    if (ghnAge.TotalMinutes >= 10)
                    {
                        return "transporting";
                    }
                    break;

                case "transporting":
                    if (ghnAge.TotalMinutes >= 15)
                    {
                        return "delivering";
                    }
                    break;

                case "delivering":
                    // Sau 20 phút → delivered (85%) hoặc return (10%) hoặc delay (5%)
                    if (ghnAge.TotalMinutes >= 20)
                    {
                        if (successRate < 85) return "delivered";
                        else if (successRate < 95) return "return";
                        // 5% còn lại giữ nguyên delivering (delay)
                    }
                    // Sau 40 phút → Bắt buộc kết thúc
                    else if (ghnAge.TotalMinutes >= 40)
                    {
                        return successRate < 90 ? "delivered" : "return";
                    }
                    break;
            }

            return status;
        }

        /// <summary>
        /// Update Order Status dựa trên GHN Status
        /// CHỈ UPDATE KHI: Delivered (giao thành công) hoặc Return (hoàn trả)
        /// </summary>
        private void UpdateOrderStatusByGhnStatus(Order order, string ghnStatus)
        {
            if (string.IsNullOrEmpty(ghnStatus))
                return;

            var oldOrderStatus = (OrderStatusEnums)order.Status;

            switch (ghnStatus.ToLower())
            {
                case "delivered":
                    // Giao hàng thành công
                    order.Status = (int)OrderStatusEnums.Delivered;
                    break;

                case "return":
                case "returned":
                case "exception":
                case "damage":
                case "lost":
                    // Hoàn trả
                    order.Status = (int)OrderStatusEnums.Returned;
                    break;

                case "cancel":
                    // Hủy đơn
                    order.Status = (int)OrderStatusEnums.Cancelled;
                    break;

                // Các trạng thái khác (ready_to_pick, picking, picked, storing, transporting, delivering)
                // → KHÔNG ĐỔI Order Status, chỉ cập nhật GHN Status
                default:
                    // Không làm gì với Order Status
                    break;
            }

            var newOrderStatus = (OrderStatusEnums)order.Status;
            if (oldOrderStatus != newOrderStatus)
            {
                _logger.LogInformation(
                    "  └─ Order Status: {OldStatus} → {NewStatus}",
                    GetOrderStatusText(oldOrderStatus), GetOrderStatusText(newOrderStatus));
            }
        }

        /// <summary>
        /// Xử lý logic nghiệp vụ khi GHN status thay đổi
        /// </summary>
        private async Task HandleGhnStatusChangeBusinessLogic(Order order, string newGhnStatus, AppDbContext context, IRevenueService revenueService)
        {
            var status = newGhnStatus?.ToLower() ?? "";

            switch (status)
            {
                case "picking":
                    _logger.LogInformation("  └─ 🚗 GHN đang đến lấy hàng");
                    break;

                case "picked":
                    _logger.LogInformation("  └─ ✅ GHN đã lấy hàng thành công");
                    break;

                case "storing":
                    _logger.LogInformation("  └─ 📦 Hàng đang tại kho GHN");
                    break;

                case "transporting":
                    _logger.LogInformation("  └─ 🚚 Hàng đang vận chuyển");
                    break;

                case "delivering":
                    _logger.LogInformation("  └─ 🏃 Shipper đang giao hàng");
                    break;

                case "delivered":
                    await HandleGhnDeliverySuccess(order, context, revenueService);
                    break;

                case "return":
                case "returned":
                case "exception":
                case "damage":
                case "lost":
                    await HandleGhnDeliveryFailed(order, context);
                    break;

                case "cancel":
                    await HandleGhnOrderCancelled(order, context);
                    break;
            }
        }

        /// <summary>
        /// Xử lý giao hàng thành công (GHN delivered)
        /// QUAN TRỌNG: Thu COD + Ghi nhận doanh thu
        /// </summary>
        private async Task HandleGhnDeliverySuccess(Order order, AppDbContext context, IRevenueService revenueService)
        {
            try
            {
                _logger.LogInformation("  └─ ✅ GHN giao hàng thành công");

                // 1. Cập nhật trạng thái thanh toán (Thu COD)
                var orderPayment = order.OrderPayments?.FirstOrDefault();
                if (orderPayment != null)
                {
                    if (orderPayment.Status == (int)PaymentStatus.Unpaid)
                    {
                        orderPayment.Status = (int)PaymentStatus.Paid;
                        order.CodCollected = true;

                        _logger.LogInformation("      💰 Đã thu COD: {Amount:N0}₫", order.TotalAmount);
                    }
                }

                // 2. Ghi nhận doanh thu vào bảng Revenue
                var revenueRecorded = await revenueService.RecordRevenueAsync(order.OrderID, order.TotalAmount);
                
                if (revenueRecorded)
                {
                    _logger.LogInformation("      💵 Đã ghi nhận doanh thu: {Amount:N0}₫", order.TotalAmount);
                }
                else
                {
                    _logger.LogWarning("      ⚠️ Doanh thu đã được ghi nhận trước đó");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error handling GHN delivery success for Order {OrderId}", order.OrderID);
            }
        }

        /// <summary>
        /// Xử lý giao hàng thất bại / hoàn trả (GHN return)
        /// QUAN TRỌNG: Hoàn kho + Xóa doanh thu (nếu có)
        /// </summary>
        private async Task HandleGhnDeliveryFailed(Order order, AppDbContext context)
        {
            try
            {
                _logger.LogWarning("  └─ ↩️ GHN hoàn trả đơn hàng");

                // 1. Hoàn trả số lượng sản phẩm vào kho
                if (order.OrderDetails != null && order.OrderDetails.Any())
                {
                    int totalRestored = 0;
                    foreach (var detail in order.OrderDetails)
                    {
                        if (detail.Variant != null)
                        {
                            var oldQty = detail.Variant.StockQuantity;
                            detail.Variant.StockQuantity += detail.Quantity;
                            totalRestored += detail.Quantity;

                            _logger.LogInformation(
                                "      🔄 VariantID {VariantId}: +{Qty} (Stock: {OldQty} → {NewQty})",
                                detail.Variant.VariantID, detail.Quantity, oldQty, detail.Variant.StockQuantity);
                        }
                    }
                    _logger.LogInformation("      Tổng hoàn kho: {Total} sản phẩm", totalRestored);
                }

                // 2. Xóa doanh thu nếu có (trường hợp đã ghi nhầm)
                var revenue = await context.Revenues
                    .FirstOrDefaultAsync(r => r.OrderID == order.OrderID);

                if (revenue != null)
                {
                    context.Revenues.Remove(revenue);
                    _logger.LogInformation("      💸 Đã xóa doanh thu: {Amount:N0}₫", revenue.Amount);
                }

                // 3. Hoàn trạng thái thanh toán nếu đã thanh toán nhầm
                var orderPayment = order.OrderPayments?.FirstOrDefault();
                if (orderPayment != null && orderPayment.Status == (int)PaymentStatus.Paid)
                {
                    orderPayment.Status = (int)PaymentStatus.Unpaid;
                    order.CodCollected = false;
                    _logger.LogInformation("      Đã hoàn trạng thái thanh toán");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error handling GHN delivery failed for Order {OrderId}", order.OrderID);
            }
        }

        /// <summary>
        /// Xử lý đơn hàng bị hủy từ GHN
        /// QUAN TRỌNG: Hoàn kho
        /// </summary>
        private async Task HandleGhnOrderCancelled(Order order, AppDbContext context)
        {
            try
            {
                _logger.LogWarning("  └─ ❌ GHN hủy đơn hàng");

                // Hoàn trả số lượng sản phẩm vào kho
                if (order.OrderDetails != null && order.OrderDetails.Any())
                {
                    int totalRestored = 0;
                    foreach (var detail in order.OrderDetails)
                    {
                        if (detail.Variant != null)
                        {
                            var oldQty = detail.Variant.StockQuantity;
                            detail.Variant.StockQuantity += detail.Quantity;
                            totalRestored += detail.Quantity;

                            _logger.LogInformation(
                                "      🔄 VariantID {VariantId}: +{Qty} (Stock: {OldQty} → {NewQty})",
                                detail.Variant.VariantID, detail.Quantity, oldQty, detail.Variant.StockQuantity);
                        }
                    }
                    _logger.LogInformation("      Tổng hoàn kho: {Total} sản phẩm", totalRestored);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error handling GHN order cancelled for Order {OrderId}", order.OrderID);
            }
        }

        private string GetOrderStatusText(OrderStatusEnums status)
        {
            return status switch
            {
                OrderStatusEnums.Pending => "Chờ xác nhận",
                OrderStatusEnums.Confirmed => "Đã xác nhận",
                OrderStatusEnums.Processing => "Đang xử lý",
                OrderStatusEnums.Shipped => "Đang giao hàng",
                OrderStatusEnums.Delivered => "Đã giao hàng",
                OrderStatusEnums.Cancelled => "Đã hủy",
                OrderStatusEnums.Returned => "Đã hoàn trả",
                _ => "Không xác định"
            };
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GHN Status Simulation Service is stopping");
            await base.StopAsync(cancellationToken);
        }
    }
}
