using BUS.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BUS.Services
{
    public class MailServices : IMailServices
    {
        private readonly string _from;
        private readonly string _password;

        public MailServices(IConfiguration configuration)
        {
            _from = configuration["EmailSettings:From"];
            _password = configuration["EmailSettings:Password"];
        }

        public async Task<bool> SendOtpEmail(string email, string optCode)
        {
            try
        {

                string subject = "Mã Xác Minh - Asion Store";
                string body = $@"
       
<!DOCTYPE html>
<html lang=""en"">

<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Mã Xác Minh</title>
</head>

<body>
    <div style=""padding:0;margin:0;height:100%;width:100%;font-family:Arial,'Times New Roman','Calibri'"">


        <div style=""margin:0 auto;max-width:600px;display:block;background:#f0f0f0;font-family:inherit"">
            <table cellpadding=""0"" cellspacing=""0""
                style=""padding:0;border-spacing:0;background:#f0f0f0;border:0;margin:0;text-align:center;vertical-align:middle;font-weight:500;table-layout:fixed;border-collapse:collapse;height:100%;width:100%;line-height:100%""
                width=""100%"" height=""100%"" align=""center"" valign=""middle"">
                <tbody>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td
                            style=""margin:0;padding:0;border:none;border-spacing:0;background:#f0f0f0;border-collapse:collapse;font-family:inherit"">
                            <table cellpadding=""0"" cellspacing=""0""
                                style=""margin:0;border-spacing:0;border:0;padding:0;width:100%;border-collapse:collapse""
                                width=""100%"">
                                <tbody>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">
                                            <h1 style=""font-size:36px;font-weight:700;color:#333;margin:20px 0;font-family:inherit"">ASION STORE</h1>
                                            <p style=""font-size:14px;color:#666;margin:0;font-family:inherit"">Cửa hàng giày thể thao chính hãng</p>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""1""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:24px;border-collapse:collapse;font-family:inherit""
                                            height=""24"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""></table>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">
                                            <table cellpadding=""0"" cellspacing=""0""
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%"">
                                                <tbody>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                                            width=""72"" height=""100%"">
                                                            <div
                                                                style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                                            </div>
                                                        </td>
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center"">
                                                            <h1
                                                                style=""font-size:32px;font-weight:500;letter-spacing:0.01em;color:#141212;text-align:center;line-height:39px;margin:0;font-family:inherit"">
                                                                Mã Xác Minh</h1>
                                                        </td>
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                                            width=""72"" height=""100%"">
                                                            <div
                                                                style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td colspan=""1""
                            style=""margin:0;padding:0;border:none;border-spacing:0;height:0px;border-collapse:collapse;font-family:inherit""
                            height=""0"">
                            <table
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                width=""100%"">
                            </table>
                        </td>
                    </tr>
                    
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center"">
                            </td>
                    </tr>
                    
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center"">
                            <table cellpadding=""0"" cellspacing=""0""
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                width=""100%"">
                                <tbody>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""3""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:64px;border-collapse:collapse;font-family:inherit""
                                            height=""64"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""><p>Để xác minh tài khoản của bạn, hãy nhập mã này vào Asion Store:</p></table>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                            width=""72"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                            </div>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">
                                            <table cellpadding=""0"" cellspacing=""0""
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;background-color:#f9f9f9;border-collapse:collapse""
                                                width=""100%"" bgcolor=""#F9F9F9"">
                                                <tbody>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td colspan=""3""
                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:40px;border-collapse:collapse;font-family:inherit""
                                                            height=""40"">
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%""></table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:38px;border-collapse:collapse;font-family:inherit""
                                                            width=""38"" height=""100%"">
                                                            <div
                                                                style=""height:100%;overflow:hidden;width:38px;font-family:inherit"">
                                                            </div>
                                                        </td>
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center"">
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;table-layout:fixed;border-collapse:collapse""
                                                                width=""100%"">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <h1
                                                                                style=""font-size:40px;font-weight:700;line-height:100%;color:#c51e1e;margin:0;text-align:center;font-family:inherit"">
                                                                                {optCode}
                                                                            </h1>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:38px;border-collapse:collapse;font-family:inherit""
                                                            width=""38"" height=""100%"">
                                                            <div
                                                                style=""height:100%;overflow:hidden;width:38px;font-family:inherit"">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td colspan=""3""
                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:48px;border-collapse:collapse;font-family:inherit""
                                                            height=""48"">
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%""></table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                            width=""72"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""3""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:48px;border-collapse:collapse;font-family:inherit""
                                            height=""48"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""></table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center""></td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center"">
                            <table cellpadding=""0"" cellspacing=""0""
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;font-size:16px;text-align:center;line-height:140%;letter-spacing:-0.01em;color:#666;border-collapse:collapse""
                                width=""100%"" align=""center"">
                                <tbody>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:100px;border-collapse:collapse;font-family:inherit""
                                            width=""100"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:100px;font-family:inherit"">
                                            </div>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">Mã xác minh sẽ hết hạn sau 48 giờ.</td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:100px;border-collapse:collapse;font-family:inherit""
                                            width=""100"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:100px;font-family:inherit"">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""3""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:24px;border-collapse:collapse;font-family:inherit""
                                            height=""24"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""></table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center""></td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center"">
                            <table cellpadding=""0"" cellspacing=""0""
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;font-size:16px;text-align:center;line-height:140%;letter-spacing:-0.01em;color:#666;border-collapse:collapse""
                                width=""100%"" align=""center"">
                                <tbody>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:100px;border-collapse:collapse;font-family:inherit""
                                            width=""100"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:100px;font-family:inherit"">
                                            </div>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">Nếu bạn không yêu cầu mã, bạn có thể bỏ qua tin nhắn.</td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:100px;border-collapse:collapse;font-family:inherit""
                                            width=""100"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:100px;font-family:inherit"">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""3""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:20px;border-collapse:collapse;font-family:inherit""
                                            height=""80"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""></table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td colspan=""1""
                            style=""margin:0;padding:0;border:none;border-spacing:0;height:0px;border-collapse:collapse;font-family:inherit""
                            height=""0"">
                            <table
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                width=""100%""></table>
                        </td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center""></td>
                    </tr>
                    <tr
                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                            align=""center"">
                            <table cellpadding=""0"" cellspacing=""0""
                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                width=""100%"">
                                <tbody>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                            width=""72"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                            </div>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                            align=""center"">
                                            <table cellpadding=""0"" cellspacing=""0""
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;font-size:11.24px;line-height:140%;letter-spacing:-0.01em;color:#999;table-layout:fixed;border-collapse:collapse""
                                                width=""100%"">
                                                <tbody>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center"">
                                                            <table cellpadding=""0"" cellspacing=""0""
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%"">
                                                                <tbody>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td colspan=""1""
                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:48px;border-collapse:collapse;font-family:inherit""
                                                                            height=""48"">
                                                                            <table
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                                width=""100%""></table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                                            align=""center"">
                                                                            <table cellpadding=""0"" cellspacing=""0""
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;table-layout:fixed;border-collapse:collapse""
                                                                                width=""100%"">
                                                                                <tbody>
                                                                                    <tr
                                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;height:44px;width:100%;border-collapse:collapse;font-family:inherit"">
                                                                                        <td
                                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                                        </td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:44px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""44"" height=""44""><a
                                                                                                href=""https://www.facebook.com/""
                                                                                                style=""color:#bd2225;text-decoration:underline""
                                                                                                target=""_blank""
                                                                                                 ><img
                                                                                                    alt=""Biểu tượng Facebook""
                                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NZ8eWjjrcRIzSf97IShBwkN3hf6EAG7mwr6W_kVv5mlf6jXuaDyCZR-ZHxmIxbRCPnfGib4i13UY0rRnesmU-MdcGrTM2eq65bfR-TVMbW9BRZ42k4MYcppnxxUQcVyOuitL-E=s0-d-e1-ft#https://lolstatic-a.akamaihd.net/email-marketing/betabuddies/facebook-logo.png""
                                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;display:inline-block;width:187px""
                                                                                                    width=""187"" class=""CToWUd""
                                                                                                    data-bit=""iit""></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center"">
                                                            <table cellpadding=""0"" cellspacing=""0""
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%"">
                                                                <tbody>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td colspan=""1""
                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:48px;border-collapse:collapse;font-family:inherit""
                                                                            height=""48"">
                                                                            <table
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                                width=""100%""></table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                                            align=""center"">
                                                                            <table cellpadding=""0"" cellspacing=""0""
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;table-layout:fixed;border-collapse:collapse""
                                                                                width=""100%"">
                                                                                <tbody>
                                                                                    <tr
                                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;height:44px;width:100%;border-collapse:collapse;font-family:inherit"">
                                                                                        <td
                                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                                        </td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:44px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""44"" height=""44""><a
                                                                                                href=""https://www.facebook.com/""
                                                                                                style=""color:#bd2225;text-decoration:underline""
                                                                                                target=""_blank""
                                                                                                 ><img
                                                                                                    alt=""Biểu tượng Facebook""
                                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NZ8eWjjrcRIzSf97IShBwkN3hf6EAG7mwr6W_kVv5mlf6jXuaDyCZR-ZHxmIxbRCPnfGib4i13UY0rRnesmU-MdcGrTM2eq65bfR-TVMbW9BRZ42k4MYcppnxxUQcVyOuitL-E=s0-d-e1-ft#https://lolstatic-a.akamaihd.net/email-marketing/betabuddies/facebook-logo.png""
                                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;display:inline-block;width:187px""
                                                                                                    width=""187"" class=""CToWUd""
                                                                                                    data-bit=""iit""></td>
                                                                                        </td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:24px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""24"" height=""44""></td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:44px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""44"" height=""44""><a
                                                                                                href=""https://www.instagram.com/""
                                                                                                style=""color:#bd2225;text-decoration:underline""
                                                                                                target=""_blank""
                                                                                               ><img
                                                                                                    alt=""Biểu tượng Instagram""
                                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NZUedGKkwdQ9Jw0Y6ClifA4PDpAMyAW1-N0oAWzeWOkcqJmIjw5BHdJOBiVWHCOjj3duW-y3unrjqfIcT4-q92i1dDv5ljZKhjocQMimNWs1PnpumPVQ64k3JBtOtYDCrYTJFUV=s0-d-e1-ft#https://lolstatic-a.akamaihd.net/email-marketing/betabuddies/instagram-logo.png""
                                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
                                                                                                    width=""44""
                                                                                                    height=""44""
                                                                                                    class=""CToWUd""
                                                                                                    data-bit=""iit""></a>
                                                                                        </td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:24px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""24"" height=""44""></td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:44px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""44"" height=""44""><a
                                                                                                href=""https://www.youtube.com/""
                                                                                                style=""color:#bd2225;text-decoration:underline""
                                                                                                target=""_blank""
                                                                                                ><img
                                                                                                    alt=""Biểu tượng YouTube""
                                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_Nbw5BguhKUzXGTPLZsJY9xNhnoGbwqSlFVubmXT-KvYiKA_WihAcokPFB5Ea-02DzZ_OjV7HO2EHFEA2itA_070a13moZT1eOK5cYTzdDH_qKykKVqjbfSSYG95ToiTmZ7qNw=s0-d-e1-ft#https://lolstatic-a.akamaihd.net/email-marketing/betabuddies/youtube-logo.png""
                                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
                                                                                                    width=""44""
                                                                                                    height=""44""
                                                                                                    class=""CToWUd""
                                                                                                    data-bit=""iit""></a>
                                                                                        </td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:24px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""24"" height=""44""></td>
                                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;width:44px;height:44px;border-collapse:collapse;font-family:inherit""
                                                                                            width=""44"" height=""44""><a
                                                                                                href=""https://x.com/""
                                                                                                style=""color:#bd2225;text-decoration:underline""
                                                                                                target=""_blank""
                                                                                                ><img
                                                                                                    alt=""Biểu tượng Twitter""
                                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NYDPpMKFfKpK07U8PBz_ZZkCa3lxfy-wSHkgBALHkWzEbaBXgiPGCHsLabi4OzA0cewt01ygRh-io4GT0MpbRvRm41I5P4K8O3m5S_RIKGMuPVvPsxsHKqoeXY-cyl8K3yfLQ=s0-d-e1-ft#https://lolstatic.a.akamaihd.net/email-marketing/betabuddies/twitter-logo.png""
                                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
                                                                                                    width=""44""
                                                                                                    height=""44""
                                                                                                    class=""CToWUd""
                                                                                                    data-bit=""iit""></a>
                                                                                        </td>
                                                                                        <td
                                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td colspan=""1""
                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:32px;border-collapse:collapse;font-family:inherit""
                                                                            height=""32"">
                                                                            <table
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                                width=""100%""></table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center"">
                                                            <table cellpadding=""0"" cellspacing=""0""
                                                                style=""padding:0;border:none;border-spacing:0;width:100%;margin:0 auto;border-collapse:collapse""
                                                                width=""100%"">
                                                                <tbody>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                                            align=""center""><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""><a
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle"">Chính
                                                                                    sách Quyền riêng tư</a></span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""> | </span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""><a
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle"">Hỗ
                                                                                    trợ</a></span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""> | </span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""><a
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle"">Điều
                                                                                    khoản Sử dụng</a></span></td>
                                                                    </tr>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        <td colspan=""1""
                                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:16px;border-collapse:collapse;font-family:inherit""
                                                                            height=""16"">
                                                                            <table
                                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                                width=""100%""></table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center""><span style=""font-family:inherit"">Đây là dịch
                                                                vụ thư thông báo.</span></td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td colspan=""1""
                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:16px;border-collapse:collapse;font-family:inherit""
                                                            height=""16"">
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%""></table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center""><span style=""font-family:inherit"">Asion Store - Cửa hàng giày thể thao chính hãng</span></td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td colspan=""1""
                                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:16px;border-collapse:collapse;font-family:inherit""
                                                            height=""16"">
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                                width=""100%""></table>
                                                        </td>
                                                    </tr>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            align=""center""><span style=""font-family:inherit"">© năm 2025
                                                                - bởi Asion Store</span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;height:100%;overflow:hidden;width:72px;border-collapse:collapse;font-family:inherit""
                                            width=""72"" height=""100%"">
                                            <div style=""height:100%;overflow:hidden;width:72px;font-family:inherit"">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td colspan=""3""
                                            style=""margin:0;padding:0;border:none;border-spacing:0;height:64px;border-collapse:collapse;font-family:inherit""
                                            height=""64"">
                                            <table
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%""></table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


    </div>
</body>

</html>";

                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(email.Trim());
                    mail.From = new MailAddress(_from, "Asion Store - Hệ thống hỗ trợ");
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(_from, _password);

                        await smtp.SendMailAsync(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email OTP: {ex.Message}");
                return false;
            }
        }

    }
}
