using System.Text.Json;
using Microsoft.JSInterop;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    /// <summary>
    /// Service xử lý authentication - hiện tại sử dụng fake data
    /// Có thể dễ dàng thay thế bằng HttpClient để gọi API thực
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private User? _currentUser;
        private string? _currentToken;
        private const string TOKEN_KEY = "abc_mart_token";
        private const string USER_KEY = "abc_mart_user";

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_currentToken) && _currentUser != null;
        
        public string? CurrentToken => _currentToken;
        
        public User? CurrentUser => _currentUser;
        
        public event EventHandler<bool>? AuthStateChanged;

        public async Task<AuthResponse<LoginResult>> LoginAsync(LoginRequest request)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1500);

                // Fake validation - replace with actual API call
                if (request.EmailOrPhone == "admin@abc.com" && request.Password == "123456")
                {
                    var user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = "Admin User",
                        Email = "admin@abc.com",
                        Phone = "+84123456789",
                        IsEmailVerified = true,
                        IsPhoneVerified = true,
                        LastLoginAt = DateTime.UtcNow
                    };

                    var token = GenerateFakeToken();
                    var refreshToken = GenerateFakeToken();

                    var result = new LoginResult
                    {
                        Token = token,
                        RefreshToken = refreshToken,
                        ExpiresAt = DateTime.UtcNow.AddHours(24),
                        User = user
                    };

                    // Store in localStorage
                    await StoreAuthDataAsync(token, user);
                    
                    _currentToken = token;
                    _currentUser = user;
                    
                    AuthStateChanged?.Invoke(this, true);

                    return new AuthResponse<LoginResult>
                    {
                        Success = true,
                        Message = "Đăng nhập thành công",
                        Data = result
                    };
                }

                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Email/Số điện thoại hoặc mật khẩu không chính xác",
                    Errors = new List<string> { "Invalid credentials" }
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra. Vui lòng thử lại sau.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<RegisterResult>> RegisterAsync(RegisterRequest request)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(2000);

                // Check if email exists (fake check)
                if (request.Email.ToLower() == "admin@abc.com")
                {
                    return new AuthResponse<RegisterResult>
                    {
                        Success = false,
                        Message = "Email đã được sử dụng",
                        Errors = new List<string> { "Email already exists" }
                    };
                }

                // Fake successful registration
                var result = new RegisterResult
                {
                    UserId = Guid.NewGuid().ToString(),
                    VerificationToken = GenerateFakeToken(),
                    RequiresVerification = true
                };

                return new AuthResponse<RegisterResult>
                {
                    Success = true,
                    Message = "Đăng ký thành công. Vui lòng kiểm tra email để xác nhận tài khoản.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<RegisterResult>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra. Vui lòng thử lại sau.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> VerifyOtpAsync(OtpVerificationRequest request)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1500);

                // Fake OTP validation - accept "123456" as valid
                if (request.OtpCode == "123456")
                {
                    return new AuthResponse<bool>
                    {
                        Success = true,
                        Message = "Xác nhận thành công",
                        Data = true
                    };
                }

                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Mã OTP không chính xác",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra. Vui lòng thử lại sau.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> ResendOtpAsync(string contact, string verificationType)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1000);

                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = $"Mã OTP đã được gửi lại đến {verificationType}",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Không thể gửi lại mã OTP. Vui lòng thử lại.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1500);

                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = "Email khôi phục mật khẩu đã được gửi",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra. Vui lòng thử lại sau.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1500);

                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = "Mật khẩu đã được cập nhật thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra. Vui lòng thử lại sau.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> LogoutAsync()
        {
            try
            {
                // Clear localStorage
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TOKEN_KEY);
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", USER_KEY);
                
                _currentToken = null;
                _currentUser = null;
                
                AuthStateChanged?.Invoke(this, false);

                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = "Đăng xuất thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra khi đăng xuất.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<LoginResult>> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(1000);

                // Fake token refresh
                var newToken = GenerateFakeToken();
                var newRefreshToken = GenerateFakeToken();

                var result = new LoginResult
                {
                    Token = newToken,
                    RefreshToken = newRefreshToken,
                    ExpiresAt = DateTime.UtcNow.AddHours(24),
                    User = _currentUser ?? new User()
                };

                _currentToken = newToken;

                return new AuthResponse<LoginResult>
                {
                    Success = true,
                    Message = "Token refreshed successfully",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Không thể làm mới token. Vui lòng đăng nhập lại.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<User>> GetCurrentUserAsync()
        {
            try
            {
                if (_currentUser == null)
                {
                    // Try to load from localStorage
                    await LoadAuthDataAsync();
                }

                return new AuthResponse<User>
                {
                    Success = _currentUser != null,
                    Message = _currentUser != null ? "User found" : "User not found",
                    Data = _currentUser
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<User>
                {
                    Success = false,
                    Message = "Đã có lỗi xảy ra khi lấy thông tin người dùng.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> CheckEmailExistsAsync(string email)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(500);

                // Fake check - admin@abc.com exists
                var exists = email.ToLower() == "admin@abc.com";

                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = exists ? "Email đã tồn tại" : "Email khả dụng",
                    Data = exists
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Không thể kiểm tra email.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<bool>> CheckPhoneExistsAsync(string phone)
        {
            try
            {
                // Simulate API delay
                await Task.Delay(500);

                // Fake check - assume all phones are available
                return new AuthResponse<bool>
                {
                    Success = true,
                    Message = "Số điện thoại khả dụng",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Không thể kiểm tra số điện thoại.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<LoginResult>> LoginWithGoogleAsync(string googleToken)
        {
            try
            {
                // Simulate OAuth flow
                await Task.Delay(2000);

                // For demo purposes, create a fake Google user
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = "Google User",
                    Email = "user@gmail.com",
                    IsEmailVerified = true,
                    LastLoginAt = DateTime.UtcNow
                };

                var token = GenerateFakeToken();
                var refreshToken = GenerateFakeToken();

                var result = new LoginResult
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddHours(24),
                    User = user
                };

                await StoreAuthDataAsync(token, user);
                
                _currentToken = token;
                _currentUser = user;
                
                AuthStateChanged?.Invoke(this, true);

                return new AuthResponse<LoginResult>
                {
                    Success = true,
                    Message = "Đăng nhập Google thành công",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Đăng nhập Google thất bại.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthResponse<LoginResult>> LoginWithFacebookAsync(string facebookToken)
        {
            try
            {
                // Simulate OAuth flow
                await Task.Delay(2000);

                // For demo purposes, create a fake Facebook user
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = "Facebook User",
                    Email = "user@facebook.com",
                    IsEmailVerified = true,
                    LastLoginAt = DateTime.UtcNow
                };

                var token = GenerateFakeToken();
                var refreshToken = GenerateFakeToken();

                var result = new LoginResult
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddHours(24),
                    User = user
                };

                await StoreAuthDataAsync(token, user);
                
                _currentToken = token;
                _currentUser = user;
                
                AuthStateChanged?.Invoke(this, true);

                return new AuthResponse<LoginResult>
                {
                    Success = true,
                    Message = "Đăng nhập Facebook thành công",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Đăng nhập Facebook thất bại.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        // Private helper methods
        private static string GenerateFakeToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + 
                   Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        private async Task StoreAuthDataAsync(string token, User user)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TOKEN_KEY, token);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", USER_KEY, JsonSerializer.Serialize(user));
        }

        private async Task LoadAuthDataAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", TOKEN_KEY);
                var userJson = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", USER_KEY);

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userJson))
                {
                    _currentToken = token;
                    _currentUser = JsonSerializer.Deserialize<User>(userJson);
                    AuthStateChanged?.Invoke(this, true);
                }
            }
            catch
            {
                // Ignore errors when loading auth data
            }
        }

        /// <summary>
        /// Initialize auth service - call this on app startup
        /// </summary>
        public async Task InitializeAsync()
        {
            await LoadAuthDataAsync();
        }
    }
}