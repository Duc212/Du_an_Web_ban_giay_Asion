using DAL.DTOs.Categories.Req;
using DAL.DTOs.Categories.Res;
using System.Text.Json;
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
        // Added for dropdown in Products.razor
        public async Task<CommonResponse<List<AdminWeb.Models.CategoryDto>>> GetListCategoryAsync()
        {
            var res = await _http.GetAsync("api/ProductLanding/GetAllCategory?currentPage=1&recordPerPage=1000");
            var result = await res.Content.ReadFromJsonAsync<CommonPagination<DAL.DTOs.Categories.Res.GetAllCategoryRes>>() ?? new CommonPagination<DAL.DTOs.Categories.Res.GetAllCategoryRes>();
            var list = result.Data.Select(x => new AdminWeb.Models.CategoryDto
            {
                CategoryID = x.CategoryID,
                CategoryName = x.Name
            }).ToList();
            return new CommonResponse<List<AdminWeb.Models.CategoryDto>> { Success = true, Data = list };
        }
        // Raw fetch to include fields not present in current DTO (e.g. totalProduct)
        public async Task<(List<AdminWeb.Models.CategoryExtended> Data, int TotalRecords, int TotalPages)> GetAllCategoryExtendedAsync(int currentPage = 1, int recordPerPage = 10)
        {
            var json = await _http.GetStringAsync($"api/ProductLanding/GetAllCategory?currentPage={currentPage}&recordPerPage={recordPerPage}");
            var dataList = new List<AdminWeb.Models.CategoryExtended>();
            int totalRecords = 0, totalPages = 1;
            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                // Metadata (try camelCase then PascalCase)
                if (root.TryGetProperty("totalRecords", out var tr)) totalRecords = tr.GetInt32();
                else if (root.TryGetProperty("TotalRecords", out tr)) totalRecords = tr.GetInt32();
                if (root.TryGetProperty("totalPages", out var tp)) totalPages = tp.GetInt32();
                else if (root.TryGetProperty("TotalPages", out tp)) totalPages = tp.GetInt32();

                // Data array
                JsonElement dataEl;
                if (root.TryGetProperty("data", out dataEl) || root.TryGetProperty("Data", out dataEl))
                {
                    foreach (var el in dataEl.EnumerateArray())
                    {
                        var item = new AdminWeb.Models.CategoryExtended
                        {
                            CategoryID = el.TryGetProperty("categoryID", out var cid) ? cid.GetInt32() : (el.TryGetProperty("CategoryID", out cid) ? cid.GetInt32() : 0),
                            Name = el.TryGetProperty("name", out var nm) ? nm.GetString() ?? string.Empty : (el.TryGetProperty("Name", out nm) ? nm.GetString() ?? string.Empty : string.Empty),
                            Description = el.TryGetProperty("description", out var dsc) ? dsc.GetString() : (el.TryGetProperty("Description", out dsc) ? dsc.GetString() : null),
                            Icon = el.TryGetProperty("icon", out var ic) ? ic.GetString() ?? string.Empty : (el.TryGetProperty("Icon", out ic) ? ic.GetString() ?? string.Empty : string.Empty),
                            TotalProduct = el.TryGetProperty("totalProduct", out var tpEl) ? tpEl.GetInt32() : (el.TryGetProperty("TotalProduct", out tpEl) ? tpEl.GetInt32() : 0)
                        };
                        dataList.Add(item);
                    }
                }
            }
            catch
            {
                // swallow minimal, return whatever parsed
            }
            return (dataList, totalRecords, totalPages);
        }
    }
}
