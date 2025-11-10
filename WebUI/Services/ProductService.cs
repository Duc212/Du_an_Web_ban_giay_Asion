using System.Text.Json;
using WebUI.Models;
using WebUI.Services.Interfaces;
using WebUI.Constants;

namespace WebUI.Services
{
    /// <summary>
    /// Service để quản lý dữ liệu sản phẩm thông qua API
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;
        private string? _apiBaseUrl;

        public ProductService(HttpClient httpClient, ConfigurationService configService)
        {
            _httpClient = httpClient;
            _configService = configService;
            InitializeApiBaseUrl();
        }

        private async void InitializeApiBaseUrl()
        {
            try
            {
                _apiBaseUrl = await _configService.GetApiBaseUrlAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing API base URL: {ex.Message}");
            }
        }

        private async Task<string> GetApiBaseUrl()
        {
            if (string.IsNullOrEmpty(_apiBaseUrl))
            {
                _apiBaseUrl = await _configService.GetApiBaseUrlAsync();
            }
            return _apiBaseUrl;
        }

        public async Task<List<Product>> GetAllProductsAsync(int? categoryId = null, int currentPage = 1, int recordPerPage = 12)
        {
            try
            {
                var apiBaseUrl = await GetApiBaseUrl();
                Console.WriteLine($"[ProductService] API Base URL: {apiBaseUrl}");
                
                var url = $"{apiBaseUrl}/api/ProductLanding/GetListProduct?currentPage={currentPage}&recordPerPage={recordPerPage}";
                if (categoryId.HasValue)
                {
                    url += $"&categoryId={categoryId}";
                }
                
                Console.WriteLine($"[ProductService] Calling API: {url}");
                var response = await _httpClient.GetAsync(url);
                Console.WriteLine($"[ProductService] API Response Status: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ProductApiResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return apiResponse?.Data ?? new List<Product>();
                }
                return new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling API: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                // Tạm thời sử dụng GetAllProducts và filter theo id
                // Sau này có thể thay bằng API riêng để get product by id
                var products = await GetAllProductsAsync();
                return products.FirstOrDefault(p => p.Id == id) ?? new Product();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting product by id: {ex.Message}");
                return new Product();
            }
        }
   public async Task<CommonPagination<Product>> GetProductShopAsync(int? categoryId, string? keyword, int? sortType, int? sortPrice, int currentPage, int recordPerPage)
        {
            try
            {
                var apiBaseUrl = await GetApiBaseUrl();
                var url = $"{apiBaseUrl}{ApiEndpoints.ProductShop}?" +
                          $"CategoryId={(categoryId.HasValue ? categoryId.Value : -1)}" +
                          $"&Keyword={keyword ?? ""}" +
                          $"&SortType={(sortType.HasValue ? sortType.Value : 1)}" +
                          $"&SortPrice={(sortPrice.HasValue ? sortPrice.Value : 1)}" +
                          $"&CurrentPage={currentPage}" +
                          $"&RecordPerPage={recordPerPage}";
                Console.WriteLine($"[ProductService] Calling API: {url}");
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<CommonPagination<Product>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse ?? new CommonPagination<Product>();
                }
                return new CommonPagination<Product> { Success = false, Message = $"API returned status code: {response.StatusCode}" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling GetProductShop API: {ex.Message}");
                return new CommonPagination<Product> { Success = false, Message = "Error occurred while fetching products" };
            }
        }
        public async Task<List<Product>> GetRelatedProductsAsync(int productId, int count = 6)
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                var currentProduct = allProducts.FirstOrDefault(p => p.Id == productId);
                
                if (currentProduct == null)
                    return new List<Product>();

                // Lấy các sản phẩm cùng danh mục hoặc có giá tương tự
                var related = allProducts
                    .Where(p => p.Id != productId && 
                           (p.CategoryId == currentProduct.CategoryId || 
                            Math.Abs(p.Price - currentProduct.Price) <= currentProduct.Price * 0.2m))
                    .OrderBy(x => Guid.NewGuid())
                    .Take(count)
                    .ToList();

                return related;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting related products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await GetAllProductsAsync(categoryId);
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return allProducts;

