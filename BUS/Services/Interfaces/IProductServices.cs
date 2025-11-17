using DAL.DTOs.Products.Res;
using DAL.Entities;
using System.Threading.Tasks;
using DAL.Enums;

namespace BUS.Services.Interfaces
{
    public interface IProductServices
    {
        Task<CommonResponse<GetProductRes>> GetProductById(int productId);
        Task<CommonPagination<GetProductRes>> GetProductLanding(int? CategoryId, int CurrentPage, int RecordPerPage, ProductLandingFilterType? filterType = null);
        Task<CommonResponse<List<GetListCategoryRes>>> GetListCategory();

        Task<CommonPagination<GetProductRes>> GetProductShop(int? categoryId,string? Keyword,int? SortType,int? SortPrice,int CurrentPage, int RecordPerPage);
        Task<CommonResponse<List<GetListBrandRes>>> GetListBrand();
        Task<CommonResponse<bool>> AddFavoriteProduct(int userId, int productId);
        Task<CommonResponse<bool>> RemoveFavoriteProduct(int userId, int productId);
        Task<CommonResponse<List<GetProductRes>>> GetFavoriteProducts(int userId);
    }
}
