using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Orders.Res;
using DAL.Entities;
using Helper.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAdminController : ControllerBase
    {
        private readonly IOrderAdminServices _orderAdminServices;

        public OrderAdminController(IOrderAdminServices orderAdminServices)
        {
            _orderAdminServices = orderAdminServices;
        }

        /// <summary>
        /// 1. GET /GetAllOrders - L?y t?t c? ??n h�ng v?i b? l?c v� ph�n trang
        /// </summary>
        [HttpGet("GetAllOrders")]
        [BAuthorize]
        public async Task<CommonResponse<List<AdminOrderListItem>>> GetAllOrders(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? keyword = null,
            [FromQuery] int? status = null,
            [FromQuery] int? paymentStatus = null,
            [FromQuery] int? paymentMethod = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string sortBy = "orderDate",
            [FromQuery] string sortOrder = "desc")
        {
            return await _orderAdminServices.GetAllOrders(
                pageIndex, pageSize, keyword, status, paymentStatus, 
                paymentMethod, fromDate, toDate, sortBy, sortOrder);
        }

        /// <summary>
        /// 2. GET /GetPendingOrders - L?y ??n h�ng ch? x�c nh?n
        /// </summary>
        [HttpGet("GetPendingOrders")]
        [BAuthorize]
        public async Task<CommonResponse<List<AdminOrderListItem>>> GetPendingOrders(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 20)
        {
            return await _orderAdminServices.GetPendingOrders(pageIndex, pageSize);
        }

        /// <summary>
        /// 3. GET /GetOrderDetail/{orderId} - L?y chi ti?t ??n h�ng
        /// </summary>
        [HttpGet("GetOrderDetail/{orderId}")]
        [BAuthorize]
        public async Task<CommonResponse<AdminOrderDetail>> GetOrderDetail(int orderId)
        {
            return await _orderAdminServices.GetOrderDetail(orderId);
        }

        /// <summary>
        /// 4. PUT /UpdateOrderStatus - C?p nh?t tr?ng th�i ??n h�ng
        /// </summary>
        [HttpPut("UpdateOrderStatus")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateOrderStatus([FromBody] UpdateOrderStatusRequest request)
        {
            var updatedBy = HttpContextHelper.GetUserId();
            return await _orderAdminServices.UpdateOrderStatus(
                request.OrderID, 
                request.NewStatus, 
                request.Note, 
                updatedBy);
        }

        /// <summary>
        /// 5. POST /ConfirmOrder - X�c nh?n ??n h�ng
        /// </summary>
        [HttpPost("ConfirmOrder")]
        [BAuthorize]
        public async Task<CommonResponse<ConfirmOrderResponse>> ConfirmOrder([FromBody] ConfirmOrderRequest request)
        {
            return await _orderAdminServices.ConfirmOrder(
                request.OrderID,
                request.ShippingProvider,
                request.EstimatedDelivery,
                request.Note);
        }

        /// <summary>
        /// 6. POST /CancelOrder - H?y ??n h�ng
        /// </summary>
        [HttpPost("CancelOrder")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> CancelOrder([FromBody] CancelOrderRequest request)
        {
            return await _orderAdminServices.CancelOrder(
                request.OrderID,
                request.CancelReason,
                request.RefundRequired);
        }

        /// <summary>
        /// 7. PUT /UpdatePaymentStatus - C?p nh?t tr?ng th�i thanh to�n
        /// </summary>
        [HttpPut("UpdatePaymentStatus")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdatePaymentStatus([FromBody] UpdatePaymentStatusRequest request)
        {
            return await _orderAdminServices.UpdatePaymentStatus(
                request.OrderID,
                request.PaymentStatus,
                request.Note);
        }

        /// <summary>
        /// 8. PUT /UpdateShippingInfo - C?p nh?t th�ng tin v?n chuy?n
        /// </summary>
        [HttpPut("UpdateShippingInfo")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateShippingInfo([FromBody] UpdateShippingInfoRequest request)
        {
            return await _orderAdminServices.UpdateShippingInfo(
                request.OrderID,
                request.ShippingProvider,
                request.TrackingNumber,
                request.ShippedDate,
                request.EstimatedDelivery,
                request.Note);
        }

        /// <summary>
        /// 9. GET /GetOrderStatistics - L?y th?ng k� ??n h�ng
        /// </summary>
        [HttpGet("GetOrderStatistics")]
        [BAuthorize]
        public async Task<CommonResponse<OrderStatistics>> GetOrderStatistics(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            return await _orderAdminServices.GetOrderStatistics(fromDate, toDate);
        }

        /// <summary>
        /// 10. GET /GetRevenueReport - L?y b�o c�o doanh thu
        /// </summary>
        [HttpGet("GetRevenueReport")]
        [BAuthorize]
        public async Task<CommonResponse<RevenueReportRes>> GetRevenueReport(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string groupBy = "day")
        {
            return await _orderAdminServices.GetRevenueReport(fromDate, toDate, groupBy);
        }

        /// <summary>
        /// 11. GET /SearchOrders - T�m ki?m ??n h�ng
        /// </summary>
        [HttpGet("SearchOrders")]
        [BAuthorize]
        public async Task<CommonResponse<List<AdminOrderListItem>>> SearchOrders(
            [FromQuery] string keyword,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 20)
        {
            return await _orderAdminServices.SearchOrders(keyword, pageIndex, pageSize);
        }

        /// <summary>
        /// 12. GET /GetOrdersByStatus - L?y ??n h�ng theo tr?ng th�i
        /// </summary>
        [HttpGet("GetOrdersByStatus")]
        [BAuthorize]
        public async Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByStatus(
            [FromQuery] int status,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 20)
        {
            return await _orderAdminServices.GetOrdersByStatus(status, pageIndex, pageSize);
        }

        /// <summary>
        /// 13. GET /GetOrdersByDateRange - L?y ??n h�ng theo kho?ng th?i gian
        /// </summary>
        [HttpGet("GetOrdersByDateRange")]
        [BAuthorize]
        public async Task<CommonResponse<List<AdminOrderListItem>>> GetOrdersByDateRange(
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 20)
        {
            return await _orderAdminServices.GetOrdersByDateRange(fromDate, toDate, pageIndex, pageSize);
        }

        /// <summary>
        /// 14. POST /BulkUpdateStatus - C?p nh?t tr?ng th�i h�ng lo?t
        /// </summary>
        [HttpPost("BulkUpdateStatus")]
        [BAuthorize]
        public async Task<CommonResponse<BulkUpdateResult>> BulkUpdateStatus([FromBody] BulkUpdateStatusRequest request)
        {
            return await _orderAdminServices.BulkUpdateStatus(
                request.OrderIDs,
                request.NewStatus,
                request.Note);
        }

        /// <summary>
        /// 15. GET /GetOrderStatisticsSummary - L?y th?ng k� t?ng quan ??n h�ng cho dashboard
        /// </summary>
        [HttpGet("GetOrderStatisticsSummary")]
        [BAuthorize]
        public async Task<CommonResponse<OrderStatisticsSummary>> GetOrderStatisticsSummary()
        {
            return await _orderAdminServices.GetOrderStatisticsSummary();
        }
    }

    // Request DTOs
    public class BulkUpdateStatusRequest
    {
        public List<int> OrderIDs { get; set; } = new();
        public int NewStatus { get; set; }
        public string? Note { get; set; }
    }
}