                var term = searchTerm.ToLower();
                return allProducts
                    .Where(p => p.Name.ToLower().Contains(term) || 
                               p.Description.ToLower().Contains(term) ||
                               p.Brand.ToLower().Contains(term))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetTrendingProductsAsync(int count = 6)
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                // Lấy các sản phẩm có rating cao nhất
                return allProducts
                    .OrderByDescending(p => p.Rating)
                    .ThenByDescending(p => p.ReviewCount)
                    .Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting trending products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetFeaturedProductsAsync(int count = 6)
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                // Lấy các sản phẩm có nhiều review nhất
                return allProducts
                    .OrderByDescending(p => p.ReviewCount)
                    .ThenByDescending(p => p.Rating)
                    .Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting featured products: {ex.Message}");
                return new List<Product>();
            }
        }

        // New methods for pagination support
        public async Task<List<Product>> GetAllTrendingProductsAsync()
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                // Lấy tất cả sản phẩm trending (có badge hoặc rating cao)
                return allProducts
                    .Where(p => p.HasBadge || p.Rating >= 4.0f)
                    .OrderByDescending(p => p.Rating)
                    .ThenByDescending(p => p.ReviewCount)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all trending products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetAllFeaturedProductsAsync()
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                // Lấy tất cả sản phẩm nổi bật (có nhiều review hoặc có badge)
                return allProducts
                    .Where(p => p.ReviewCount > 50 || p.HasBadge)
                    .OrderByDescending(p => p.ReviewCount)
                    .ThenByDescending(p => p.Rating)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all featured products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetNewProductsAsync()
        {
            try
            {
                var allProducts = await GetAllProductsAsync();
                
                // Lấy các sản phẩm mới (có badge NEW hoặc được thêm gần đây)
                return allProducts
                    .Where(p => p.Badge == "NEW" || p.Badge == "HOT" || p.Id >= 10)
                    .OrderByDescending(p => p.Id)
                    .ThenByDescending(p => p.Rating)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting new products: {ex.Message}");
                return new List<Product>();
            }
        }

        /// <summary>
        /// Lấy sản phẩm với phân trang từ API
        /// </summary>
        public async Task<ProductApiResponse> GetProductsWithPaginationAsync(int currentPage = 1, int recordPerPage = 12)
        {
            try
            {
                var apiBaseUrl = await GetApiBaseUrl();
                var response = await _httpClient.GetAsync($"{apiBaseUrl}/api/ProductLanding/GetListProduct?currentPage={currentPage}&recordPerPage={recordPerPage}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ProductApiResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return apiResponse ?? new ProductApiResponse();
                }
                return new ProductApiResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling API with pagination: {ex.Message}");
                return new ProductApiResponse();
            }
        }

        public async Task<CommonResponse<List<Category>>> GetCategoriesAsync()
        {
            try
            {
                var apiBaseUrl = await GetApiBaseUrl();
                var response = await _httpClient.GetAsync($"{apiBaseUrl}{ApiEndpoints.ProductCategories}");
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<CommonResponse<List<Category>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse ?? new CommonResponse<List<Category>>();
                }
                
                return new CommonResponse<List<Category>> 
                { 
                    Success = false, 
                    Message = $"API returned status code: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return new CommonResponse<List<Category>> 
                { 
                    Success = false, 
                    Message = "Error occurred while fetching categories" 
                };
            }
        }

        public async Task<CommonResponse<List<GetListBrand>>> GetListBrandAsync()
        {
             try
            {
                var apiBaseUrl = await GetApiBaseUrl();
                var response = await _httpClient.GetAsync($"{apiBaseUrl}{ApiEndpoints.GetLisBrand}");
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<CommonResponse<List<GetListBrand>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse ?? new CommonResponse<List<GetListBrand>>();
                }
                
                return new CommonResponse<List<GetListBrand>> 
                { 
                    Success = false, 
                    Message = $"API returned status code: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return new CommonResponse<List<GetListBrand>> 
                { 
                    Success = false, 
                    Message = "Error occurred while fetching categories" 
                };
            }
        }
    }
}
