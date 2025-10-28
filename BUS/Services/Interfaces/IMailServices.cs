namespace BUS.Services.Interfaces
{
    public interface IMailServices
    {
        Task SendVerificationCodeAsync(string toEmail, string code);

    }
}
