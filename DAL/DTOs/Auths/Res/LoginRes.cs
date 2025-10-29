namespace DAL.DTOs.Auths.Res
{
    public class LoginRes
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public int UserID { get; set; }
        public List<string> RoleName { get; set; }
    }
}
