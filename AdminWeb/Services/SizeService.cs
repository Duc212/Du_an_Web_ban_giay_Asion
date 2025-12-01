using AdminWeb.Models;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class SizeService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7134/api/Size";

        public SizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SizeDTO>> GetAllSizesAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<SizeDTO>>>("api/Size");
                return response?.Data ?? new List<SizeDTO>();
                }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting sizes: {ex.Message}");
                return new List<SizeDTO>();
            }
        }

        public async Task<SizeDTO?> GetSizeByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<SizeDTO>>($"api/Size/{id}");
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting size: {ex.Message}");
                return null;
            }
        }

        public async Task<ApiResponse<SizeDTO>> CreateSizeAsync(CreateSizeDTO size)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Size", size);
                return await response.Content.ReadFromJsonAsync<ApiResponse<SizeDTO>>() 
                    ?? new ApiResponse<SizeDTO> { Success = false, Message = "Failed to create size" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<SizeDTO> 
                { 
                    Success = false, 
                    Message = $"Error creating size: {ex.Message}" 
                };
            }
        }

        public async Task<ApiResponse<SizeDTO>> UpdateSizeAsync(int id, UpdateSizeDTO size)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Size/{id}", size);
                return await response.Content.ReadFromJsonAsync<ApiResponse<SizeDTO>>() 
                    ?? new ApiResponse<SizeDTO> { Success = false, Message = "Failed to update size" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<SizeDTO> 
                { 
                    Success = false, 
                    Message = $"Error updating size: {ex.Message}" 
                };
            }
        }

        public async Task<ApiResponse<bool>> DeleteSizeAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Size/{id}");
                return await response.Content.ReadFromJsonAsync<ApiResponse<bool>>() 
                    ?? new ApiResponse<bool> { Success = false, Message = "Failed to delete size" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool> 
                { 
                    Success = false, 
                    Message = $"Error deleting size: {ex.Message}" 
                };
            }
        }
    }
}
