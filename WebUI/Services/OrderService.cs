using System.Net.Http.Json;
using System.Text.Json;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
        Task<Order?> GetOrderByIdAsync(string orderId);
        Task<List<Order>> GetOrderHistoryAsync();
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

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
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
                    // API trả về CommonResponse<bool>
                    var apiResponse = await response.Content.ReadFromJsonAsync<CommonResponse<bool>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (apiResponse != null && apiResponse.Success)
                    {
                        // Lấy OrderID từ response hoặc từ request (nếu API trả về)
                        // Tạm thời dùng timestamp làm OrderNumber
                        return new CreateOrderResponse
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Đặt hàng thành công",
                            Data = new OrderData
                            {
                                OrderId = DateTime.Now.Ticks.ToString(), // Tạm thời, cần lấy từ API response
                                OrderNumber = DateTime.Now.Ticks.ToString(),
                                Status = "pending",
                                TotalAmount = 0, // Sẽ tính từ order details
                                CreatedAt = DateTime.Now
                            }
                        };
                    }
                    else
                    {
                        return new CreateOrderResponse
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Tạo đơn hàng thất bại"
                        };
                    }
                }
                else
                {
                    Console.WriteLine($"[OrderService] CreateOrder failed: {response.StatusCode} - {responseContent}");
                    return new CreateOrderResponse
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
                return new CreateOrderResponse
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}"
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
    }
}
