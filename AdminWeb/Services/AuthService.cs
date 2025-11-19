using AdminWeb.Models;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CommonResponse<LoginRes>> StaffLoginAsync(LoginReq request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Auth/StaffLogin", request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CommonResponse<LoginRes>>();
                    return result ?? new CommonResponse<LoginRes> { Success = false, Message = "Không nhận được dữ liệu" };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new CommonResponse<LoginRes>
                    {
                        Success = false,
                        Message = $"Lỗi: {(int)response.StatusCode} - {errorContent}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new CommonResponse<LoginRes>
                {
                    Success = false,
                    Message = $"Lỗi ngoại lệ: {ex.Message}"
                };
            }
        }
    }
}