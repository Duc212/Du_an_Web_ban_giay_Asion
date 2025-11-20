using DAL.Enums;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    /// <summary>
    /// Background service tự động hủy đơn hàng chưa thanh toán sau 24 giờ.
    /// Chạy mỗi giờ để kiểm tra đơn hết hạn.
    /// </summary>
    public class OrderCancellationService : BackgroundService
    {
        private readonly ILogger<OrderCancellationService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OrderCancellationService(
            ILogger<OrderCancellationService> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OrderCancellationService started at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CancelExpiredOrders(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error while executing OrderCancellationService");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private async Task CancelExpiredOrders(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var orderRepository = scope.ServiceProvider.GetRequiredService<IRepositoryAsync<Order>>();
            var orderPaymentRepository = scope.ServiceProvider.GetRequiredService<IRepositoryAsync<OrderPayment>>();

            var cutoffTime = DateTime.Now.AddHours(-24);
            var codPaymentId = 1; // paymentId = 1 => COD

            var expiredOrders = await orderRepository.AsQueryable()
                .Include(o => o.OrderPayments)
                    .ThenInclude(op => op.Payment)
                .Where(o =>
                    o.Status == (int)OrderStatusEnums.Pending &&  // Pending
                    o.OrderDate < cutoffTime &&                    // Over 24 hours
                    o.OrderPayments.Any(op =>
                        op.Payment != null && op.Payment.PaymentID != codPaymentId) // Not COD
                )
                .ToListAsync(cancellationToken);

            if (!expiredOrders.Any())
            {
                _logger.LogInformation("No expired orders found at {time}", DateTimeOffset.Now);
                return;
            }

            _logger.LogInformation("Found {count} expired orders to cancel", expiredOrders.Count);

            foreach (var order in expiredOrders)
            {
                try
                {
                    order.Status = (int)OrderStatusEnums.Cancelled;

                    await orderRepository.UpdateAsync(order);

                    _logger.LogInformation(
                        "Cancelled order {OrderCode} (ID: {OrderId}) - Created at {OrderDate}, Age: {Age} hours",
                        order.OrderCode,
                        order.OrderID,
                        order.OrderDate,
                        (DateTime.Now - order.OrderDate).TotalHours
                    );
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Failed to cancel order {OrderCode} (ID: {OrderId})",
                        order.OrderCode,
                        order.OrderID
                    );
                }
            }

            await orderRepository.SaveChangesAsync();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OrderCancellationService stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}
