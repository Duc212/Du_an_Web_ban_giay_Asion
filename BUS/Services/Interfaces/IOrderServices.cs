using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.DTOs.Payments.Req;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<CommonResponse<int>> CreateOrder(CreateOrderReq req);
        Task<CommonResponse<bool>> UpdateStatusOrder(UpdateStatusOrderReq req);
        Task<CommonPagination<GetListOrderRes>> GetListOrder(string? FullName, string? OrderCode, int? Status, DateTime? CreatedDate, int CurrentPage, int RecordPerPage);
        Task<CommonResponse<GetOrderDetailRes>> GetOrderDetail(int OrderID);
        Task<CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>> ConfirmOrderAsync(ConfirmOrderReq req);
        Task<CommonPagination<List<GetOrderRes>>> GetOrdersByUserId(int userId, int CurrentPage, int RecordPerPage);
        Task<CommonResponse<bool>> UpdateStatusPayment(UpdatePaymentReq req);
        Task<CommonResponse<GetOrderStatisticsRes>> GetOrderStatistics(DateTime? fromDate = null, DateTime? toDate = null);
    }
}
