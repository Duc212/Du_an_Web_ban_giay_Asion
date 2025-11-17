using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using WebUI.Models;
using WebUI.Services.Interfaces;
using WebUI.Constants;

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
        private readonly ConfigurationService _configService;
        private readonly ILoadingService _loadingService;
        private User? _currentUser;
        private string? _currentToken;

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, ConfigurationService configService, ILoadingService loadingService)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _configService = configService;
            _loadingService = loadingService;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_currentToken) && _currentUser != null;

        public string? CurrentToken => _currentToken;

        public User? CurrentUser => _currentUser;

        public event EventHandler<bool>? AuthStateChanged;

        public async Task<AuthResponse<LoginResult>> LoginAsync(LoginRequest request)
        {
            // Show loading
            _loadingService.Show("Đang đăng nhập", "Vui lòng chờ trong giây lát...");
            
            try
            {
                var apiRequest = new
                {
                    userName = request.EmailOrPhone,
                    password = request.Password
                };

                // Serialize request to JSON
                var jsonContent = JsonSerializer.Serialize(apiRequest);

                // Tạo HTTP content
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gọi API
                var apiSettings = await _configService.GetApiSettingsAsync();
                var response = await _httpClient.PostAsync(apiSettings.GetFullUrl(ApiEndpoints.Login), content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse API response
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<LoginApiResult>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (apiResponse?.Success == true && apiResponse.Data != null)
                    {
                        var apiData = apiResponse.Data;

                        // Tạo User object từ API response - xử lý cả 2 format
                        var userId = apiData.UserId ?? apiData.UserID?.ToString() ?? Guid.NewGuid().ToString();
                        var token = apiData.AccessToken ?? apiData.Token ?? "";
                        var roles = apiData.Roles ?? apiData.RoleName;
                        
                        var user = new User
                        {
                            Id = userId,
                            FullName = apiData.FullName ?? "User",
                            Email = apiData.Email ?? request.EmailOrPhone,
                            Phone = apiData.Phone ?? "",
                            Picture = apiData.Picture, // Avatar URL từ API
                            IsEmailVerified = apiData.IsEmailVerified,
                            IsPhoneVerified = true,
                            LastLoginAt = DateTime.UtcNow,
                            Roles = roles
                        };

                        var result = new LoginResult
                        {
                            Token = token,
                            RefreshToken = apiData.RefreshToken ?? "",
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
                            Message = apiResponse.Message ?? "Đăng nhập thành công",
                            Data = result
                        };
                    }

                    return new AuthResponse<LoginResult>
                    {
                        Success = false,
                        Message = apiResponse?.Message ?? "Đăng nhập thất bại",
                        Errors = new List<string> { "Login failed" }
                    };
                }
                else
                {
                    // Parse error response
                    var errorResponse = JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return new AuthResponse<LoginResult>
                    {
                        Success = false,
                        Message = errorResponse?.Message ?? "Email/Số điện thoại hoặc mật khẩu không chính xác",
                        Errors = new List<string> { "Invalid credentials" }
                    };
                }
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
            finally
            {
                // Hide loading
                _loadingService.Hide();
            }
        }

        public async Task<AuthResponse<RegisterResult>> RegisterAsync(RegisterRequest request)
        {
            try
            {
                // Tạo API request DTO
                var apiRequest = new RegisterApiRequest
                {
                    FullName = request.FullName,
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email,
                    Phone = request.Phone,
                    DateOfBirth = request.DateOfBirth ?? DateTime.Now.AddYears(-18)
                };

                // Serialize request to JSON
                var jsonContent = JsonSerializer.Serialize(apiRequest, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                // Tạo HTTP content
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gọi API
                var apiSettings = await _configService.GetApiSettingsAsync();
                var response = await _httpClient.PostAsync(apiSettings.GetFullUrl(ApiEndpoints.Register), content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse API response
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (apiResponse?.Success == true)
                    {
                        // Tạo result cho UI
                        var result = new RegisterResult
                        {
                            UserId = Guid.NewGuid().ToString(),
                            VerificationToken = GenerateFakeToken(),
                            RequiresVerification = true
                        };

                        return new AuthResponse<RegisterResult>
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Đăng ký thành công. Vui lòng kiểm tra email để xác nhận tài khoản.",
                            Data = result
                        };
                    }
                    else
                    {
                        return new AuthResponse<RegisterResult>
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Đăng ký thất bại",
                            Errors = new List<string> { apiResponse?.Message ?? "Unknown error" }
                        };
                    }
                }
                else
                {
                    // Parse error response
                    try
                    {
                        var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(responseContent, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                        return new AuthResponse<RegisterResult>
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Đăng ký thất bại. Vui lòng kiểm tra thông tin và thử lại.",
                            Errors = new List<string> { apiResponse?.Message ?? $"API Error: {response.StatusCode}" }
                        };
                    }
                    catch
                    {
                        return new AuthResponse<RegisterResult>
                        {
                            Success = false,
                            Message = "Đăng ký thất bại. Vui lòng kiểm tra thông tin và thử lại.",
                            Errors = new List<string> { $"API Error: {response.StatusCode}" }
                        };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new AuthResponse<RegisterResult>
                {
                    Success = false,
                    Message = "Không thể kết nối đến máy chủ. Vui lòng kiểm tra kết nối mạng.",
                    Errors = new List<string> { ex.Message }
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
                // Tạo API request DTO
                var apiRequest = new VerifyOtpApiRequest
                {
                    Email = request.Contact,
                    Code = request.OtpCode
                };

                // Serialize request to JSON
                var jsonContent = JsonSerializer.Serialize(apiRequest, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                // Tạo HTTP content
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gọi API
                var apiSettings = await _configService.GetApiSettingsAsync();
                var response = await _httpClient.PostAsync(apiSettings.GetFullUrl(ApiEndpoints.Verify), content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse API response
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (apiResponse?.Success == true)
                    {
                        return new AuthResponse<bool>
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Xác nhận thành công",
                            Data = true
                        };
                    }
                    else
                    {
                        return new AuthResponse<bool>
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Xác nhận thất bại",
                            Data = false
                        };
                    }
                }
                else
                {
                    // Parse error response
                    try
                    {
                        var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(responseContent, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                        return new AuthResponse<bool>
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Mã OTP không chính xác hoặc đã hết hạn",
                            Data = false
                        };
                    }
                    catch
                    {
                        return new AuthResponse<bool>
                        {
                            Success = false,
                            Message = "Mã OTP không chính xác hoặc đã hết hạn",
                            Data = false
                        };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new AuthResponse<bool>
                {
                    Success = false,
                    Message = "Không thể kết nối đến máy chủ. Vui lòng kiểm tra kết nối mạng.",
                    Errors = new List<string> { ex.Message }
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
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", LocalStorageKeys.AuthToken);
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", LocalStorageKeys.UserData);

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
                    RefreshToken = GenerateFakeToken(),
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

                var result = new LoginResult
                {
                    Token = token,
                    RefreshToken = GenerateFakeToken(),
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

                var result = new LoginResult
                {
                    Token = token,
                    RefreshToken = GenerateFakeToken(),
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
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKeys.AuthToken, token);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKeys.UserData, JsonSerializer.Serialize(user));
        }

        private async Task LoadAuthDataAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", LocalStorageKeys.AuthToken);
                var userJson = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", LocalStorageKeys.UserData);

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userJson))
                {
                    _currentToken = token;
                    _currentUser = JsonSerializer.Deserialize<User>(userJson);
                    AuthStateChanged?.Invoke(this, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AuthService] Error loading auth: {ex.Message}");
            }
        }

        public async Task<AuthResponse<LoginResult>> LoginWithGoogleAsync(GoogleLoginRequest request)
        {
            // Show loading
            _loadingService.Show("Đang đăng nhập với Google", "Xác thực thông tin tài khoản...");
            
            try
            {
                // Tạo API request DTO - backend expect idToken
                var apiRequest = new
                {
                    idToken = request.AccessToken, 
                    email = request.Email,
                    name = request.Name,
                    googleId = request.GoogleId,
                    picture = request.Picture
                };

                // Serialize request to JSON
                var jsonContent = JsonSerializer.Serialize(apiRequest, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                // Tạo HTTP content
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gọi API backend
                var apiSettings = await _configService.GetApiSettingsAsync();
                var response = await _httpClient.PostAsync(apiSettings.GetFullUrl(ApiEndpoints.GoogleLogin), content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse API response
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<LoginApiResult>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (apiResponse?.Success == true && apiResponse.Data != null)
                    {
                        var apiData = apiResponse.Data;

                        // Tạo User object từ API response - xử lý cả 2 format
                        var userId = apiData.UserId ?? apiData.UserID?.ToString() ?? Guid.NewGuid().ToString();
                        var token = apiData.AccessToken ?? apiData.Token ?? "";
                        var roles = apiData.Roles ?? apiData.RoleName;
                        
                        var user = new User
                        {
                            Id = userId,
                            FullName = apiData.FullName ?? request.Name,
                            Email = apiData.Email ?? request.Email,
                            Phone = apiData.Phone ?? "",
                            Picture = apiData.Picture ?? request.Picture, // Ưu tiên picture từ API, fallback về Google
                            IsEmailVerified = apiData.IsEmailVerified,
                            IsPhoneVerified = true,
                            LastLoginAt = DateTime.UtcNow,
                            Roles = roles
                        };

                        var result = new LoginResult
                        {
                            Token = token,
                            RefreshToken = apiData.RefreshToken ?? "",
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
                            Message = apiResponse.Message ?? "Đăng nhập Google thành công",
                            Data = result
                        };
                    }

                    return new AuthResponse<LoginResult>
                    {
                        Success = false,
                        Message = apiResponse?.Message ?? "Đăng nhập Google thất bại",
                        Errors = new List<string> { "Google login failed" }
                    };
                }
                else
                {
                    // Parse error response
                    var errorResponse = JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return new AuthResponse<LoginResult>
                    {
                        Success = false,
                        Message = errorResponse?.Message ?? "Đăng nhập Google thất bại",
                        Errors = new List<string> { "Google authentication failed" }
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Không thể kết nối đến máy chủ. Vui lòng kiểm tra kết nối mạng.",
                    Errors = new List<string> { ex.Message }
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse<LoginResult>
                {
                    Success = false,
                    Message = "Có lỗi xảy ra trong quá trình đăng nhập Google",
                    Errors = new List<string> { ex.Message }
                };
            }
            finally
            {
                // Hide loading
                _loadingService.Hide();
            }
        }

        /// <summary>
        /// Initialize auth service - call this on app startup
        /// </summary>
        public async Task InitializeAsync()
        {
            await LoadAuthDataAsync();
        }

        /// <summary>
        /// Trả về UserId dạng int nếu có. Ưu tiên từ CurrentUser.Id, fallback decode JWT.
        /// </summary>
        public int? GetCurrentUserId()
        {
            if (_currentUser != null && int.TryParse(_currentUser.Id, out var idFromUser))
            {
                return idFromUser;
            }

            if (!string.IsNullOrEmpty(_currentToken))
            {
                var parts = _currentToken.Split('.');
                if (parts.Length >= 2)
                {
                    try
                    {
                        var payload = parts[1];
                        // Base64Url decode
                        payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=')
                                             .Replace('-', '+')
                                             .Replace('_', '/');
                        var json = Encoding.UTF8.GetString(Convert.FromBase64String(payload));
                        using var doc = JsonDocument.Parse(json);
                        if (doc.RootElement.TryGetProperty("userId", out var userIdProp) && userIdProp.TryGetInt32(out var idClaim))
                        {
                            return idClaim;
                        }
                        if (doc.RootElement.TryGetProperty("sub", out var subProp))
                        {
                            var subStr = subProp.GetString();
                            if (int.TryParse(subStr, out var subId))
                            {
                                return subId;
                            }
                        }
                    }
                    catch
                    {
                        // Ignore decode errors
                    }
                }
            }
            return null;
        }

        public async Task<CommonResponse<UserWithAddressRes>> GetUserWithAddressAsync()
        {
            try
            {
                if (!IsAuthenticated)
                {
                    return new CommonResponse<UserWithAddressRes>
                    {
                        Success = false,
                        Message = "User not authenticated"
                    };
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var url = $"{apiBaseUrl}{ApiEndpoints.GetUserWithAddress}";

                var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _currentToken
                );

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CommonResponse<UserWithAddressRes>>();
                    return result ?? new CommonResponse<UserWithAddressRes> { Success = false };
                }

                return new CommonResponse<UserWithAddressRes>
                {
                    Success = false,
                    Message = $"API returned status code: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user with address: {ex.Message}");
                return new CommonResponse<UserWithAddressRes>
                {
                    Success = false,
                    Message = "Error occurred while fetching user data"
                };
            }
        }
    }
}