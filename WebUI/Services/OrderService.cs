using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    public interface IOrderService
    {
        Task<CommonResponse<int>> CreateOrderAsync(CreateOrderRequest request);
        Task<Order?> GetOrderByIdAsync(string orderId);
        Task<List<Order>> GetOrderHistoryAsync();
        Task<CommonResponse<bool>> UpdatePaymentStatusAsync(int orderId, PaymentStatus status);
        Task<CommonPagination<GetOrderRes>> GetListOrderByUserAsync(int currentPage, int recordPerPage);
        Task<CommonResponse<bool>> UpdateOrderStatusAsync(int orderId, int status);
    }

    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;
        private readonly IAuthService _authService;

        public OrderService(HttpClient httpClient, ConfigurationService configService, IAuthService authService)
        {
            _httpClient = httpClient;
            _configService = configService;
            _authService = authService;
        }

        public async Task<CommonResponse<int>> CreateOrderAsync(CreateOrderRequest request)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Orders/CreateOrder")
                {
                    Content = JsonContent.Create(request)
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[OrderService] CreateOrder Response: {response.StatusCode}");
                Console.WriteLine($"[OrderService] Response Body: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    // API trả về CommonResponse<int>
                    var apiResponse = await response.Content.ReadFromJsonAsync<CommonResponse<int>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                    return apiResponse ?? new CommonResponse<int> { Success = false, Message = "Không nhận được phản hồi từ API" };
                }
                else
                {
                    Console.WriteLine($"[OrderService] CreateOrder failed: {response.StatusCode} - {responseContent}");
                    return new CommonResponse<int>
                    {
                        Success = false,
                        Message = $"Tạo đơn hàng thất bại: {responseContent}"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Exception in CreateOrderAsync: {ex.Message}");
                Console.WriteLine($"[OrderService] StackTrace: {ex.StackTrace}");
                return new CommonResponse<int>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}",
                    Data = 0
                };
            }
        }

        public async Task<Order?> GetOrderByIdAsync(string orderId)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{apiBaseUrl}/api/Orders/{orderId}");

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Order>();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Exception in GetOrderByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Order>> GetOrderHistoryAsync()
        {
            try
            {
                if (!_authService.IsAuthenticated)
                {
                    return new List<Order>();
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{apiBaseUrl}/api/Orders/history");

                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _authService.CurrentToken!
                );

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<Order>>();
                    return result ?? new List<Order>();
                }

                return new List<Order>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Exception in GetOrderHistoryAsync: {ex.Message}");
                return new List<Order>();
            }
        }

        /// <summary>
        /// Cập nhật trạng thái thanh toán đơn hàng sau khi thanh toán thành công / thất bại.
        /// POST /api/Orders/UpdateStatusPayment { orderId, status }
        /// status: 1 = Paid (giả định), các giá trị khác tùy backend.
        /// </summary>
        public async Task<CommonResponse<bool>> UpdatePaymentStatusAsync(int orderId, PaymentStatus status)
        {
            try
            {
                if (orderId <= 0) 
                {
                    return new CommonResponse<bool> 
                    { 
                        Success = false, 
                        Message = "OrderID không hợp lệ",
                        Data = false
                    };
                }
                
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                // Backend expects OrderId (PascalCase) and Status as PaymentStatus enum value
                var payload = new { OrderId = orderId, Status = status };
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Orders/UpdateStatusPayment")
                {
                    Content = JsonContent.Create(payload)
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[OrderService] UpdatePaymentStatus Response: {response.StatusCode} Body: {body}");
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CommonResponse<bool>>();
                    return result ?? new CommonResponse<bool> 
                    { 
                        Success = true, 
                        Message = "Cập nhật thành công",
                        Data = true
                    };
                }
                else
                {
                    return new CommonResponse<bool> 
                    { 
                        Success = false, 
                        Message = $"API trả về lỗi: {response.StatusCode}",
                        Data = false
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[OrderService] Exception in UpdatePaymentStatusAsync: {ex.Message}");
                return new CommonResponse<bool> 
                { 
                    Success = false, 
                    Message = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

        /// <summary>
        /// Lấy danh sách đơn hàng của user với phân trang
        /// GET /api/Orders/GetListOrderByUser?CurrentPage=1&RecordPerPage=10
        /// Backend trả về nested List<List<GetOrderRes>>, cần flatten
        /// </summary>
        public async Task<CommonPagination<GetOrderRes>> GetListOrderByUserAsync(int currentPage, int recordPerPage)
        {
            try
            {
                if (!_authService.IsAuthenticated)
                {
                    return new CommonPagination<GetOrderRes>
                    {
                        Success = false,
                        Message = "User not authenticated",
                        Data = new List<GetOrderRes>()
                    };
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var url = $"{apiBaseUrl}/api/Orders/GetListOrderByUser?CurrentPage={currentPage}&RecordPerPage={recordPerPage}";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _authService.CurrentToken!
                );

                var response = await _httpClient.SendAsync(httpRequest);
                var body = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Backend trả về List<List<GetOrderRes>> trong data field
                    var nestedResult = JsonSerializer.Deserialize<NestedOrderResponse>(body, 
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (nestedResult?.Success == true && nestedResult.Data != null)
                    {
                        // Flatten nested list
                        var flattenedOrders = nestedResult.Data.SelectMany(list => list).ToList();

                        return new CommonPagination<GetOrderRes>
                        {
                            Success = true,
                            Message = nestedResult.Message,
                            Data = flattenedOrders,
                            TotalRecord = nestedResult.TotalRecord
                        };
                    }
                }

                return new CommonPagination<GetOrderRes>
                {
                    Success = false,
                    Message = $"API returned {response.StatusCode}",
                    Data = new List<GetOrderRes>()
                };
            }
            catch (Exception)
            {
                return new CommonPagination<GetOrderRes>
                {
                    Success = false,
                    Message = "Error loading orders",
                    Data = new List<GetOrderRes>()
                };
            }
        }

        public async Task<CommonResponse<bool>> UpdateOrderStatusAsync(int orderId, int status)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Orders/UpdateStatusOrder")
                {
                    Content = JsonContent.Create(new { OrderID = orderId, Status = status })
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CommonResponse<bool>>();
                    return result ?? new CommonResponse<bool> { Success = false, Message = "Không nhận được phản hồi từ API" };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = $"Cập nhật trạng thái thất bại: {errorContent}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi cập nhật trạng thái: {ex.Message}"
                };
            }
        }

        // Helper class để deserialize nested response structure
        private class NestedOrderResponse
        {
            [JsonPropertyName("success")]
            public bool Success { get; set; }
            
            [JsonPropertyName("message")]
            public string Message { get; set; } = string.Empty;
            
            [JsonPropertyName("data")]
            public List<List<GetOrderRes>> Data { get; set; } = new();
            
            [JsonPropertyName("totalRecord")]
            public int TotalRecord { get; set; }
        }
    }
}
