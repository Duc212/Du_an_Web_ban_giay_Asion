using DAL.DTOs.Users.Res;
using DAL.Entities;
namespace BUS.Services.Interfaces
{
    public interface IUserServices
    {
        Task<CommonPagination<GetListUserRes>> GetUsersAsync(int pageIndex = 1, int pageSize = 10, string? keyword = null, int? status = null, string? email = null, string? phone = null);
        
        Task<CommonResponse<bool>> ChangeUserStatusAsync(int userId, int newStatus);
    }
}
