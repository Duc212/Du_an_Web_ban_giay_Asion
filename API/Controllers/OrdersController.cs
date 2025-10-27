using BUS.Services.Interfaces;
using DAL.DTOs;
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
        [HttpPost("CreateOrder")]
        public async Task<CommonResponse<bool>> CreateOrder([FromBody] CreateOrderDTO createOrder)
        {
            var result = await _orderServices.CreateOrder(createOrder);
            return result;
        }
    }
}
