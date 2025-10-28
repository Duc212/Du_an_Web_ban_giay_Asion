using BUS.Services.Interfaces;
using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Helper.Utils;
using Helper.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly ITokenUtils _tokenUtils;
        public AuthServices(IRepositoryAsync<User> userRepository, ITokenUtils tokenUtils)
        {
            _userRepository = userRepository;
            _tokenUtils = tokenUtils;
        }

        public async Task<CommonResponse<LoginRes>> Login(LoginReq req)
        {
            var response = new CommonResponse<LoginRes>();

            if (string.IsNullOrWhiteSpace(req.UserName) || string.IsNullOrWhiteSpace(req.Password))
            {
                response.Success = false;
                response.Message = "Tên đăng nhập hoặc mật khẩu không được để trống.";
                return response;
            }

            var user = await _userRepository.AsQueryable()
                .FirstOrDefaultAsync(x => x.Username == req.UserName);

            if (user == null)
            {
                response.Success = false;
                response.Message = "Tài khoản không tồn tại.";
                return response;
            }

            if (user.Password != req.Password)
            {
                response.Success = false;
                response.Message = "Mật khẩu không đúng.";
                return response;
            }

            var accessToken = _tokenUtils.GenerateToken(user.UserID);
            var refreshToken = _tokenUtils.GenerateRefreshToken(user.UserID);
            response.Success = true;
            response.Message = "Đăng nhập thành công.";
            response.Data = new LoginRes
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return response;
        }

        public async Task<CommonResponse<bool>> Register(RegisterReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                // Kiểm tra username/email trùng
                var existingUser = await _userRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(x => x.Username == req.Username || x.Email == req.Email);

                if (existingUser != null)
                {
                    response.Success = false;
                    response.Message = "Tên đăng nhập hoặc email đã tồn tại!";
                    response.Data = false;
                    return response;
                }
                var encryptedPassword = CryptoHelperUtil.Encrypt(req.Password);

                // Tạo user mới
                var user = new User
                {
                    FullName = req.FullName,
                    Username = req.Username,
                    Password = encryptedPassword,
                    Email = req.Email,
                    Phone = req.Phone,
                    DateOfBirth = req.DateOfBirth,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Đăng ký thành công!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đăng ký thất bại: {ex.Message}";
                response.Data = false;
            }

            return response;
        }
    }
}
