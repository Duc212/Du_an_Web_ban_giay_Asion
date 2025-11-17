using WebUI.Models;

namespace WebUI.Services.Interfaces
{
    /// <summary>
    /// Service interface để quản lý thông tin sản phẩm
    /// Có thể dễ dàng thay thế bằng API call
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Lấy danh sách tất cả sản phẩm với phân trang
        /// </summary>
        Task<List<Product>> GetAllProductsAsync(ProductLandingFilterType? filterType = null, int? categoryId = null, int currentPage = 1, int recordPerPage = 12);

        /// <summary>
        /// Lấy sản phẩm theo ID
        /// </summary>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Lấy các sản phẩm liên quan
        /// </summary>
        Task<List<Product>> GetRelatedProductsAsync(int productId, int count = 6);

        /// <summary>
        /// Lấy sản phẩm theo danh mục (deprecated - use GetAllProductsAsync with categoryId instead)
        /// </summary>
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId) => GetAllProductsAsync(null, categoryId);

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        Task<List<Product>> SearchProductsAsync(string searchTerm);

        /// <summary>
        /// Lấy sản phẩm hot/trending
        /// </summary>
        Task<List<Product>> GetTrendingProductsAsync(int count = 6);

        /// <summary>
        /// Lấy sản phẩm đặc biệt/nổi bật
        /// </summary>
        Task<List<Product>> GetFeaturedProductsAsync(int count = 6);

        /// <summary>
        /// Lấy tất cả sản phẩm trending (cho phân trang)
        /// </summary>
        Task<List<Product>> GetAllTrendingProductsAsync();

        /// <summary>
        /// Lấy tất cả sản phẩm featured (cho phân trang)
        /// </summary>
        Task<List<Product>> GetAllFeaturedProductsAsync();

        /// <summary>
        /// Lấy sản phẩm mới
        /// </summary>
        Task<List<Product>> GetNewProductsAsync();

        /// <summary>
        /// Lấy sản phẩm với phân trang từ API
        /// </summary>
        Task<ProductApiResponse> GetProductsWithPaginationAsync(int currentPage = 1, int recordPerPage = 12);

        Task<CommonResponse<List<Category>>> GetCategoriesAsync();
        Task<CommonPagination<Product>> GetProductShopAsync(int? categoryId, string? keyword, int? sortType, int? sortPrice, int currentPage, int recordPerPage);
        Task<CommonResponse<List<GetListBrand>>> GetListBrandAsync();
        
        Task<CommonResponse<bool>> AddFavoriteProductAsync(int productId);
        Task<CommonResponse<bool>> RemoveFavoriteProductAsync(int productId);
        Task<CommonResponse<List<Product>>> GetFavoriteProductsAsync();
    }
}
