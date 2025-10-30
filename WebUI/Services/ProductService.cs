using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    /// <summary>
    /// Service để quản lý dữ liệu sản phẩm
    /// Hiện tại sử dụng fake data từ ProductDetailData
    /// Có thể dễ dàng thay thế bằng HttpClient để gọi API
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly List<Product> _allProducts;

        public ProductService()
        {
            // Khởi tạo dữ liệu fake từ ProductDetailData
            _allProducts = ProductDetailData.GetAllProducts();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            // Simulate API call delay
            await Task.Delay(100);
            return _allProducts;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            // Simulate API call delay
            await Task.Delay(100);
            return _allProducts.FirstOrDefault(p => p.Id == id) ?? new Product();
        }

        public async Task<List<Product>> GetRelatedProductsAsync(int productId, int count = 6)
        {
            // Simulate API call delay
            await Task.Delay(100);

            var currentProduct = _allProducts.FirstOrDefault(p => p.Id == productId);
            if (currentProduct == null)
                return new List<Product>();

            // Lấy các sản phẩm cùng danh mục hoặc có giá tương tự
            var related = _allProducts
                .Where(p => p.Id != productId && 
                       (p.CategoryId == currentProduct.CategoryId || 
                        Math.Abs(p.Price - currentProduct.Price) <= currentProduct.Price * 0.2m))
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .ToList();

            return related;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            // Simulate API call delay
            await Task.Delay(100);
            return _allProducts.Where(p => p.CategoryId == categoryId).ToList();
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            // Simulate API call delay
            await Task.Delay(100);

            if (string.IsNullOrWhiteSpace(searchTerm))
                return _allProducts;

            var term = searchTerm.ToLower();
            return _allProducts
                .Where(p => p.Name.ToLower().Contains(term) || 
                           p.Description.ToLower().Contains(term) ||
                           p.Brand.ToLower().Contains(term))
                .ToList();
        }

        public async Task<List<Product>> GetTrendingProductsAsync(int count = 6)
        {
            // Simulate API call delay
            await Task.Delay(100);

            // Lấy các sản phẩm có rating cao nhất
            return _allProducts
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.ReviewCount)
                .Take(count)
                .ToList();
        }

        public async Task<List<Product>> GetFeaturedProductsAsync(int count = 6)
        {
            // Simulate API call delay
            await Task.Delay(100);

            // Lấy các sản phẩm có nhiều review nhất
            return _allProducts
                .OrderByDescending(p => p.ReviewCount)
                .ThenByDescending(p => p.Rating)
                .Take(count)
                .ToList();
        }

        // New methods for pagination support
        public async Task<List<Product>> GetAllTrendingProductsAsync()
        {
            // Simulate API call delay
            await Task.Delay(100);

            // Lấy tất cả sản phẩm trending (có badge hoặc rating cao)
            return _allProducts
                .Where(p => p.HasBadge || p.Rating >= 4.0f)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.ReviewCount)
                .ToList();
        }

        public async Task<List<Product>> GetAllFeaturedProductsAsync()
        {
            // Simulate API call delay
            await Task.Delay(100);

            // Lấy tất cả sản phẩm nổi bật (có nhiều review hoặc có badge)
            return _allProducts
                .Where(p => p.ReviewCount > 50 || p.HasBadge)
                .OrderByDescending(p => p.ReviewCount)
                .ThenByDescending(p => p.Rating)
                .ToList();
        }

        public async Task<List<Product>> GetNewProductsAsync()
        {
            // Simulate API call delay
            await Task.Delay(100);

            // Lấy các sản phẩm mới (có badge NEW hoặc được thêm gần đây)
            return _allProducts
                .Where(p => p.Badge == "NEW" || p.Badge == "TRENDING" || p.Id >= 10)
                .OrderByDescending(p => p.Id)
                .ThenByDescending(p => p.Rating)
                .ToList();
        }
    }
}
