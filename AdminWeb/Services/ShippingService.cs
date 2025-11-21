using System.Net.Http.Json;
using DAL.DTOs.Orders.Res;

namespace AdminWeb.Services
{
    public class ShippingService
    {
        private readonly HttpClient _httpClient;

        public ShippingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateGhnOrderResult?> CreateGhnOrderAsync(CreateGhnOrderRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/shipping/create-ghn", request);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CreateGhnOrderResult>();
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"GHN Create Order Error: {response.StatusCode} - {errorContent}");
                
                return new CreateGhnOrderResult
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateGhnOrderAsync: {ex.Message}");
                return new CreateGhnOrderResult
                {
                    Success = false,
                    Message = $"Lỗi kết nối: {ex.Message}"
                };
            }
        }

        public async Task<OrderTrackingResponse?> GetOrderTrackingAsync(int orderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/shipping/{orderId}/tracking");
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<OrderTrackingResponse>();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetOrderTrackingAsync: {ex.Message}");
                return null;
            }
        }
    }
}
