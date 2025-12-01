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

        public async Task<SizePaginationResponse> GetSizesPagedAsync(int pageIndex, int pageSize, string searchQuery = "")
        {
            try
            {
                var url = $"api/Size/paged?pageIndex={pageIndex}&pageSize={pageSize}";
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    url += $"&search={Uri.EscapeDataString(searchQuery)}";
                }
                
                var response = await _httpClient.GetFromJsonAsync<SizePaginationResponse>(url);
                return response ?? new SizePaginationResponse 
                { 
                    Success = false, 
                    Message = "Failed to get sizes",
                    Data = new List<GetSizeRes>(),
                    TotalRecords = 0
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting sizes: {ex.Message}");
                return new SizePaginationResponse 
                { 
                    Success = false, 
                    Message = $"Error: {ex.Message}",
                    Data = new List<GetSizeRes>(),
                    TotalRecords = 0
                };
            }
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

        public async Task<(bool success, string message)> AddSizeAsync(AddSizeReq size)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Size", size);
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to add size");
            }
            catch (Exception ex)
            {
                return (false, $"Error adding size: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> UpdateSizeAsync(UpdateSizeReq size)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Size/{size.SizeID}", size);
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to update size");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating size: {ex.Message}");
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

        public async Task<(bool success, string message)> DeleteSizeAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Size/{id}");
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                
                if (result != null && result.Success)
                {
                    return (true, result.Message);
                }
                return (false, result?.Message ?? "Failed to delete size");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting size: {ex.Message}");
            }
        }
    }
}
