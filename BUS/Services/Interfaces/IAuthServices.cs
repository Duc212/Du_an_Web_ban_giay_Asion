using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<CommonResponse<LoginRes>> Login(LoginReq req);
        Task<CommonResponse<string>> Register(RegisterReq req);
        Task<CommonResponse<bool>> VerifyRegister(VerifyRegisterReq req);
        Task<CommonResponse<bool>> CreateUserFromAdmin(CreateUserReq req);
        Task<CommonResponse<LoginRes>> GoogleLogin(GoogleLoginReq req);
        Task<CommonResponse<UserWithAddressRes>> GetUserWithAddress(int userId);
    }
}
