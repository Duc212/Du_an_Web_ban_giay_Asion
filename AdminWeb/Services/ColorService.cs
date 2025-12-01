using AdminWeb.Models;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class ColorService
    {
        private readonly HttpClient _httpClient;

        public ColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

        public async Task<ApiResponse<bool>> DeleteColorAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Color/{id}");
                return await response.Content.ReadFromJsonAsync<ApiResponse<bool>>() 
                    ?? new ApiResponse<bool> { Success = false, Message = "Failed to delete color" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool> 
                { 
                    Success = false, 
                    Message = $"Error deleting color: {ex.Message}" 
                };
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
