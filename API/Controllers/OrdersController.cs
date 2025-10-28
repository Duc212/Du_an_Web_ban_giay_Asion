using BUS.Services;
using BUS.Services.Interfaces;
using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<CommonResponse<bool>> CreateOrder([FromBody] CreateOrderReq createOrder)
        {
            var result = await _orderServices.CreateOrder(createOrder);
            return result;
        }
        [HttpPost]
        [Route("UpdateStatusOrder")]
        public async Task<CommonResponse<bool>> UpdateStatusOrder(UpdateStatusOrderReq req)
        {
            var result = await _orderServices.UpdateStatusOrder(req);
            return result;
        }
        [HttpPost]
        [Route("GetListOrder")]
        public async Task<CommonPagination<GetListOrderRes>> GetListOrder(string? FullName, string? OrderCode, int? Status, DateTime? CreatedDate, int CurrentPage, int RecordPerPage)
        {
            var result = await _orderServices.GetListOrder(FullName, OrderCode, Status, CreatedDate, CurrentPage, RecordPerPage);
            return result;
        }
    }
}
