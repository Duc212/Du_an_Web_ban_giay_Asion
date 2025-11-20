using API.Extensions;
using BUS.Services;
using BUS.Services.Interfaces;
using DAL.DTOs.Orders.Req;
using DAL.DTOs.Orders.Res;
using DAL.DTOs.Payments.Req;
using DAL.Entities;
using Helper.Utils;
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
        public async Task<CommonResponse<int>> CreateOrder([FromBody] CreateOrderReq createOrder)
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
        [HttpGet]
        [Route("GetListOrder")]
        public async Task<CommonPagination<GetListOrderRes>> GetListOrder(string? FullName, string? OrderCode, int? Status, DateTime? CreatedDate, int CurrentPage, int RecordPerPage)
        {
            var result = await _orderServices.GetListOrder(FullName, OrderCode, Status, CreatedDate, CurrentPage, RecordPerPage);
            return result;
        }
        [HttpPost]
        [Route("ConfirmOrder")]
        public async Task<CommonResponse<DAL.DTOs.Orders.Res.ConfirmOrderResponse>> ConfirmOrderAsync(ConfirmOrderReq req)
        {
            return await _orderServices.ConfirmOrderAsync(req);
        }
        [HttpGet]
        [Route("GetListOrderByUser")]
        [BAuthorize]
        public async Task<CommonPagination<List<GetOrderRes>>> GetListOrder(int CurrentPage, int RecordPerPage)
        {
            var userId = HttpContextHelper.GetUserId();
            return await _orderServices.GetOrdersByUserId(userId, CurrentPage, RecordPerPage);
        }
        [HttpPost]
        [Route("UpdateStatusPayment")]
        public async Task<CommonResponse<bool>> UpdateStatusPayment(UpdatePaymentReq req)
        {
            return await _orderServices.UpdateStatusPayment(req);
        }

        [HttpGet]
        [Route("GetOrderStatistics")]
        [BAuthorize]
        public async Task<CommonResponse<GetOrderStatisticsRes>> GetOrderStatistics(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            return await _orderServices.GetOrderStatistics(fromDate, toDate);
        }
    }
}
