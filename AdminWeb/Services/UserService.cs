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

        public async Task<(bool Success, string Message)> AddUserAsync(AddUserRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Auth/AddUser", request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    return (result?.Success ?? true, result?.Message ?? "Thêm người dùng thành công");
                }
                
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Lỗi: {response.StatusCode} - {errorContent}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<GetRoleListResponse> GetListRoleAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/Auth/GetListRole");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetRoleListResponse>() 
                        ?? new GetRoleListResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetRoleListResponse { Success = false, Message = "Không thể tải danh sách vai trò" };
        }

        public async Task<GetUserDetailRes?> GetUserDetailAsync(int userId)
        {
            try
            {
                var response = await _http.GetAsync($"api/Auth/GetUserDetail/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<UserDetailResponse>();
                    return result?.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user detail: {ex.Message}");
            }

            return null;
        }

        public async Task<(bool Success, string Message)> UpdateUserAsync(UpdateUserRequest request)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("api/Auth/UpdateUser", request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    return (result?.Success ?? true, result?.Message ?? "Cập nhật người dùng thành công");
                }
                
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Lỗi: {response.StatusCode} - {errorContent}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserReq request)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("api/Auth/UpdateUser", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        private class ApiResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
        }

        private class UserDetailResponse
        {
            public int Status { get; set; }
            public string Message { get; set; } = string.Empty;
            public GetUserDetailRes? Data { get; set; }
        }
    }
}
