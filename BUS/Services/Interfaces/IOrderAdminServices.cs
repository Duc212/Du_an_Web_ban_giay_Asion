using DAL.DTOs.Orders.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IOrderAdminServices
    {
        Task<CommonResponse<List<AdminOrderListItem>>> GetAllOrders(
            int pageIndex,
            int pageSize,
            string? keyword,
            int? status,
            int? paymentStatus,
            int? paymentMethod,
            DateTime? fromDate,
            DateTime? toDate,
            string sortBy,
            string sortOrder);

        Task<CommonResponse<List<AdminOrderListItem>>> GetPendingOrders(int pageIndex, int pageSize);
        
        Task<CommonResponse<AdminOrderDetail>> GetOrderDetail(int orderId);
        
        Task<CommonResponse<bool>> UpdateOrderStatus(int orderId, int newStatus, string? note, int? updatedBy);
        
        Task<CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>> ConfirmOrder(int orderId, string shippingProvider, DateTime estimatedDelivery, string? note);
        
        Task<CommonResponse<bool>> CancelOrder(int orderId, string cancelReason, bool refundRequired);
        
        Task<CommonResponse<bool>> UpdatePaymentStatus(int orderId, int paymentStatus, string? note);
        
        Task<CommonResponse<bool>> UpdateShippingInfo(int orderId, string shippingProvider, string trackingNumber, DateTime? shippedDate, DateTime? estimatedDelivery, string? note);
        
        Task<CommonResponse<OrderStatistics>> GetOrderStatistics(DateTime? fromDate, DateTime? toDate);
        
        Task<CommonResponse<OrderStatisticsSummary>> GetOrderStatisticsSummary();
        
        Task<CommonResponse<RevenueReportRes>> GetRevenueReport(DateTime? fromDate, DateTime? toDate, string groupBy);
        
        Task<CommonResponse<List<AdminOrderListItem>>> SearchOrders(string keyword, int pageIndex, int pageSize);
        
        Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByStatus(int status, int pageIndex, int pageSize);
        
        Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByDateRange(DateTime fromDate, DateTime toDate, int pageIndex, int pageSize);
        
        Task<CommonResponse<BulkUpdateResult>> BulkUpdateStatus(List<int> orderIds, int newStatus, string? note);
    }

    public class RevenueReportRes
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public List<RevenueByDateRes> RevenueByDate { get; set; } = new();
        public List<RevenueByStatusRes> RevenueByStatus { get; set; } = new();
        public List<PaymentMethodStatsRes> PaymentMethodStats { get; set; } = new();
    }

    public class RevenueByDateRes
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
    }

    public class RevenueByStatusRes
    {
        public int Status { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
    }

    public class PaymentMethodStatsRes
    {
        public int PaymentMethod { get; set; }
        public string PaymentMethodText { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
    }

    public class BulkUpdateResult
    {
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<BulkUpdateDetail> Details { get; set; } = new();
    }

    public class BulkUpdateDetail
    {
        public int OrderID { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
