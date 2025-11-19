using BUS.Services.Interfaces;
using DAL.DTOs.Auths.Req;
using DAL.DTOs.Auths.Res;
using DAL.DTOs.Users.Req;
using DAL.DTOs.Users.Res;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.Repositories;
using DAL.RepositoryAsyns;
using Helper.CacheCore.Interfaces;
using Helper.Utils;
using Helper.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using Google.Apis.Auth;

namespace BUS.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly ITokenUtils _tokenUtils;
        private readonly IMailServices _mailServices;
        private readonly IRepositoryAsync<UserRole> _userRoleRepository;
        private readonly IRepositoryAsync<Role> _roleRepository;
        private readonly IMemoryCacheSystem _cache;
        private readonly IAvatarUtils _avatarUtils;

        public AuthServices(
            IRepositoryAsync<User> userRepository,
            ITokenUtils tokenUtils,
            IMailServices mailServices,
            IMemoryCacheSystem cache,
            IRepositoryAsync<UserRole> userRoleRepository,
            IRepositoryAsync<Role> roleRepository,
            IAvatarUtils avatarUtils)
        {
            _userRepository = userRepository;
            _tokenUtils = tokenUtils;
            _mailServices = mailServices;
            _cache = cache;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _avatarUtils = avatarUtils;
        }

        public async Task<CommonResponse<bool>> CreateUserFromAdmin(CreateUserReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
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

                var user = new User
                {
                    FullName = req.FullName,
                    Username = req.Username,
                    Password = encryptedPassword,
                    Email = req.Email,
                    Phone = req.Phone,
                    DateOfBirth = req.DateOfBirth,
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                var roles = await _roleRepository.AsQueryable()
                    .Where(r => req.ListRole.Contains(r.Name))
                    .ToListAsync();

                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        UserID = user.UserID,
                        RoleID = role.RoleID
                    };
                    await _userRoleRepository.AddAsync(userRole);
                }

                await _userRoleRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Tạo user thành công!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi tạo user: {ex.Message}";
                response.Data = false;
            }

            return response;
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
            var roles = await (from ur in _userRoleRepository.AsQueryable()
                               join r in _roleRepository.AsQueryable() on ur.RoleID equals r.RoleID
                               where ur.UserID == user.UserID
                               select r.Name)
                   .ToListAsync();

            var accessToken = _tokenUtils.GenerateToken(user.UserID);
            var refreshToken = _tokenUtils.GenerateRefreshToken(user.UserID);

            response.Success = true;
            response.Message = "Đăng nhập thành công.";
            response.Data = new LoginRes
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserID = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Picture = null,
                IsEmailVerified = true,
                RoleName = roles
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

                await _mailServices.SendOtpEmail(req.Email,code);

                var encryptedPassword = CryptoHelperUtil.Encrypt(req.Password);

                var avatarUrl = _avatarUtils.GenerateAvatarUrl(req.FullName);

                var tempData = new
                {
                    req.FullName,
                    req.Username,
                    Password = encryptedPassword,
                    req.Email,
                    req.Phone,
                    req.DateOfBirth,
                    Picture = avatarUrl,
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
                    Picture = cachedData.Picture,
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                var userRole = new UserRole
                {
                    UserID = user.UserID,
                    RoleID = (int)RoleEnums.User
                };
                await _userRoleRepository.AddAsync(userRole);
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

        public async Task<CommonResponse<LoginRes>> GoogleLogin(GoogleLoginReq req)
        {
            var response = new CommonResponse<LoginRes>();

            try
            {
                if (string.IsNullOrWhiteSpace(req.IdToken))
                {
                    response.Success = false;
                    response.Message = "Token không hợp lệ!";
                    return response;
                }

                GoogleJsonWebSignature.Payload payload;
                try
                {
                    payload = await GoogleJsonWebSignature.ValidateAsync(req.IdToken);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = $"Token Google không hợp lệ! Chi tiết: {ex.Message}";
                    return response;
                }

                if (payload == null || string.IsNullOrEmpty(payload.Email))
                {
                    response.Success = false;
                    response.Message = "Không thể xác thực Google token!";
                    return response;
                }

                var existingUser = await _userRepository.AsQueryable()
         .FirstOrDefaultAsync(x => x.Email == payload.Email);

                User user;
                bool isNewUser = false;

                if (existingUser == null)
                {
                    isNewUser = true;
                    user = new User
                    {
                        FullName = payload.Name,
                        Username = payload.Email.Split('@')[0] + "_" + Guid.NewGuid().ToString()[..6],
                        Password = CryptoHelperUtil.Encrypt(Guid.NewGuid().ToString()),
                        Email = payload.Email,
                        Phone = " ",
                        DateOfBirth = DateTime.UtcNow.AddYears(-18),
                        Picture = payload.Picture,
                        Status = (int)UserStatusEnums.Active,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _userRepository.AddAsync(user);
                    await _userRepository.SaveChangesAsync();

                    var userRole = new UserRole
                    {
                        UserID = user.UserID,
                        RoleID = (int)RoleEnums.User
                    };

                    await _userRoleRepository.AddAsync(userRole);
                    await _userRoleRepository.SaveChangesAsync();
                }
                else
                {
                    user = existingUser;

                    if (!string.IsNullOrEmpty(payload.Picture))
                    {
                        user.Picture = payload.Picture;
                        await _userRepository.UpdateAsync(user);
                        await _userRepository.SaveChangesAsync();
                    }
                }

                var roles = await (from ur in _userRoleRepository.AsQueryable()
                                   join r in _roleRepository.AsQueryable() on ur.RoleID equals r.RoleID
                                   where ur.UserID == user.UserID
                                   select r.Name)
       .ToListAsync();

                var accessToken = _tokenUtils.GenerateToken(user.UserID);
                var refreshToken = _tokenUtils.GenerateRefreshToken(user.UserID);

                response.Success = true;
                response.Message = isNewUser ? "Đăng nhập Google thành công! Tài khoản mới đã được tạo." : "Đăng nhập Google thành công!";
                response.Data = new LoginRes
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Picture = user.Picture,
                    IsEmailVerified = true,
                    RoleName = roles
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi đăng nhập Google: {ex.Message}";
            }

            return response;
        }

        public async Task<CommonResponse<UserWithAddressRes>> GetUserWithAddress(int userId)
        {
            var user = await _userRepository.AsNoTrackingQueryable()
                .FirstOrDefaultAsync(u => u.UserID == userId);
            if (user == null)
            {
                return new CommonResponse<UserWithAddressRes>
                {
                    Success = false,
                    Message = "Không tìm thấy user.",
                    Data = null
                };
            }

            var addresses = await _userRepository.DbContext.Set<Address>()
                .Where(a => a.UserID == userId)
                .ToListAsync();

            var result = new UserWithAddressRes
            {
                UserID = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Picture = user.Picture,
                DateOfBirth = user.DateOfBirth,
                Status = user.Status,
                Addresses = addresses
            };
            return new CommonResponse<UserWithAddressRes>
            {
                Success = true,
                Message = "Lấy thông tin user thành công.",
                Data = result
            };
        }

        public async Task<CommonResponse<bool>> AddUser(AddUserReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                // 1. Kiểm tra username hoặc email đã tồn tại chưa
                var existingUser = await _userRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(x => x.Username == req.Username || x.Email == req.Email);

                if (existingUser != null)
                {
                    response.Success = false;
                    response.Message = "Tên đăng nhập hoặc email đã tồn tại!";
                    response.Data = false;
                    return response;
                }

                // 2. Kiểm tra các role có tồn tại trong hệ thống không
                if (req.Roles == null || req.Roles.Count == 0)
                {
                    response.Success = false;
                    response.Message = "Vui lòng chọn ít nhất một quyền cho user!";
                    response.Data = false;
                    return response;
                }

                var roles = await _roleRepository.AsQueryable()
                    .Where(r => req.Roles.Contains(r.Name))
                    .ToListAsync();

                if (roles.Count != req.Roles.Count)
                {
                    response.Success = false;
                    response.Message = "Một hoặc nhiều quyền không hợp lệ!";
                    response.Data = false;
                    return response;
                }

                // 3. Mã hóa mật khẩu
                var encryptedPassword = CryptoHelperUtil.Encrypt(req.Password);

                var avatarUrl = _avatarUtils.GenerateAvatarUrl(req.FullName);

                var user = new User
                {
                    FullName = req.FullName,
                    Username = req.Username,
                    Password = encryptedPassword,
                    Email = req.Email,
                    Phone = req.Phone,
                    DateOfBirth = req.DateOfBirth,
                    Picture = avatarUrl,
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        UserID = user.UserID,
                        RoleID = role.RoleID
                    };
                    await _userRoleRepository.AddAsync(userRole);
                }

                await _userRoleRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Thêm user thành công!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi thêm user: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<List<GetListRoleRes>>> GetListRole()
        {
            var response = new CommonResponse<List<GetListRoleRes>>();

            try
            {
                var roles = await _roleRepository.AsQueryable()
                    .Select(r => new GetListRoleRes
                    {
                        RoleId = r.RoleID,
                        RoleName = r.Name
                    })
                    .ToListAsync();

                response.Success = true;
                response.Message = "Lấy danh sách role thành công!";
                response.Data = roles;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi lấy danh sách role: {ex.Message}";
                response.Data = null;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> UpdateUser(UpdateUserReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                // 1. Kiểm tra user có tồn tại không
                var user = await _userRepository.AsQueryable()
                    .FirstOrDefaultAsync(x => x.UserID == req.UserID);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User không tồn tại!";
                    response.Data = false;
                    return response;
                }

                // 2. Kiểm tra username hoặc email đã được sử dụng bởi user khác chưa
                var existingUser = await _userRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(x => x.UserID != req.UserID && 
                                            (x.Username == req.Username || x.Email == req.Email));

                if (existingUser != null)
                {
                    response.Success = false;
                    response.Message = "Tên đăng nhập hoặc email đã được sử dụng bởi user khác!";
                    response.Data = false;
                    return response;
                }

                // 3. Kiểm tra các role có tồn tại trong hệ thống không
                if (req.Roles == null || req.Roles.Count == 0)
                {
                    response.Success = false;
                    response.Message = "Vui lòng chọn ít nhất một quyền cho user!";
                    response.Data = false;
                    return response;
                }

                var roles = await _roleRepository.AsQueryable()
                    .Where(r => req.Roles.Contains(r.Name))
                    .ToListAsync();

                if (roles.Count != req.Roles.Count)
                {
                    response.Success = false;
                    response.Message = "Một hoặc nhiều quyền không hợp lệ!";
                    response.Data = false;
                    return response;
                }

                // 4. Cập nhật thông tin user
                user.FullName = req.FullName;
                user.Username = req.Username;
                user.Email = req.Email;
                user.Phone = req.Phone;
                user.DateOfBirth = req.DateOfBirth;
                user.Status = req.Status;

                // Chỉ cập nhật password nếu có giá trị mới
                if (!string.IsNullOrWhiteSpace(req.Password))
                {
                    user.Password = CryptoHelperUtil.Encrypt(req.Password);
                }

                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                // 5. Xóa tất cả role cũ của user
                var oldUserRoles = await _userRoleRepository.AsQueryable()
                    .Where(ur => ur.UserID == req.UserID)
                    .ToListAsync();

                foreach (var oldRole in oldUserRoles)
                {
                    await _userRoleRepository.RemoveAsync(oldRole);
                }

                // 6. Thêm role mới cho user
                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        UserID = user.UserID,
                        RoleID = role.RoleID
                    };
                    await _userRoleRepository.AddAsync(userRole);
                }

                await _userRoleRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Cập nhật user thành công!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi cập nhật user: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<GetUserDetailRes>> GetUserDetail(int userId)
        {
            var response = new CommonResponse<GetUserDetailRes>();

            try
            {
                var user = await _userRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User không tồn tại!";
                    response.Data = null;
                    return response;
                }

                // Lấy danh sách role của user
                var roles = await (from ur in _userRoleRepository.AsQueryable()
                                   join r in _roleRepository.AsQueryable() on ur.RoleID equals r.RoleID
                                   where ur.UserID == userId
                                   select r.Name)
                    .ToListAsync();

                var userDetail = new GetUserDetailRes
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.Phone,
                    DateOfBirth = user.DateOfBirth,
                    Picture = user.Picture,
                    Status = user.Status,
                    Roles = roles,
                    CreatedAt = user.CreatedAt
                };

                response.Success = true;
                response.Message = "Lấy thông tin user thành công!";
                response.Data = userDetail;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi lấy thông tin user: {ex.Message}";
                response.Data = null;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> DeleteUser(int userId)
        {
            var response = new CommonResponse<bool>();

            try
            {
                var user = await _userRepository.AsQueryable()
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User không tồn tại!";
                    response.Data = false;
                    return response;
                }

                user.Status = (int)UserStatusEnums.Blocked;
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Xóa user thành công!";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi khi xóa user: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<LoginRes>> StaffLogin(LoginReq req)
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

            var roles = await (from ur in _userRoleRepository.AsQueryable()
                               join r in _roleRepository.AsQueryable() on ur.RoleID equals r.RoleID
                               where ur.UserID == user.UserID
                               select r.Name)
                   .ToListAsync();

            var isStaff = roles.Any(r => r.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                                         r.Equals("Employee", StringComparison.OrdinalIgnoreCase));
            if (!isStaff)
            {
                response.Success = false;
                response.Message = "Tài khoản không có quyền truy cập trang quản trị.";
                return response;
            }

            var accessToken = _tokenUtils.GenerateToken(user.UserID);
            var refreshToken = _tokenUtils.GenerateRefreshToken(user.UserID);

            response.Success = true;
            response.Message = "Đăng nhập nhân viên thành công.";
            response.Data = new LoginRes
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserID = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Picture = user.Picture,
                IsEmailVerified = true,
                RoleName = roles
            };
            return response;
        }
    }
}
