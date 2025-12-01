using AdminWeb.Models;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class ColorService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7134/api/Color";

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ColorPaginationResponse> GetColorsPagedAsync(int pageIndex, int pageSize, string searchQuery = "")
        {
            try
            {
                var url = $"api/Color/paged?pageIndex={pageIndex}&pageSize={pageSize}";
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    url += $"&search={Uri.EscapeDataString(searchQuery)}";
                }
                
                var response = await _httpClient.GetFromJsonAsync<ColorPaginationResponse>(url);
                return response ?? new ColorPaginationResponse 
                { 
                    Success = false, 
                    Message = "Failed to get colors",
                    Data = new List<GetColorRes>(),
                    TotalRecords = 0
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting colors: {ex.Message}");
                return new ColorPaginationResponse 
                { 
                    Success = false, 
                    Message = $"Error: {ex.Message}",
                    Data = new List<GetColorRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<List<ColorDTO>> GetAllColorsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<ColorDTO>>>("api/Color");
                return response?.Data ?? new List<ColorDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting colors: {ex.Message}");
                return new List<ColorDTO>();
            }
        }

        public async Task<ColorDTO?> GetColorByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<ColorDTO>>($"api/Color/{id}");
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting color: {ex.Message}");
                return null;
            }
        }

        public async Task<(bool success, string message)> AddColorAsync(AddColorReq color)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Color", color);
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to add color");
            }
            catch (Exception ex)
            {
                return (false, $"Error adding color: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> UpdateColorAsync(UpdateColorReq color)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Color/{color.ColorID}", color);
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to update color");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating color: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ColorDTO>> CreateColorAsync(CreateColorDTO color)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Color", color);
                return await response.Content.ReadFromJsonAsync<ApiResponse<ColorDTO>>() 
                    ?? new ApiResponse<ColorDTO> { Success = false, Message = "Failed to create color" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ColorDTO> 
                { 
                    Success = false, 
                    Message = $"Error creating color: {ex.Message}" 
                };
            }
        }

        public async Task<ApiResponse<ColorDTO>> UpdateColorAsync(int id, UpdateColorDTO color)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Color/{id}", color);
                return await response.Content.ReadFromJsonAsync<ApiResponse<ColorDTO>>() 
                    ?? new ApiResponse<ColorDTO> { Success = false, Message = "Failed to update color" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ColorDTO> 
                { 
                    Success = false, 
                    Message = $"Error updating color: {ex.Message}" 
                };
            }
        }

        public async Task<(bool success, string message)> DeleteColorAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Color/{id}");
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to delete color");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting color: {ex.Message}");
            }
        }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
