using DAL.DTOs.Sizes.Req;
using DAL.DTOs.Sizes.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface ISizeService
    {
        Task<CommonPagination<GetSizeRes>> GetSizesPaged(int pageIndex, int pageSize, string? keyword);
        Task<CommonResponse<GetSizeRes>> GetSizeById(int sizeId);
        Task<CommonResponse<bool>> AddSize(AddSizeReq req);
        Task<CommonResponse<bool>> UpdateSize(UpdateSizeReq req);
        Task<CommonResponse<bool>> DeleteSize(int sizeId);
    }
}
