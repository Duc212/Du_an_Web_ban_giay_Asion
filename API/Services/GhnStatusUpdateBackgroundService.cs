using BUS.Services.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    /// <summary>
    /// Background service tự động cập nhật trạng thái đơn hàng GHN
    /// Chạy mỗi 5 phút để đồng bộ status từ GHN API
    /// </summary>
    public class GhnStatusUpdateBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<GhnStatusUpdateBackgroundService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(5); // Chạy mỗi 5 phút

        public GhnStatusUpdateBackgroundService(
            IServiceProvider serviceProvider,
            ILogger<GhnStatusUpdateBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("GHN Status Update Background Service started at {Time}", DateTime.Now);

            // Đợi 1 phút sau khi app start mới chạy lần đầu
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("GHN Status Update job triggered at {Time}", DateTime.Now);

                    await UpdateGhnOrderStatusAsync(stoppingToken);

                    _logger.LogInformation("GHN Status Update job completed at {Time}. Next run in {Interval} minutes", 
                        DateTime.Now, _interval.TotalMinutes);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in GHN Status Update background service");
                }

                // Đợi 5 phút trước khi chạy lần tiếp theo
                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("GHN Status Update Background Service stopped at {Time}", DateTime.Now);
        }

        private async Task UpdateGhnOrderStatusAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var ghnService = scope.ServiceProvider.GetRequiredService<IGhnService>();

            try
            {
                // Lấy danh sách orders đang vận chuyển (có GhnOrderCode và chưa delivered/cancelled)
                var ordersToUpdate = await context.Orders
                    .Where(o => 
                        !string.IsNullOrEmpty(o.GhnOrderCode) && 
                        o.GhnStatus != "delivered" && 
                        o.GhnStatus != "cancel" &&
                        o.GhnStatus != "return" &&
                        o.Status != (int)OrderStatusEnums.Delivered &&
                        o.Status != (int)OrderStatusEnums.Cancelled)
                    .ToListAsync(cancellationToken);

                if (!ordersToUpdate.Any())
                {
                    _logger.LogInformation("No orders to update from GHN");
                    return;
                }

                _logger.LogInformation("Found {Count} orders to update from GHN", ordersToUpdate.Count);

                int successCount = 0;
                int failCount = 0;

                foreach (var order in ordersToUpdate)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    try
                    {
                        _logger.LogInformation("Updating order {OrderId} with GHN code {GhnCode}", 
                            order.OrderID, order.GhnOrderCode);

                        // Gọi GHN API để lấy status mới nhất
                        var ghnDetail = await ghnService.GetOrderDetailAsync(order.GhnOrderCode);

                        if (ghnDetail != null)
                        {
                            var oldStatus = order.GhnStatus;
                            var newStatus = ghnDetail.Status;

                            // Chỉ update nếu status thay đổi
                            if (oldStatus != newStatus)
                            {
                                order.GhnStatus = newStatus;
                                order.GhnUpdatedAt = DateTime.Now;

                                // Tự động update Order Status dựa trên GHN Status
                                UpdateOrderStatusByGhnStatus(order, newStatus);

                                // Check COD collected
                                if (ghnDetail.CodCollectDate != null)
                                {
                                    order.CodCollected = true;
                                }

                                context.Orders.Update(order);
                                await context.SaveChangesAsync(cancellationToken);

                                _logger.LogInformation(
                                    "Order {OrderId} updated: GhnStatus changed from '{OldStatus}' to '{NewStatus}'",
                                    order.OrderID, oldStatus, newStatus);

                                successCount++;
                            }
                            else
                            {
                                _logger.LogDebug("Order {OrderId}: No status change (still '{Status}')", 
                                    order.OrderID, oldStatus);
                            }
                        }
                        else
                        {
                            _logger.LogWarning("Failed to get GHN detail for order {OrderId} with code {GhnCode}",
                                order.OrderID, order.GhnOrderCode);
                            failCount++;
                        }

                        // Delay nhỏ giữa các request để tránh rate limit
                        await Task.Delay(500, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error updating order {OrderId} from GHN", order.OrderID);
                        failCount++;
                    }
                }

                _logger.LogInformation(
                    "GHN Status Update completed: {Success} succeeded, {Fail} failed out of {Total} orders",
                    successCount, failCount, ordersToUpdate.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateGhnOrderStatusAsync");
                throw;
            }
        }

        /// <summary>
        /// Tự động update Order Status dựa trên GHN Status
        /// </summary>
        private void UpdateOrderStatusByGhnStatus(Order order, string? ghnStatus)
        {
            if (string.IsNullOrEmpty(ghnStatus))
                return;

            switch (ghnStatus.ToLower())
            {
                case "pending":
                case "ready_to_pick":
                    // Chờ lấy hàng - giữ nguyên hoặc set Confirmed
                    if (order.Status == (int)OrderStatusEnums.Pending)
                        order.Status = (int)OrderStatusEnums.Confirmed;
                    break;

                case "picking":
                case "picked":
                    // Đang lấy hàng / Đã lấy hàng - set Processing
                    order.Status = (int)OrderStatusEnums.Processing;
                    break;

                case "storing":
                case "transporting":
                case "sorting":
                case "delivering":
                    // Đang vận chuyển - set Shipped
                    order.Status = (int)OrderStatusEnums.Shipped;
                    break;

                case "delivered":
                    // Đã giao - set Delivered
                    order.Status = (int)OrderStatusEnums.Delivered;
                    break;

                case "cancel":
                case "returned":
                case "return":
                    // Hủy / Hoàn trả - set Cancelled hoặc Returned
                    order.Status = (int)OrderStatusEnums.Returned;
                    break;

                case "exception":
                case "damage":
                case "lost":
                    // Ngoại lệ - log warning
                    _logger.LogWarning("Order {OrderId} has exception status: {Status}", 
                        order.OrderID, ghnStatus);
                    break;
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GHN Status Update Background Service is stopping");
            await base.StopAsync(cancellationToken);
        }
    }
}
