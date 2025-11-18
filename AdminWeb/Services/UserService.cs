using AdminWeb.Models;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        
        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<GetListUserResponse> GetListUserAsync(
            int pageIndex = 1,
            int pageSize = 10,
            string keyword = "",
            int? status = null,
            string email = "",
            string phone = "")
        {
            var query = $"api/Users/GetListUser?pageIndex={pageIndex}&pageSize={pageSize}";
            
            if (!string.IsNullOrWhiteSpace(keyword))
                query += $"&keyword={Uri.EscapeDataString(keyword)}";
            
            if (status.HasValue)
                query += $"&status={status.Value}";
            
            if (!string.IsNullOrWhiteSpace(email))
                query += $"&email={Uri.EscapeDataString(email)}";
            
            if (!string.IsNullOrWhiteSpace(phone))
                query += $"&phone={Uri.EscapeDataString(phone)}";

            try
            {
                var response = await _http.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetListUserResponse>() 
                        ?? new GetListUserResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetListUserResponse { Success = false, Message = "Không thể tải danh sách người dùng" };
        }

        public async Task<(bool Success, string Message)> ChangeUserStatusAsync(int userId, int newStatus)
        {
            try
            {
                var response = await _http.PostAsync(
                    $"api/Users/change-status?userId={userId}&newStatus={newStatus}", 
                    null);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    return (result?.Success ?? true, result?.Message ?? "Thay đổi trạng thái thành công");
                }
                
                return (false, $"Lỗi: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        private class ApiResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
        }
    }
}
