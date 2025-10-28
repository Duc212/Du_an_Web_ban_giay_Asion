namespace Helper.Utils.Interfaces
{
    public interface ITokenUtils
    {
        string GenerateToken(int id);
        string GenerateRefreshToken(int id);
        string? GenerateTokenFromRefreshToken(string refreshToken);
        int? ValidateToken(string token);
        bool IsAccessTokenExpired(string accessToken);
    }
}
