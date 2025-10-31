namespace DAL.DTOs.Auths.Res
{
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
        public List<string> RoleName { get; set; }
    }
}
