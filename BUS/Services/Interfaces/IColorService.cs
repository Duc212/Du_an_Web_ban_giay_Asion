using DAL.DTOs.Colors.Req;
using DAL.DTOs.Colors.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IColorService
    {
        Task<CommonPagination<GetColorRes>> GetColorsPaged(int pageIndex, int pageSize, string? keyword);
        Task<CommonResponse<GetColorRes>> GetColorById(int colorId);
        Task<CommonResponse<bool>> AddColor(AddColorReq req);
        Task<CommonResponse<bool>> UpdateColor(UpdateColorReq req);
        Task<CommonResponse<bool>> DeleteColor(int colorId);
    }
}
