using BUS.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace BUS.Services
{
    public class MailServices : IMailServices
    {
        private readonly string _from = "yourmail@gmail.com";
        private readonly string _password = "your-app-password";

        public async Task SendVerificationCodeAsync(string toEmail, string code)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_from);
            message.To.Add(toEmail);
            message.Subject = "Mã xác nhận đăng ký tài khoản";
            message.Body = $"Xin chào! Mã xác nhận của bạn là: {code}\nMã này có hiệu lực trong 5 phút.";

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(_from, _password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
