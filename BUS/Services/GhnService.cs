using BUS.Services.Interfaces;
using DAL;
using DAL.DTOs.Shipping;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BUS.Services
{
    public class GhnService : IGhnService
    {
        private readonly HttpClient _httpClient;
        private readonly GhnOptions _ghnOptions;
        private readonly AppDbContext _context;
        private readonly ILogger<GhnService> _logger;

        public GhnService(
            HttpClient httpClient,
            IOptions<GhnOptions> ghnOptions,
            AppDbContext context,
            ILogger<GhnService> logger)
        {
            _httpClient = httpClient;
            _ghnOptions = ghnOptions.Value;
            _context = context;
            _logger = logger;

            // Configure HttpClient base address and default headers
            _httpClient.BaseAddress = new Uri(_ghnOptions.BaseUrl);
            _httpClient.DefaultRequestHeaders.Clear();
            
            // IMPORTANT: Đổi Token và ShopId khi deploy production
            _httpClient.DefaultRequestHeaders.Add("Token", _ghnOptions.Token);
            _httpClient.DefaultRequestHeaders.Add("ShopId", _ghnOptions.ShopId);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Tạo đơn hàng trên GHN
        /// </summary>
        public async Task<CreateGhnOrderResult> CreateOrderAsync(CreateGhnOrderRequest request)
        {
            try
            {
                // 0. Test shop info first
                try
                {
                    var shopInfoResponse = await _httpClient.GetAsync("/v2/shop/all");
                    var shopInfoContent = await shopInfoResponse.Content.ReadAsStringAsync();
                    _logger.LogInformation("📦 Shop Info: {ShopInfo}", shopInfoContent);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Cannot get shop info: {Error}", ex.Message);
                }

                // 1. Lấy thông tin order từ DB
                var order = await _context.Orders
                    .Include(o => o.User)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Variant)
                            .ThenInclude(v => v.Product)
                    .FirstOrDefaultAsync(o => o.OrderID == request.OrderId);

                if (order == null)
                {
                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = "Order not found"
                    };
                }

                // Kiểm tra đã gửi GHN chưa
                if (!string.IsNullOrEmpty(order.GhnOrderCode))
                {
                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = $"Order đã được gửi GHN với mã: {order.GhnOrderCode}"
                    };
                }

                // 2. Chuẩn bị payload - Theo đúng GHN API spec
                var payload = new GhnCreateOrderPayload
                {
                    PaymentTypeId = request.PaymentTypeId ?? 2, // 2 = Người nhận trả phí
                    Note = request.Note ?? order.Note,
                    RequiredNote = "KHONGCHOXEMHANG",
                    
                    // Thông tin người gửi (shop) - IMPORTANT: Phải có địa chỉ kho trong GHN
                    FromName = request.FromName ?? "ASION Store",
                    FromPhone = request.FromPhone ?? "0862158868",
                    FromAddress = request.FromAddress ?? "72 Thành Thái, Phường 14",
                    FromWardCode = request.FromWardCode ?? "20308",  
                    FromDistrictId = string.IsNullOrEmpty(request.FromDistrictId) ? 1454 : int.Parse(request.FromDistrictId),
                    
                    // Thông tin người nhận - FIX: Validate phone number
                    ToName = request.ToName ?? order.User?.FullName ?? "Khách hàng",
                    ToPhone = request.ToPhone ?? 
                              (!string.IsNullOrWhiteSpace(order.User?.Phone) ? order.User.Phone : "0862158868"),
                    ToAddress = request.ToAddress ?? order.Address ?? "Địa chỉ khách hàng",
                    ToWardCode = request.ToWardCode ?? "20308",
                    ToDistrictId = string.IsNullOrEmpty(request.ToDistrictId) ? 1454 : int.Parse(request.ToDistrictId),
                    
                    // COD
                    CodAmount = request.CodAmount ?? (int)order.TotalAmount,
                    Content = $"Đơn hàng {order.OrderCode}",
                    
                    // Kích thước & trọng lượng
                    Weight = request.Weight ?? 1000,
                    Length = request.Length ?? 20,
                    Width = request.Width ?? 20,
                    Height = request.Height ?? 10,
                    
                    ServiceTypeId = request.ServiceTypeId ?? 2,
                    
                    // Danh sách sản phẩm
                    Items = order.OrderDetails.Select(od => new GhnOrderItem
                    {
                        Name = od.Variant?.Product?.Name ?? "Sản phẩm",
                        Quantity = od.Quantity,
                        Price = (int)(od.Variant?.SellingPrice ?? 0)
                    }).ToList()
                };

                // 3. Log request
                var requestJson = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("GHN Create Order Request for OrderID {OrderId}:\n{Request}", 
                    request.OrderId, requestJson);
                
                // Log full URL
                var fullUrl = $"{_httpClient.BaseAddress}v2/shipping-order/create";
                _logger.LogInformation("🌐 Full GHN URL: {Url}", fullUrl);
                _logger.LogInformation("🔑 Token: {Token}, ShopId: {ShopId}", 
                    _ghnOptions.Token?.Substring(0, 10) + "...", 
                    _ghnOptions.ShopId);

                // 4. Gọi GHN API
                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/create", payload);
                var responseContent = await response.Content.ReadAsStringAsync();
                
                _logger.LogInformation("GHN Response Status: {StatusCode}, Body:\n{Response}", 
                    response.StatusCode, responseContent);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN API Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    
                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = $"GHN API Error: {response.StatusCode} - {responseContent}"
                    };
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<GhnCreateOrderResponse>>(
                    responseContent, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (ghnResponse == null || ghnResponse.Code != 200 || ghnResponse.Data == null)
                {
                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = ghnResponse?.Message ?? "GHN returned invalid response"
                    };
                }

                // 5. Lưu thông tin GHN vào DB
                order.GhnOrderCode = ghnResponse.Data.OrderCode;
                order.GhnStatus = "pending";
                order.GhnFee = ghnResponse.Data.TotalFee;
                order.GhnCreatedAt = DateTime.Now;
                order.GhnUpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                _logger.LogInformation("✅ Order {OrderId} successfully created on GHN with code: {GhnOrderCode}", 
                    request.OrderId, ghnResponse.Data.OrderCode);

                return new CreateGhnOrderResult
                {
                    Success = true,
                    Message = "Đơn hàng đã được gửi lên GHN thành công",
                    GhnOrderCode = ghnResponse.Data.OrderCode,
                    TotalFee = ghnResponse.Data.TotalFee,
                    ExpectedDeliveryTime = ghnResponse.Data.ExpectedDeliveryTime
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating GHN order for OrderID {OrderId}", request.OrderId);
                return new CreateGhnOrderResult
                {
                    Success = false,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Lấy chi tiết đơn hàng từ GHN
        /// </summary>
        public async Task<GhnOrderDetailResponse?> GetOrderDetailAsync(string ghnOrderCode)
        {
            try
            {
                var payload = new { order_code = ghnOrderCode };
                
                _logger.LogInformation("Getting GHN order detail for: {GhnOrderCode}", ghnOrderCode);

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/detail", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN GetOrderDetail Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<GhnOrderDetailResponse>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting GHN order detail for: {GhnOrderCode}", ghnOrderCode);
                return null;
            }
        }

        /// <summary>
        /// Tính phí vận chuyển GHN
        /// </summary>
        public async Task<GhnCalculateFeeResponse?> CalculateFeeAsync(GhnCalculateFeeRequest request)
        {
            try
            {
                _logger.LogInformation("Calculating GHN fee");

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/fee", request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN CalculateFee Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<GhnCalculateFeeResponse>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating GHN fee");
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin tracking từ DB
        /// </summary>
        public async Task<OrderTrackingResponse?> GetOrderTrackingAsync(int orderId)
        {
            try
            {
                var order = await _context.Orders
                    .Where(o => o.OrderID == orderId)
                    .Select(o => new OrderTrackingResponse
                    {
                        OrderId = o.OrderID,
                        OrderCode = o.OrderCode,
                        GhnOrderCode = o.GhnOrderCode,
                        GhnStatus = o.GhnStatus,
                        GhnFee = o.GhnFee,
                        CodCollected = o.CodCollected,
                        LastUpdated = o.GhnUpdatedAt
                    })
                    .FirstOrDefaultAsync();

                // Nếu có GhnOrderCode, lấy thêm status text từ GHN
                if (order != null && !string.IsNullOrEmpty(order.GhnOrderCode))
                {
                    var ghnDetail = await GetOrderDetailAsync(order.GhnOrderCode);
                    if (ghnDetail != null)
                    {
                        order.GhnStatusText = ghnDetail.StatusText;
                        order.ExpectedDeliveryTime = ghnDetail.ExpectedDeliveryTime;
                    }
                }

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order tracking for OrderID {OrderId}", orderId);
                return null;
            }
        }
    }
}
