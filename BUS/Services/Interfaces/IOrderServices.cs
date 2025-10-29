using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<CommonResponse<bool>> CreateOrder(CreateOrderReq req);
        Task<CommonResponse<bool>> UpdateStatusOrder(UpdateStatusOrderReq req);
        Task<CommonPagination<GetListOrderRes>> GetListOrder(string? FullName, string? OrderCode, int? Status,DateTime? CreatedDate,int CurrentPage, int RecordPerPage);
        Task<CommonResponse<GetOrderDetailRes>> GetOrderDetail(int OrderID);
        Task<CommonResponse<bool>> ConfirmOrderAsync(ConfirmOrderReq req);
    }
}
