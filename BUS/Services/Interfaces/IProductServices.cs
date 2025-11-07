using DAL.DTOs.Products.Res;
using DAL.Entities;
using System.Threading.Tasks;

namespace BUS.Services.Interfaces
{
    public interface IProductServices
    {
        Task<CommonPagination<GetProductRes>> GetProductLangding(int CurrentPage, int RecordPerPage);
        Task<CommonResponse<List<GetListCategoryRes>>> GetListCategory();

        Task<CommonPagination<GetProductRes>> GetProductLangding(string? Keyword,int? SortType,int? SortPrice,int CurrentPage, int RecordPerPage);
    }
}
