using DAL.DTOs.Brands.Req;
using DAL.DTOs.Brands.Res;
using DAL.DTOs.Categories.Req;
using DAL.DTOs.Categories.Res;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Enums;
using System.Threading.Tasks;

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
        Task<CommonResponse<bool>> CreateBrand(AddBrandReq req);
        Task<CommonResponse<bool>> UpdateBrand(UpdateBrandReq req);
        Task<CommonResponse<bool>> RemoveBrand(RemoveBrandReq req);
        Task<CommonPagination<GetALLBrandRes>> GetBrandsPaged(int currentPage, int recordPerPage);
        Task<CommonResponse<bool>> CreateCategory(AddCategoryReq req);
        Task<CommonResponse<bool>> UpdateCategory(UpdateCategoryReq req);
        Task<CommonResponse<bool>> RemoveCategoryReq(RemoveCategoryReq req);
        Task<CommonPagination<GetAllCategoryRes>> GetAllCategory(int currentPage, int recordPerPage);
        Task<CommonResponse<GetGenderRes>> GetGender();
    }
}
