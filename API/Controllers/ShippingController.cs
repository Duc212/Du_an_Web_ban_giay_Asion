using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Shipping;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IGhnService _ghnService;
        private readonly ILogger<ShippingController> _logger;

        public ShippingController(
            IGhnService ghnService,
            ILogger<ShippingController> logger)
        {
            _ghnService = ghnService;
            _logger = logger;
        }

        /// <summary>
        /// Tạo đơn hàng trên GHN
        /// POST /api/shipping/create-ghn
        /// </summary>
        [HttpPost("create-ghn")]
        [BAuthorize] // Chỉ admin mới được gửi đơn lên GHN
        public async Task<ActionResult<CreateGhnOrderResult>> CreateGhnOrder([FromBody] CreateGhnOrderRequest request)
        {
            try
            {
                if (request.OrderId <= 0)
                {
                    return BadRequest(new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = "OrderId không hợp lệ"
                    });
                }

                var result = await _ghnService.CreateOrderAsync(request);
                
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateGhnOrder endpoint");
                return StatusCode(500, new CreateGhnOrderResult
                {
                    Success = false,
                    Message = "Lỗi server khi tạo đơn GHN"
                });
            }
        }

        /// <summary>
        /// Lấy thông tin tracking đơn hàng
        /// GET /api/shipping/{orderId}/tracking
        /// </summary>
        [HttpGet("{orderId}/tracking")]
        public async Task<ActionResult<OrderTrackingResponse>> GetOrderTracking(int orderId)
        {
            try
            {
                if (orderId <= 0)
                {
                    return BadRequest("OrderId không hợp lệ");
                }

                var result = await _ghnService.GetOrderTrackingAsync(orderId);
                
                if (result == null)
                {
                    return NotFound($"Không tìm thấy thông tin tracking cho Order {orderId}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOrderTracking endpoint for OrderId {OrderId}", orderId);
                return StatusCode(500, "Lỗi server khi lấy thông tin tracking");
            }
        }

        /// <summary>
        /// Tính phí vận chuyển GHN
        /// POST /api/shipping/calculate-fee
        /// </summary>
        [HttpPost("calculate-fee")]
        public async Task<ActionResult<GhnCalculateFeeResponse>> CalculateFee([FromBody] GhnCalculateFeeRequest request)
        {
            try
            {
                var result = await _ghnService.CalculateFeeAsync(request);
                
                if (result == null)
                {
                    return BadRequest("Không thể tính phí vận chuyển");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CalculateFee endpoint");
                return StatusCode(500, "Lỗi server khi tính phí");
            }
        }

   
        [HttpGet("ghn-detail/{ghnOrderCode}")]
        [BAuthorize]
        public async Task<ActionResult<GhnOrderDetailResponse>> GetGhnOrderDetail(string ghnOrderCode)
        {
            try
            {
                if (string.IsNullOrEmpty(ghnOrderCode))
                {
                    return BadRequest("GHN Order Code không hợp lệ");
                }

                var result = await _ghnService.GetOrderDetailAsync(ghnOrderCode);
                
                if (result == null)
                {
                    return NotFound($"Không tìm thấy đơn hàng GHN: {ghnOrderCode}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetGhnOrderDetail endpoint for {GhnOrderCode}", ghnOrderCode);
                return StatusCode(500, "Lỗi server khi lấy chi tiết GHN");
            }
        }
    }
}
