using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<CommonResponse<LoginRes>> Login(LoginReq req);
        Task<CommonResponse<bool>> Register(RegisterReq req);
    }
}
