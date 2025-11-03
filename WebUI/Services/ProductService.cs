using System.Text.Json;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    /// <summary>
    /// Service để quản lý dữ liệu sản phẩm thông qua API
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;

        public ProductService(HttpClient httpClient, ConfigurationService configService)
        {
            _httpClient = httpClient;
            _configService = configService;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var response = await _httpClient.GetAsync($"{apiBaseUrl}/api/ProductLanding/GetListProduct?currentPage=1&recordPerPage=100");
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
            try
            {
                var allProducts = await GetAllProductsAsync();
                return allProducts.Where(p => p.CategoryId == categoryId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting products by category: {ex.Message}");
                return new List<Product>();
            }
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
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
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
    }
}
