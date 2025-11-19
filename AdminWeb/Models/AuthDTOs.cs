namespace AdminWeb.Models
{
    public class LoginReq
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRes
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public bool IsEmailVerified { get; set; }
        public List<string> RoleName { get; set; } = new();
    }

    public class CommonResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}