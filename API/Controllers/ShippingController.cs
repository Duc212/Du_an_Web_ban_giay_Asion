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
        [BAuthorize]
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

        /// <summary>
        /// Lấy chi tiết đơn hàng GHN
        /// GET /api/shipping/ghn-detail/{ghnOrderCode}
        /// </summary>
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

        /// <summary>
        /// [DEBUG] Lấy danh sách Shop từ GHN để kiểm tra ShopId
        /// GET /api/shipping/test-shops
        /// </summary>
        [HttpGet("test-shops")]
        [BAuthorize]
        public async Task<ActionResult<string>> TestGetShops()
        {
            try
            {
                var result = await _ghnService.GetAllShopsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in TestGetShops endpoint");
                return StatusCode(500, "Lỗi server");
            }
        }

        /// <summary>
        /// Lấy danh sách tỉnh/thành phố
        /// GET /api/shipping/provinces
        /// </summary>
        [HttpGet("provinces")]
        public async Task<ActionResult<GhnProvinceResponse>> GetProvinces()
        {
            try
            {
                var result = await _ghnService.GetProvincesAsync();
                
                if (result == null)
                {
                    return BadRequest("Không thể lấy danh sách tỉnh/thành");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetProvinces endpoint");
                return StatusCode(500, "Lỗi server khi lấy danh sách tỉnh");
            }
        }

        /// <summary>
        /// Lấy danh sách quận/huyện theo tỉnh
        /// GET /api/shipping/districts/{provinceId}
        /// </summary>
        [HttpGet("districts/{provinceId}")]
        public async Task<ActionResult<GhnDistrictResponse>> GetDistricts(int provinceId)
        {
            try
            {
                var result = await _ghnService.GetDistrictsAsync(provinceId);
                
                if (result == null)
                {
                    return BadRequest("Không thể lấy danh sách quận/huyện");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetDistricts endpoint");
                return StatusCode(500, "Lỗi server khi lấy danh sách quận");
            }
        }

        /// <summary>
        /// Lấy danh sách phường/xã theo quận
        /// GET /api/shipping/wards/{districtId}
        /// </summary>
        [HttpGet("wards/{districtId}")]
        public async Task<ActionResult<GhnWardResponse>> GetWards(int districtId)
        {
            try
            {
                var result = await _ghnService.GetWardsAsync(districtId);
                
                if (result == null)
                {
                    return BadRequest("Không thể lấy danh sách phường/xã");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetWards endpoint");
                return StatusCode(500, "Lỗi server khi lấy danh sách phường");
            }
        }

        /// <summary>
        /// Cập nhật note cho đơn hàng GHN
        /// PUT /api/shipping/update-note
        /// </summary>
        [HttpPut("update-note")]
        [BAuthorize]
        public async Task<ActionResult<CommonResponse<bool>>> UpdateGhnOrderNote([FromBody] UpdateGhnOrderRequest request)
        {
            try
            {
                var result = await _ghnService.UpdateOrderAsync(request.OrderCode, request.Note);

                return Ok(new CommonResponse<bool>
                {
                    Success = result,
                    Message = result ? "Cập nhật ghi chú thành công" : "Không thể cập nhật ghi chú",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateGhnOrderNote endpoint");
                return StatusCode(500, new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Lỗi server khi cập nhật ghi chú"
                });
            }
        }

        /// <summary>
        /// Hủy đơn hàng GHN
        /// POST /api/shipping/cancel
        /// </summary>
        [HttpPost("cancel")]
        [BAuthorize]
        public async Task<ActionResult<CommonResponse<bool>>> CancelGhnOrder([FromBody] CancelGhnOrderRequest request)
        {
            try
            {
                var result = await _ghnService.CancelOrderAsync(request.OrderCodes);

                return Ok(new CommonResponse<bool>
                {
                    Success = result,
                    Message = result ? "Hủy đơn hàng thành công" : "Không thể hủy đơn hàng",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CancelGhnOrder endpoint");
                return StatusCode(500, new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Lỗi server khi hủy đơn hàng"
                });
            }
        }

        /// <summary>
        /// Trả hàng GHN
        /// POST /api/shipping/return
        /// </summary>
        [HttpPost("return")]
        [BAuthorize]
        public async Task<ActionResult<CommonResponse<bool>>> ReturnGhnOrder([FromBody] ReturnGhnOrderRequest request)
        {
            try
            {
                var result = await _ghnService.ReturnOrderAsync(request.OrderCodes);

                return Ok(new CommonResponse<bool>
                {
                    Success = result,
                    Message = result ? "Yêu cầu trả hàng thành công" : "Không thể yêu cầu trả hàng",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ReturnGhnOrder endpoint");
                return StatusCode(500, new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Lỗi server khi yêu cầu trả hàng"
                });
            }
        }

        /// <summary>
        /// Cập nhật số tiền COD
        /// PUT /api/shipping/update-cod
        /// </summary>
        [HttpPut("update-cod")]
        [BAuthorize]
        public async Task<ActionResult<CommonResponse<bool>>> UpdateCOD([FromBody] UpdateCODRequest request)
        {
            try
            {
                var result = await _ghnService.UpdateCODAsync(request.OrderCode, request.CodAmount);

                return Ok(new CommonResponse<bool>
                {
                    Success = result,
                    Message = result ? "Cập nhật COD thành công" : "Không thể cập nhật COD",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateCOD endpoint");
                return StatusCode(500, new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Lỗi server khi cập nhật COD"
                });
            }
        }

        /// <summary>
        /// Lấy thời gian dự kiến giao hàng
        /// POST /api/shipping/lead-time
        /// </summary>
        [HttpPost("lead-time")]
        public async Task<ActionResult<CommonResponse<DateTime?>>> GetLeadTime([FromBody] LeadTimeRequest request)
        {
            try
            {
                var result = await _ghnService.GetLeadTimeAsync(
                    request.FromDistrictId,
                    request.FromWardCode,
                    request.ToDistrictId,
                    request.ToWardCode,
                    request.ServiceId);

                return Ok(new CommonResponse<DateTime?>
                {
                    Success = result.HasValue,
                    Message = result.HasValue ? "Lấy thời gian giao hàng thành công" : "Không thể lấy thời gian giao hàng",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetLeadTime endpoint");
                return StatusCode(500, new CommonResponse<DateTime?>
                {
                    Success = false,
                    Message = "Lỗi server khi lấy thời gian giao hàng"
                });
            }
        }

        /// <summary>
        /// Preview đơn hàng trước khi tạo
        /// POST /api/shipping/preview
        /// </summary>
        [HttpPost("preview")]
        [BAuthorize]
        public async Task<ActionResult<CommonResponse<GhnOrderPreviewResponse>>> PreviewOrder([FromBody] GhnCreateOrderPayload payload)
        {
            try
            {
                var result = await _ghnService.PreviewOrderAsync(payload);

                return Ok(new CommonResponse<GhnOrderPreviewResponse>
                {
                    Success = result != null,
                    Message = result != null ? "Preview đơn hàng thành công" : "Không thể preview đơn hàng",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in PreviewOrder endpoint");
                return StatusCode(500, new CommonResponse<GhnOrderPreviewResponse>
                {
                    Success = false,
                    Message = "Lỗi server khi preview đơn hàng"
                });
            }
        }
    }

    // ===== Request DTOs =====
    
    public class UpdateGhnOrderRequest
    {
        public string OrderCode { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

    public class CancelGhnOrderRequest
    {
        public List<string> OrderCodes { get; set; } = new();
    }

    public class ReturnGhnOrderRequest
    {
        public List<string> OrderCodes { get; set; } = new();
    }

    public class UpdateCODRequest
    {
        public string OrderCode { get; set; } = string.Empty;
        public int CodAmount { get; set; }
    }

    public class LeadTimeRequest
    {
        public int FromDistrictId { get; set; }
        public string FromWardCode { get; set; } = string.Empty;
        public int ToDistrictId { get; set; }
        public string ToWardCode { get; set; } = string.Empty;
        public int ServiceId { get; set; }
    }
}