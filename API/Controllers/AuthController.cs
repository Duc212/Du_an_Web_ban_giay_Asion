using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.DTOs.Users.Req;
using DAL.DTOs.Users.Res;
using DAL.Entities;
using Helper.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<CommonResponse<LoginRes>> Login(LoginReq req)
        {
            return await _authServices.Login(req);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<CommonResponse<string>> Register(RegisterReq req)
        {
            return await _authServices.Register(req);
        }

        [HttpPost]
        [Route("Verify")]
        public async Task<CommonResponse<bool>> VerifyRegister(VerifyRegisterReq req)
        {
            return await _authServices.VerifyRegister(req);
        }

        [HttpPost]
        [Route("GoogleLogin")]
        public async Task<CommonResponse<LoginRes>> GoogleLogin(GoogleLoginReq req)
        {
            return await _authServices.GoogleLogin(req);
        }
        [HttpGet]
        [Route("GetUserWithAddress")]
        [BAuthorize]
        public async Task<CommonResponse<UserWithAddressRes>> GetUserWithAddress()
        {
            var userId = HttpContextHelper.GetUserId();
            return await _authServices.GetUserWithAddress(userId);
        }

        [HttpPost]
        [Route("AddUser")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddUser(AddUserReq req)
        {
            return await _authServices.AddUser(req);
        }

        [HttpGet]
        [Route("GetListRole")]
        public async Task<CommonResponse<List<GetListRoleRes>>> GetListRole()
        {
            return await _authServices.GetListRole();
        }

        [HttpPut]
        [Route("UpdateUser")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateUser(UpdateUserReq req)
        {
            return await _authServices.UpdateUser(req);
        }

        [HttpGet]
        [Route("GetUserDetail/{userId}")]
        [BAuthorize]
        public async Task<CommonResponse<GetUserDetailRes>> GetUserDetail(int userId)
        {
            return await _authServices.GetUserDetail(userId);
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteUser(int userId)
        {
            return await _authServices.DeleteUser(userId);
        }

        [HttpPost]
        [Route("StaffLogin")]
        public async Task<CommonResponse<LoginRes>> StaffLogin(LoginReq req)
        {
            return await _authServices.StaffLogin(req);
        }
    }
}
