using DAL.DTOs.Products.Res;
using DAL.Entities;
using System.Threading.Tasks;

namespace BUS.Services.Interfaces
{
    public interface IProductServices
    {
        Task<CommonPagination<GetProductRes>> GetProductLanding(int? CategoryId, int CurrentPage, int RecordPerPage);
        Task<CommonResponse<List<GetListCategoryRes>>> GetListCategory();

        Task<CommonPagination<GetProductRes>> GetProductShop(int? categoryId,string? Keyword,int? SortType,int? SortPrice,int CurrentPage, int RecordPerPage);
    }
}
