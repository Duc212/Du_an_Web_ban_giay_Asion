namespace BUS.Services.Interfaces
{
    public interface IMailServices
    {
        Task<bool> SendOtpEmail(string toEmail, string code);

    }
}
