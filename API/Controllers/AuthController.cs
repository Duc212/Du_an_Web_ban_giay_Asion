using BUS.Services.Interfaces;
using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
