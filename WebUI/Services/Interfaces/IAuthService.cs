using WebUI.Models;

namespace WebUI.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Đăng nhập với email/phone và mật khẩu
        /// </summary>
        Task<AuthResponse<LoginResult>> LoginAsync(LoginRequest request);

        /// <summary>
        /// Đăng ký tài khoản mới
        /// </summary>
        Task<AuthResponse<RegisterResult>> RegisterAsync(RegisterRequest request);

        /// <summary>
        /// Xác nhận OTP cho email/phone
        /// </summary>
        Task<AuthResponse<bool>> VerifyOtpAsync(OtpVerificationRequest request);

        /// <summary>
        /// Gửi lại mã OTP
        /// </summary>
        Task<AuthResponse<bool>> ResendOtpAsync(string contact, string verificationType);

        /// <summary>
        /// Quên mật khẩu - gửi email reset
        /// </summary>
        Task<AuthResponse<bool>> ForgotPasswordAsync(ForgotPasswordRequest request);

        /// <summary>
        /// Reset mật khẩu với token
        /// </summary>
        Task<AuthResponse<bool>> ResetPasswordAsync(ResetPasswordRequest request);

        /// <summary>
        /// Đăng xuất
        /// </summary>
        Task<AuthResponse<bool>> LogoutAsync();

        /// <summary>
        /// Refresh token
        /// </summary>
        Task<AuthResponse<LoginResult>> RefreshTokenAsync(string refreshToken);

        /// <summary>
        /// Lấy thông tin user hiện tại
        /// </summary>
        Task<AuthResponse<User>> GetCurrentUserAsync();

        /// <summary>
        /// Kiểm tra email có tồn tại không
        /// </summary>
        Task<AuthResponse<bool>> CheckEmailExistsAsync(string email);

        /// <summary>
        /// Kiểm tra số điện thoại có tồn tại không
        /// </summary>
        Task<AuthResponse<bool>> CheckPhoneExistsAsync(string phone);

        /// <summary>
        /// Đăng nhập với Google OAuth
        /// </summary>
        Task<AuthResponse<LoginResult>> LoginWithGoogleAsync(string googleToken);

        /// <summary>
        /// Đăng nhập với Facebook OAuth
        /// </summary>
        Task<AuthResponse<LoginResult>> LoginWithFacebookAsync(string facebookToken);

        /// <summary>
        /// Kiểm tra trạng thái đăng nhập
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Lấy token hiện tại
        /// </summary>
        string? CurrentToken { get; }

        /// <summary>
        /// Lấy user hiện tại
        /// </summary>
        User? CurrentUser { get; }

        /// <summary>
        /// Event khi trạng thái auth thay đổi
        /// </summary>
        event EventHandler<bool>? AuthStateChanged;

        /// <summary>
        /// Đăng nhập với Google OAuth
        /// </summary>
        Task<AuthResponse<LoginResult>> LoginWithGoogleAsync(GoogleLoginRequest request);

        /// <summary>
        /// Khởi tạo AuthService - load auth state từ localStorage
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Lấy UserId dạng int nếu có (từ CurrentUser hoặc decode JWT token)
        /// </summary>
        int? GetCurrentUserId();

        /// <summary>
        /// Lấy thông tin user kèm địa chỉ
        /// </summary>
        Task<CommonResponse<UserWithAddressRes>> GetUserWithAddressAsync();
    }
}