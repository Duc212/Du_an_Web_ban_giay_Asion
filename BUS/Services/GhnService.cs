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
            // Ensure BaseUrl ends with /
            var baseUrl = _ghnOptions.BaseUrl.TrimEnd('/') + "/";
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Clear();
            
            // IMPORTANT: Đổi Token và ShopId khi deploy production
            _httpClient.DefaultRequestHeaders.Add("Token", _ghnOptions.Token);
            _httpClient.DefaultRequestHeaders.Add("ShopId", _ghnOptions.ShopId);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Extract detailed address (street number, street name) from full address
        /// Removes ward/district/province names
        /// </summary>
        private string ExtractDetailedAddress(string? fullAddress)
        {
            if (string.IsNullOrWhiteSpace(fullAddress))
                return "Chưa cập nhật";

            // Nếu fullAddress được lưu từ Checkout (format: "47A, Phường X, Quận Y, Tỉnh Z")
            // Chỉ lấy phần đầu tiên (trước dấu phẩy đầu tiên)
            var parts = fullAddress.Split(',');
            if (parts.Length > 0)
            {
                var detailedAddress = parts[0].Trim();
                
                // Nếu địa chỉ chi tiết quá ngắn (< 3 ký tự), thêm prefix để GHN không reject
                if (detailedAddress.Length < 3)
                {
                    return $"Số nhà {detailedAddress}";
                }
                
                return detailedAddress; // Chỉ lấy số nhà + tên đường
            }

            return fullAddress;
        }

        /// <summary>
        /// Tạo đơn hàng trên GHN
        /// </summary>
        public async Task<CreateGhnOrderResult> CreateOrderAsync(CreateGhnOrderRequest request)
        {
            try
            {
                // 0. Log request đầu vào để debug
                _logger.LogInformation("🔍 CreateGhnOrderRequest received:");
                _logger.LogInformation("   - OrderId: {OrderId}", request.OrderId);
                _logger.LogInformation("   - ToAddress: '{ToAddress}'", request.ToAddress ?? "null");
                _logger.LogInformation("   - ToWardCode: '{ToWardCode}'", request.ToWardCode ?? "null");
                _logger.LogInformation("   - ToDistrictId: '{ToDistrictId}'", request.ToDistrictId ?? "null");

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
                    FromAddress = request.FromAddress ?? "72 Thành Thái, Phường 14, Quận 10, Hồ Chí Minh, Vietnam",
                    FromWardName = "Phường 14",
                    FromDistrictName = "Quận 10",
                    FromProvinceName = "HCM",
                    
                    // Thông tin trả hàng
                    ReturnPhone = request.FromPhone ?? "0862158868",
                    ReturnAddress = request.FromAddress ?? "72 Thành Thái, Phường 14",
                    ReturnDistrictId = null,
                    ReturnWardCode = "",
                    
                    // Client order code
                    ClientOrderCode = order.OrderCode,
                    
                    // Thông tin người nhận - ❌ KHÔNG lấy từ request vì có thể bị sai, CHỈ lấy từ DB
                    ToName = order.User?.FullName ?? "Khách hàng",
                    ToPhone = !string.IsNullOrWhiteSpace(order.User?.Phone) ? order.User.Phone : "0862158868",
                    
                    // ToAddress CHỈ chứa địa chỉ chi tiết (số nhà, tên đường)
                    ToAddress = ExtractDetailedAddress(order.Address),
                    
                    // ⚠️ QUAN TRỌNG: CHỈ lấy từ Order DB, KHÔNG lấy từ request
                    ToWardCode = order.GhnWardCode,
                    ToDistrictId = order.GhnDistrictId,
                    
                    // COD
                    CodAmount = request.CodAmount ?? (int)order.TotalAmount,
                    Content = $"Đơn hàng giày {order.OrderCode}",
                    
                    // Kích thước & trọng lượng
                    Weight = request.Weight ?? 1000,
                    Length = request.Length ?? 20,
                    Width = request.Width ?? 20,
                    Height = request.Height ?? 10,
                    
                    // Station và service
                    PickStationId = request.PickStationId,
                    DeliverStationId = null,
                    InsuranceValue = request.InsuranceValue ?? (int)(order.TotalAmount * 0.5m), // Bảo hiểm 50% giá trị đơn
                    ServiceId = request.ServiceId ?? 0,
                    ServiceTypeId = request.ServiceTypeId ?? 2,
                    Coupon = request.Coupon,
                    PickShift = request.PickShift ?? new List<int> { 2 }, // Shift 2 = Chiều
                    
                    // Danh sách sản phẩm với đầy đủ thông tin
                    Items = order.OrderDetails.Select(od => new GhnOrderItem
                    {
                        Name = od.Variant?.Product?.Name ?? "Sản phẩm",
                        Code = $"SKU{od.VariantID}",
                        Quantity = od.Quantity,
                        Price = (int)(od.Variant?.SellingPrice ?? 0),
                        Length = 30, // Chiều dài giày cm
                        Width = 20,  // Chiều rộng giày cm
                        Height = 12, // Chiều cao hộp giày cm
                        Weight = 800, // Trọng lượng 1 đôi giày gram
                        Category = new GhnItemCategory
                        {
                            Level1 = "Giày dép"
                        }
                    }).ToList()
                };

                // Validate địa chỉ trước khi gửi
                if (string.IsNullOrWhiteSpace(payload.ToAddress) || 
                    payload.ToWardCode == null || 
                    payload.ToDistrictId == null)
                {
                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = $"❌ Địa chỉ giao hàng chưa đầy đủ!\n\n" +
                                 $"📍 ToAddress: '{payload.ToAddress}'\n" +
                                 $"🏘️ ToWardCode: '{payload.ToWardCode}'\n" +
                                 $"🏙️ ToDistrictId: '{payload.ToDistrictId}'\n\n" +
                                 $"💡 Vui lòng:\n" +
                                 $"1. Gọi GET /api/shipping/provinces để lấy danh sách tỉnh\n" +
                                 $"2. Gọi GET /api/shipping/districts/{{provinceId}} để lấy quận\n" +
                                 $"3. Gọi GET /api/shipping/wards/{{districtId}} để lấy phường\n" +
                                 $"4. Truyền đầy đủ ToAddress, ToWardCode, ToDistrictId khi tạo đơn GHN"
                    };
                }

                // IMPORTANT: Validate Ward thuộc District đã chọn
                _logger.LogWarning("⚠️ Validating Ward {WardCode} belongs to District {DistrictId}", 
                    payload.ToWardCode, payload.ToDistrictId);

                // Log thông tin Order hiện tại
                _logger.LogInformation("📦 Order Info - OrderID: {OrderId}, OrderCode: {OrderCode}", 
                    request.OrderId, order.OrderCode);
                _logger.LogInformation("📍 Order Address - GhnProvinceId: {ProvinceId}, GhnDistrictId: {DistrictId}, GhnWardCode: {WardCode}", 
                    order.GhnProvinceId, order.GhnDistrictId, order.GhnWardCode);
                _logger.LogInformation("📍 Order FullAddress: {Address}", order.GhnFullAddress ?? order.Address);

                var wardsInDistrict = await GetWardsAsync(payload.ToDistrictId.Value);
                if (wardsInDistrict?.Data == null || !wardsInDistrict.Data.Any(w => w.WardCode == payload.ToWardCode))
                {
                    // Log danh sách Wards hợp lệ trong District này
                    if (wardsInDistrict?.Data != null)
                    {
                        _logger.LogError("❌ Available WardCodes in District {DistrictId}: {WardCodes}", 
                            payload.ToDistrictId, 
                            string.Join(", ", wardsInDistrict.Data.Take(5).Select(w => $"{w.WardCode}({w.WardName})")));
                    }

                    return new CreateGhnOrderResult
                    {
                        Success = false,
                        Message = $"❌ Địa chỉ không hợp lệ!\n\n" +
                                 $"🏘️ WardCode '{payload.ToWardCode}' KHÔNG thuộc DistrictId '{payload.ToDistrictId}'!\n\n" +
                                 $"📍 Địa chỉ hiện tại trong Order:\n" +
                                 $"   - GhnProvinceId: {order.GhnProvinceId}\n" +
                                 $"   - GhnDistrictId: {order.GhnDistrictId}\n" +
                                 $"   - GhnWardCode: {order.GhnWardCode}\n" +
                                 $"   - ToAddress: {payload.ToAddress}\n\n" +
                                 $"💡 Vui lòng:\n" +
                                 $"1. Kiểm tra lại địa chỉ đã chọn khi đặt hàng\n" +
                                 $"2. Đảm bảo Province/District/Ward được chọn từ cùng 1 tỉnh\n" +
                                 $"3. Hủy Order này và tạo lại với địa chỉ đúng\n" +
                                 $"4. Hoặc cập nhật lại GhnProvinceId/GhnDistrictId/GhnWardCode trong DB"
                    };
                }

                _logger.LogInformation("✅ Address validation passed - Ward {WardCode} belongs to District {DistrictId}", 
                    payload.ToWardCode, payload.ToDistrictId);

                // 3. Log request
                var requestJson = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("GHN Create Order Request for OrderID {OrderId}:\n{Request}", 
                    request.OrderId, requestJson);
                
                // Log full URL
                var fullUrl = "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/create";
                _logger.LogInformation("🌐 Full GHN URL: {Url}", fullUrl);
                _logger.LogInformation("🔑 Token: {Token}, ShopId: {ShopId}", 
                    _ghnOptions.Token?.Substring(0, 10) + "...", 
                    _ghnOptions.ShopId);

                // 4. Gọi GHN API trực tiếp với full URL
                var response = await _httpClient.PostAsJsonAsync(fullUrl, payload);
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
                order.GhnStatus = "ready_to_pick"; // ✅ Status mặc định khi tạo đơn GHN
                order.GhnFee = ghnResponse.Data.TotalFee;
                order.GhnCreatedAt = DateTime.Now;
                order.GhnUpdatedAt = DateTime.Now;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                _logger.LogInformation("✅ Saved GhnOrderCode='{Code}', GhnStatus='{Status}' to database", 
                    order.GhnOrderCode, order.GhnStatus);

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

                // ✅ Sửa endpoint đầy đủ
                var request = new HttpRequestMessage(HttpMethod.Post, 
                    "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/detail")
                {
                    Content = JsonContent.Create(payload)
                };
                
                // Clear any existing Token header và add mới
                request.Headers.Remove("Token");
                request.Headers.TryAddWithoutValidation("Token", _ghnOptions.Token);
                
                _logger.LogInformation("📤 GetOrderDetail Request - URL: {Url}, OrderCode: {OrderCode}", 
                    request.RequestUri, ghnOrderCode);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                
                _logger.LogInformation("📥 GetOrderDetail Response - Status: {Status}, Body: {Body}", 
                    response.StatusCode, responseContent);

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

                if (order == null)
                {
                    _logger.LogWarning("Order {OrderId} not found in database", orderId);
                    return null;
                }

                // Nếu có GhnOrderCode, lấy thêm thông tin realtime từ GHN
                if (!string.IsNullOrEmpty(order.GhnOrderCode))
                {
                    try
                    {
                        var ghnDetail = await GetOrderDetailAsync(order.GhnOrderCode);
                        if (ghnDetail != null)
                        {
                            // Cập nhật thông tin từ GHN vào response
                            order.GhnStatus = ghnDetail.Status ?? order.GhnStatus;
                            order.GhnStatusText = ghnDetail.StatusText ?? GetStatusText(ghnDetail.Status);
                            order.GhnFee = ghnDetail.TotalFee ?? order.GhnFee;
                            order.CodCollected = ghnDetail.IsCodCollected;
                            order.ExpectedDeliveryTime = ghnDetail.ExpectedDeliveryTime ?? ghnDetail.Leadtime;
                            order.LastUpdated = ghnDetail.UpdatedDate ?? order.LastUpdated;
                            
                            // Cập nhật vào DB nếu có thay đổi
                            var dbOrder = await _context.Orders.FindAsync(orderId);
                            if (dbOrder != null)
                            {
                                dbOrder.GhnStatus = ghnDetail.Status;
                                dbOrder.GhnFee = ghnDetail.TotalFee;
                                dbOrder.CodCollected = ghnDetail.IsCodCollected;
                                dbOrder.GhnUpdatedAt = DateTime.Now;
                                await _context.SaveChangesAsync();
                                _logger.LogInformation("✅ Updated Order {OrderId} with latest GHN status: {Status}", 
                                    orderId, ghnDetail.Status);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to get realtime GHN status for order {OrderId}, using DB data", orderId);
                        // Không throw, vẫn trả về data từ DB
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
        
        /// <summary>
        /// Map GHN status code sang text tiếng Việt
        /// </summary>
        private string GetStatusText(string? status) => status?.ToLower() switch
        {
            "ready_to_pick" => "Chờ lấy hàng",
            "picking" => "Đang lấy hàng",
            "picked" => "Đã lấy hàng",
            "storing" => "Đang lưu kho",
            "transporting" => "Đang vận chuyển",
            "sorting" => "Đang phân loại",
            "delivering" => "Đang giao hàng",
            "delivered" => "Đã giao hàng",
            "return" => "Đang hoàn trả",
            "returned" => "Đã hoàn trả",
            "exception" => "Giao hàng thất bại",
            "damage" => "Hàng hư hỏng",
            "lost" => "Thất lạc",
            "cancel" => "Đã hủy",
            _ => status ?? "Chưa xác định"
        };

        /// <summary>
        /// Cập nhật thông tin đơn hàng GHN (note)
        /// </summary>
        public async Task<bool> UpdateOrderAsync(string orderCode, string note)
        {
            try
            {
                var payload = new
                {
                    order_code = orderCode,
                    note = note
                };

                _logger.LogInformation("Updating GHN order: {OrderCode}", orderCode);

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/update", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN Update Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return false;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<object>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Code == 200;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating GHN order: {OrderCode}", orderCode);
                return false;
            }
        }

        /// <summary>
        /// Hủy đơn hàng GHN
        /// </summary>
        public async Task<bool> CancelOrderAsync(List<string> orderCodes)
        {
            try
            {
                var payload = new { order_codes = orderCodes };

                _logger.LogInformation("Cancelling GHN orders: {OrderCodes}", string.Join(", ", orderCodes));

                var response = await _httpClient.PostAsJsonAsync("/v2/switch-status/cancel", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN Cancel Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return false;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<object>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Code == 200;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling GHN orders");
                return false;
            }
        }

        /// <summary>
        /// Chuyển đơn về trạng thái trả hàng
        /// </summary>
        public async Task<bool> ReturnOrderAsync(List<string> orderCodes)
        {
            try
            {
                var payload = new { order_codes = orderCodes };

                _logger.LogInformation("Returning GHN orders: {OrderCodes}", string.Join(", ", orderCodes));

                var response = await _httpClient.PostAsJsonAsync("/v2/switch-status/return", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN Return Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return false;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<object>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Code == 200;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error returning GHN orders");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật số tiền COD
        /// </summary>
        public async Task<bool> UpdateCODAsync(string orderCode, int codAmount)
        {
            try
            {
                var payload = new
                {
                    order_code = orderCode,
                    cod_amount = codAmount
                };

                _logger.LogInformation("Updating COD for order: {OrderCode} to {CodAmount}", orderCode, codAmount);

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/updateCOD", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN UpdateCOD Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return false;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<object>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Code == 200;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating COD for order: {OrderCode}", orderCode);
                return false;
            }
        }

        /// <summary>
        /// Lấy thời gian dự kiến giao hàng
        /// </summary>
        public async Task<DateTime?> GetLeadTimeAsync(int fromDistrictId, string fromWardCode, int toDistrictId, string toWardCode, int serviceId)
        {
            try
            {
                var payload = new
                {
                    from_district_id = fromDistrictId,
                    from_ward_code = fromWardCode,
                    to_district_id = toDistrictId,
                    to_ward_code = toWardCode,
                    service_id = serviceId
                };

                _logger.LogInformation("Getting lead time from GHN");

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/leadtime", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN LeadTime Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<GhnLeadTimeResponse>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (ghnResponse?.Data != null)
                {
                    // Convert Unix timestamp to DateTime
                    var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ghnResponse.Data.OrderDate);
                    return dateTimeOffset.DateTime.AddSeconds(ghnResponse.Data.LeadTime);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting lead time");
                return null;
            }
        }

        /// <summary>
        /// Preview đơn hàng trước khi tạo
        /// </summary>
        public async Task<GhnOrderPreviewResponse?> PreviewOrderAsync(GhnCreateOrderPayload payload)
        {
            try
            {
                _logger.LogInformation("Previewing GHN order");

                var response = await _httpClient.PostAsJsonAsync("/v2/shipping-order/preview", payload);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN Preview Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<GhnOrderPreviewResponse>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ghnResponse?.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error previewing order");
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Shop từ GHN - Dùng để debug/test
        /// </summary>
        public async Task<string> GetAllShopsAsync()
        {
            try
            {
                _logger.LogInformation("Getting all shops from GHN");

                var response = await _httpClient.PostAsync("/v2/shop/all", null);
                var responseContent = await response.Content.ReadAsStringAsync();

                _logger.LogInformation("GHN Shops Response: {Response}", responseContent);

                return responseContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting shops");
                return $"Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Lấy danh sách tỉnh/thành phố từ GHN
        /// </summary>
        public async Task<GhnProvinceResponse?> GetProvincesAsync()
        {
            try
            {
                _logger.LogInformation("Getting provinces from GHN");
                _logger.LogInformation("🔑 Using Token: {Token}", _ghnOptions.Token);

                // Tạo request message với token header
                var request = new HttpRequestMessage(HttpMethod.Get, 
                    "https://dev-online-gateway.ghn.vn/shiip/public-api/master-data/province");
                
                // Clear any existing Token header và add mới
                request.Headers.Remove("Token");
                request.Headers.TryAddWithoutValidation("Token", _ghnOptions.Token);
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

                _logger.LogInformation("📤 Request Headers: {Headers}", 
                    string.Join(", ", request.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}")));

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                _logger.LogInformation("📥 Response Status: {StatusCode}", response.StatusCode);
                _logger.LogInformation("📥 Response Body: {Response}", responseContent);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN GetProvinces Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<List<GhnProvince>>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new GhnProvinceResponse { Data = ghnResponse?.Data };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting provinces");
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách quận/huyện từ GHN
        /// </summary>
        public async Task<GhnDistrictResponse?> GetDistrictsAsync(int provinceId)
        {
            try
            {
                _logger.LogInformation("Getting districts for province: {ProvinceId}", provinceId);

                var payload = new { province_id = provinceId };
                
                // Tạo request message với token header
                var request = new HttpRequestMessage(HttpMethod.Post, 
                    "https://dev-online-gateway.ghn.vn/shiip/public-api/master-data/district")
                {
                    Content = JsonContent.Create(payload)
                };
                
                // Clear any existing Token header và add mới
                request.Headers.Remove("Token");
                request.Headers.TryAddWithoutValidation("Token", _ghnOptions.Token);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN GetDistricts Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<List<GhnDistrict>>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new GhnDistrictResponse { Data = ghnResponse?.Data };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting districts");
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách phường/xã từ GHN
        /// </summary>
        public async Task<GhnWardResponse?> GetWardsAsync(int districtId)
        {
            try
            {
                _logger.LogInformation("Getting wards for district: {DistrictId}", districtId);

                var payload = new { district_id = districtId };
                
                // Tạo request message với token header
                var request = new HttpRequestMessage(HttpMethod.Post, 
                    "https://dev-online-gateway.ghn.vn/shiip/public-api/master-data/ward")
                {
                    Content = JsonContent.Create(payload)
                };
                
                // Clear any existing Token header và add mới
                request.Headers.Remove("Token");
                request.Headers.TryAddWithoutValidation("Token", _ghnOptions.Token);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GHN GetWards Error: {StatusCode} - {Response}", 
                        response.StatusCode, responseContent);
                    return null;
                }

                var ghnResponse = JsonSerializer.Deserialize<GhnApiResponse<List<GhnWard>>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new GhnWardResponse { Data = ghnResponse?.Data };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting wards");
                return null;
            }
        }
    }
}
