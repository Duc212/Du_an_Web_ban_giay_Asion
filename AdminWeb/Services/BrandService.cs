using DAL.DTOs.Brands.Req;
using DAL.DTOs.Brands.Res;
using DAL.Entities;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class BrandService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7134/api/ProductLanding";

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommonPagination<GetListBrandRes>> GetAllBrandsAsync(int currentPage = 1, int recordPerPage = 10)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CommonPagination<GetListBrandRes>>($"{BaseUrl}/GetBrandAll?currentPage={currentPage}&recordPerPage={recordPerPage}");
                return response ?? new CommonPagination<GetListBrandRes> { Data = new List<GetListBrandRes>() };
            }
            catch
            {
                return new CommonPagination<GetListBrandRes> { Data = new List<GetListBrandRes>() };
            }
        }

        public async Task<GetListBrandRes?> GetBrandByIdAsync(int brandId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CommonResponse<GetListBrandRes>>($"{BaseUrl}/GetBrandById?brandId={brandId}");
                return response?.Data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool success, string message)> CreateBrandAsync(AddBrandReq request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/AddBrand", request);
                var result = await response.Content.ReadFromJsonAsync<CommonResponse<GetListBrandRes>>();
                return (result?.Success ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> UpdateBrandAsync(UpdateBrandReq request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/UpdateBrand", request);
                var result = await response.Content.ReadFromJsonAsync<CommonResponse<GetListBrandRes>>();
                return (result?.Success ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> RemoveBrandAsync(int brandId)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RemoveBrand", new RemoveBrandReq { BrandId = brandId });
                var result = await response.Content.ReadFromJsonAsync<CommonResponse<bool>>();
                return (result?.Success ?? false, result?.Message ?? "Lỗi không xác định");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // Added for dropdown in Products.razor
        public async Task<CommonResponse<List<AdminWeb.Models.BrandDto>>> GetListBrandAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CommonPagination<GetListBrandRes>>($"{BaseUrl}/GetBrandAll?currentPage=1&recordPerPage=1000");
                if (response?.Data != null)
                {
                    var list = response.Data.Select(x => new AdminWeb.Models.BrandDto
                    {
                        BrandID = x.BrandId,
                        BrandName = x.BrandName
                    }).ToList();
                    return new CommonResponse<List<AdminWeb.Models.BrandDto>> { Success = true, Data = list };
                }
            }
            catch { }
            
            return new CommonResponse<List<AdminWeb.Models.BrandDto>> { Success = false, Data = new List<AdminWeb.Models.BrandDto>() };
        }
    }
}
