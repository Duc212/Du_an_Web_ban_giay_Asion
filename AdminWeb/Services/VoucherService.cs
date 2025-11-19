using AdminWeb.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AdminWeb.Services
{
    public class VoucherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7134/api/Voucher";

        public VoucherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetVoucherRes>> GetAllVouchersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CommonVoucherResponse<List<GetVoucherRes>>>($"{_baseUrl}/GetAllVouchers");
                return response?.Data ?? new List<GetVoucherRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching vouchers: {ex.Message}");
                return new List<GetVoucherRes>();
            }
        }

        public async Task<GetVoucherRes?> GetVoucherByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CommonVoucherResponse<GetVoucherRes>>($"{_baseUrl}/GetVoucherById/{id}");
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching voucher: {ex.Message}");
                return null;
            }
        }

        public async Task<(bool Success, string Message)> CreateVoucherAsync(CreateVoucherReq request)
        {
            try
            {
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PostAsync($"{_baseUrl}/CreateVoucher", content);
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<CommonVoucherResponse<string>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (response != null && response.Success)
                {
                    return (true, response.Message);
                }
                return (false, response?.Message ?? "Tạo voucher thất bại");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating voucher: {ex.Message}");
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> UpdateVoucherAsync(UpdateVoucherReq request)
        {
            try
            {
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PutAsync($"{_baseUrl}/UpdateVoucher", content);
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<CommonVoucherResponse<string>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (response != null && response.Success)
                {
                    return (true, response.Message);
                }
                return (false, response?.Message ?? "Cập nhật voucher thất bại");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating voucher: {ex.Message}");
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> DeleteVoucherAsync(int id)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync($"{_baseUrl}/DeleteVoucher/{id}");
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<CommonVoucherResponse<string>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (response != null && response.Success)
                {
                    return (true, response.Message);
                }
                return (false, response?.Message ?? "Xóa voucher thất bại");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting voucher: {ex.Message}");
                return (false, $"Lỗi: {ex.Message}");
            }
        }
    }
}
