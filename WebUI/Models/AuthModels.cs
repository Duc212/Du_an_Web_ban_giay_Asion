using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập email hoặc số điện thoại")]
        public string EmailOrPhone { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; } = false;
    }

    public class RegisterRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [MinLength(2, ErrorMessage = "Họ và tên phải có ít nhất 2 ký tự")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [MinLength(3, ErrorMessage = "Tên đăng nhập phải có ít nhất 3 ký tự")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = "";

        public string CountryCode { get; set; } = "+84";

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Bạn phải đồng ý với điều khoản")]
        public bool AcceptTerms { get; set; } = false;
    }

    // DTO for API call
    public class RegisterApiRequest
    {
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
    }

    // DTO for Login API Response
    public class LoginApiResult
    {
        public string Token { get; set; } = "";
        public string? RefreshToken { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    // DTO for OTP Verification API
    public class VerifyOtpApiRequest
    {
        public string Email { get; set; } = "";
        public string Code { get; set; } = "";
    }

    // API Response Models
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }
    }

    public class OtpVerificationRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập mã OTP")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã OTP phải có 6 chữ số")]
        public string OtpCode { get; set; } = "";

        [Required]
        public string Contact { get; set; } = "";

        [Required]
        public string VerificationType { get; set; } = ""; // "email" or "phone"
    }

    public class AuthResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class LoginResult
    {
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; } = new();
    }

    public class RegisterResult
    {
        public string UserId { get; set; } = "";
        public string VerificationToken { get; set; } = "";
        public bool RequiresVerification { get; set; } = true;
    }

    public class User
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPhoneVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }

    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = "";
    }

    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập token")]
        public string Token { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string NewPassword { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Compare(nameof(NewPassword), ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; } = "";
    }
}