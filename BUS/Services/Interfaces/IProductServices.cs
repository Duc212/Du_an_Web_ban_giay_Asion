using DAL.DTOs.Products.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IProductServices 
    {
        Task<CommonPagination<GetProductRes>> GetProductLangding(int CurrentPage, int RecordPerPage);
    }
}
