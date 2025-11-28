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

        public async Task<(List<GetSizeRes> Data, int TotalRecords)> GetSizesPagedAsync(int pageIndex, int pageSize, string? keyword)
        {
            try
            {
                var query = $"?pageIndex={pageIndex}&pageSize={pageSize}";
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += $"&keyword={keyword}";
                }

                var response = await _httpClient.GetFromJsonAsync<SizePaginationResponse>($"{BaseUrl}/GetSizesPaged{query}");
                return (response?.Data ?? new List<GetSizeRes>(), response?.TotalRecords ?? 0);
            }
            catch
            {
                return (new List<GetSizeRes>(), 0);
            }
        }

        public async Task<GetSizeRes?> GetSizeByIdAsync(int sizeId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SizeSingleResponse>($"{BaseUrl}/GetSizeById/{sizeId}");
                return response?.Data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool success, string message)> AddSizeAsync(AddSizeReq request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/AddSize", request);
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> UpdateSizeAsync(UpdateSizeReq request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/UpdateSize", request);
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> DeleteSizeAsync(int sizeId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/DeleteSize/{sizeId}");
                var result = await response.Content.ReadFromJsonAsync<SizeBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
