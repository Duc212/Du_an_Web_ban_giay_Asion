using BUS.Services.Interfaces;
using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.RepositoryAsyns;
using Helper.CacheCore.Interfaces;
using Helper.Utils;
using Helper.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly ITokenUtils _tokenUtils;
        private readonly IMailServices _mailServices;
        private readonly IMemoryCacheSystem _cache;

        public AuthServices(
            IRepositoryAsync<User> userRepository,
            ITokenUtils tokenUtils,
            IMailServices mailServices,
            IMemoryCacheSystem cache)
        {
            _userRepository = userRepository;
            _tokenUtils = tokenUtils;
            _mailServices = mailServices;
            _cache = cache;
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

            if (CryptoHelperUtil.Decrypt(user.Password) != req.Password)
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

        public async Task<CommonResponse<string>> Register(RegisterReq req)
        {
            var response = new CommonResponse<string>();

            try
            {
                var existingUser = await _userRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(x => x.Username == req.Username || x.Email == req.Email);

                if (existingUser != null)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Tên đăng nhập hoặc email đã tồn tại!",
                    };
                }

                var code = new Random().Next(100000, 999999).ToString();

                // nào config email thì mở dòng dưới ra
                //await _mailServices.SendVerificationCodeAsync(req.Email,code); 

                var encryptedPassword = CryptoHelperUtil.Encrypt(req.Password);

                var tempData = new
                {
                    req.FullName,
                    req.Username,
                    Password = encryptedPassword,
                    req.Email,
                    req.Phone,
                    req.DateOfBirth,
                    Code = code
                };

                _cache.AddOrUpdate($"register:{req.Email}", tempData, TimeSpan.FromMinutes(5));

                response.Success = true;
                response.Message = "Đã gửi mã xác nhận đến email của bạn. Vui lòng kiểm tra hộp thư.";
                response.Data = code;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi gửi mã xác nhận: {ex.Message}";
            }

            return response;
        }

        public async Task<CommonResponse<bool>> VerifyRegister(VerifyRegisterReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                if (!_cache.TryGetValue($"register:{req.Email}", out dynamic? cachedData))
                {
                    response.Success = false;
                    response.Message = "Mã xác nhận không tồn tại hoặc đã hết hạn!";
                    response.Data = false;
                    return response;
                }

                if (cachedData.Code != req.Code)
                {
                    response.Success = false;
                    response.Message = "Mã xác nhận không chính xác!";
                    response.Data = false;
                    return response;
                }

                var user = new User
                {
                    FullName = cachedData.FullName,
                    Username = cachedData.Username,
                    Password = cachedData.Password,
                    Email = cachedData.Email,
                    Phone = cachedData.Phone,
                    DateOfBirth = cachedData.DateOfBirth,
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                _cache.Remove($"register:{req.Email}");

                response.Success = true;
                response.Message = "Xác nhận thành công, tài khoản của bạn đã được tạo!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi xác nhận đăng ký: {ex.Message}";
                response.Data = false;
            }

            return response;
        }
    }
}
