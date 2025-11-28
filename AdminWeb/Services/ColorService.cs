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

        public async Task<(List<GetColorRes> Data, int TotalRecords)> GetColorsPagedAsync(int pageIndex, int pageSize, string? keyword)
        {
            try
            {
                var query = $"?pageIndex={pageIndex}&pageSize={pageSize}";
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += $"&keyword={keyword}";
                }

                var response = await _httpClient.GetFromJsonAsync<ColorPaginationResponse>($"{BaseUrl}/GetColorsPaged{query}");
                return (response?.Data ?? new List<GetColorRes>(), response?.TotalRecords ?? 0);
            }
            catch
            {
                return (new List<GetColorRes>(), 0);
            }
        }

        public async Task<GetColorRes?> GetColorByIdAsync(int colorId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ColorSingleResponse>($"{BaseUrl}/GetColorById/{colorId}");
                return response?.Data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool success, string message)> AddColorAsync(AddColorReq request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/AddColor", request);
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> UpdateColorAsync(UpdateColorReq request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/UpdateColor", request);
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> DeleteColorAsync(int colorId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/DeleteColor/{colorId}");
                var result = await response.Content.ReadFromJsonAsync<ColorBoolResponse>();
                return (result?.Data ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
