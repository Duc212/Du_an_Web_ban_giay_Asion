using DAL.DTOs.Products.Req;
using DAL.DTOs.Products.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IProductAdminServices
    {
        // CRUD Product
        Task<CommonPagination<GetProductAdminRes>> GetAllProducts(int pageIndex, int pageSize, string? keyword = null, int? categoryId = null, int? brandId = null, string? sortBy = null, string? sortOrder = null);
        Task<CommonResponse<GetProductDetailAdminRes>> GetProductDetail(int productId);
        Task<CommonResponse<bool>> AddProduct(AddProductReq req);
        Task<CommonResponse<bool>> UpdateProduct(UpdateProductReq req);
        Task<CommonResponse<bool>> DeleteProduct(int productId);

        // Variant Management
        Task<CommonResponse<List<GetVariantRes>>> GetProductVariants(int productId);
        Task<CommonResponse<bool>> AddVariant(AddVariantReq req);
        Task<CommonResponse<bool>> UpdateVariant(UpdateVariantReq req);
        Task<CommonResponse<bool>> DeleteVariant(int variantId);
        Task<CommonResponse<bool>> UpdateStock(UpdateStockReq req);

        // Image Management
        Task<CommonResponse<bool>> AddProductImage(AddProductImageReq req);

        // Support APIs
        Task<CommonResponse<List<GetColorRes>>> GetColors();
        Task<CommonResponse<List<GetSizeRes>>> GetSizes();
        Task<CommonResponse<List<GetGenderRes>>> GetGenders();
        Task<CommonResponse<GetProductStatisticsRes>> GetProductStatistics();
        Task<CommonPagination<GetProductAdminRes>> GetLowStockProducts(int pageIndex, int pageSize, int threshold = 10);
    }
}
