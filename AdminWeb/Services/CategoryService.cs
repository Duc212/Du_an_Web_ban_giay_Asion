using DAL.DTOs.Categories.Req;
using DAL.DTOs.Categories.Res;
using DAL.Entities;
using System.Net.Http.Json;

namespace AdminWeb.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CommonResponse<bool>> CreateCategoryAsync(AddCategoryReq req)
        {
            var res = await _http.PostAsJsonAsync("api/ProductLanding/AddCategory", req);
            return await res.Content.ReadFromJsonAsync<CommonResponse<bool>>() ?? new CommonResponse<bool>();
        }

        public async Task<CommonResponse<bool>> UpdateCategoryAsync(UpdateCategoryReq req)
        {
            var res = await _http.PostAsJsonAsync("api/ProductLanding/UpdateCategory", req);
            return await res.Content.ReadFromJsonAsync<CommonResponse<bool>>() ?? new CommonResponse<bool>();
        }

        public async Task<CommonResponse<bool>> RemoveCategoryAsync(RemoveCategoryReq req)
        {
            var res = await _http.PostAsJsonAsync("api/ProductLanding/RemoveCategory", req);
            return await res.Content.ReadFromJsonAsync<CommonResponse<bool>>() ?? new CommonResponse<bool>();
        }

        public async Task<CommonPagination<GetAllCategoryRes>> GetAllCategoryAsync(int currentPage = 1, int recordPerPage = 10)
        {
            var res = await _http.GetAsync($"api/ProductLanding/GetAllCategory?currentPage={currentPage}&recordPerPage={recordPerPage}");
            return await res.Content.ReadFromJsonAsync<CommonPagination<GetAllCategoryRes>>() ?? new CommonPagination<GetAllCategoryRes>();
        }
    }
}
