using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.DTOs.Users.Req;
using DAL.DTOs.Users.Res;
using DAL.Entities;

namespace BUS.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<CommonResponse<LoginRes>> Login(LoginReq req);
        Task<CommonResponse<LoginRes>> StaffLogin(LoginReq req); 
        Task<CommonResponse<string>> Register(RegisterReq req);
        Task<CommonResponse<bool>> VerifyRegister(VerifyRegisterReq req);
        Task<CommonResponse<bool>> CreateUserFromAdmin(CreateUserReq req);
        Task<CommonResponse<LoginRes>> GoogleLogin(GoogleLoginReq req);
        Task<CommonResponse<UserWithAddressRes>> GetUserWithAddress(int userId);
        Task<CommonResponse<bool>> AddUser(AddUserReq req);
        Task<CommonResponse<List<GetListRoleRes>>> GetListRole();
        Task<CommonResponse<bool>> UpdateUser(UpdateUserReq req);
        Task<CommonResponse<GetUserDetailRes>> GetUserDetail(int userId);
        Task<CommonResponse<bool>> DeleteUser(int userId);
    }
}
