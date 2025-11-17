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

                string subject = "Your OTP Code";
                string body = $@"
       
<!DOCTYPE html>
<html lang=""en"">

<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
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
                                            align=""center""></td>
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                    </tr>
                                    <tr
                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                        <td
                                            style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">

                                            <table cellpadding=""0"" cellspacing=""0""
                                                style=""margin:0;padding:0;border:none;border-spacing:0;width:100%;border-collapse:collapse""
                                                width=""100%"">
                                                <tbody>
                                                    <tr
                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;background-image:url(https://res.cloudinary.com/dw44ghjmu/image/upload/v1745446945/LogoEmailCinex_iuwqqe.png);background-size:cover;width:612px;height:146px;text-align:center;border-collapse:collapse;font-family:inherit""
                                                            width=""612"" height=""146""
                                                            background=""https://res.cloudinary.com/dw44ghjmu/image/upload/v1745446945/LogoEmailCinex_iuwqqe.png""
                                                            align=""center""></td>
                                                    </tr>
                                                </tbody>
                                            </table>


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
                                                width=""100%""><p>Để xác minh tài khoản của bạn, hãy nhập mã này vào CineX:</p></table>
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
                                                            <table
                                                                style=""margin:0;padding:0;border:none;border-spacing:0;display:inline-table;width:auto;border-collapse:collapse"">
                                                                <tbody>
                                                                    <tr
                                                                        style=""margin:0;padding:0;border:none;border-spacing:0;border-collapse:collapse;font-family:inherit"">
                                                                        
                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;width:32px;border-collapse:collapse;font-family:inherit""
                                                                            width=""32"" align=""center""></td>
                                                                        <td style=""margin:0;padding:0;border:none;border-spacing:0;text-align:center;border-collapse:collapse;font-family:inherit""
                                                                            align=""center""><img
                                                                                src=""https://res.cloudinary.com/dw44ghjmu/image/upload/v1745447860/e9acac58-056e-4b69-bc95-0576c455b5f4_rtybyk.png""
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
                                                                                                    style=""border:0;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
                                                                                                    width=""44""
                                                                                                    height=""44""
                                                                                                    class=""CToWUd""
                                                                                                    data-bit=""iit""></a>
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
                                                                                                    style=""border:0;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
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
                                                                                                    style=""border:0;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
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
                                                                                                    style=""border:0;line-height:100%;outline:none;text-decoration:none;width:44px;height:44px""
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
                                                                                    
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle""
                                                                                    
                                                                                    data-saferedirecturl=""https://www.google.com/url?q=https://links.riotgames.com/ls/click?upn%3DfrHghcUMWgUZ9OUHJJkDdaslin-2FqpxTNhpsWvP-2FdJrIzmy3Vb9wkwL7FAp39O-2FpyV3KcJTlQXFtw4C6etxvOOw-3D-3Dg9-8_CyPYuvKevH6nD6CMROzBiVQzIj9ecAtAT4i5qN8rzTPS70M0Tdj-2FnTRrzaK0fly80zNHaMqliceDQg7-2FI7Nzdxh6rc4O-2FlJGR-2FXhvyLnYZ7gf9Aw3ue5CqgeIu2Y-2B0ut36SxWVjDVHZhHRcb-2BLf4oLViFWt6BP6OfO6Ss0X2cbAaBqdSpqWxghXv-2FEwS0BFTsaaUSRCvl0WX5d7QjEla3SHyQxQ1OnXg8O-2FOzcOVJo-2B7Z1395NjjJC-2FslOKr5octrndcyDoXgrabyTDWtoaWP-2BRmw1hJpxjB98geqN3E1kBvEXfZzuoWjkizDCrtSNVPMx0SWGHUejW-2B-2BoRJaob6njY3ne-2FVtHMV5UxEBk2QiER9AjzN87Cf1tetplaxwk1nhpuWA7XvZR-2F1lG1VKHSjEWPP-2BDAMUD4t2Sktq9N8SqCzoZbihLOn9KpX8cTriDAhVi6731R3-2BcmU4JogPjoXPIfUssvqmmNOYKh3ntXwVnsz1Iil3CDaIkzy99qvhWEbeHTvL4ri0v6kmTw46cX8J1e0vu0hLzrHbEPoq9FWNhdkMpJC4gTXQY8nA-2FOhHeaIeRZcobynQVisoBbDbVdamDQIrOrWEHhN8HGUWiMAKuDzSQZeBba-2F3LYI7lTvxqEFVUM1s3i3fYMpbzRittkCDMghizSCTYq4EPeBpWQxBiYJbIyqTqf8jqwRdHzbE7qyH9T6n-2FJcmAKOgQjXkilY1c7NUoI5zXI6DKGNye0yO-2F02ROhHSnZt956VdejVtb8svxQnrv7tj25WYfoEpBvg1SqHBjbT91VwRQSMexbsOvVSlrMLCxZsI91FpLUYYXlgMJjbvJNphRf0-2FOf0WlaS3C1yHYlKoNGmUJitVEr5OMW-2FQl4gX2u93GTWMQ5cDhwoBD9r-2BtSUdACezUycbLI3ZpU3PVDGbZ0uiUpWu7WKteuEMrM7UVTcC7DFtUpDGE9S4or4dEPo0aMjgUstjEjYl1mR4xKBQSsizz-2F8W3XFv3w-3D&amp;source=gmail&amp;ust=1745531320354000&amp;usg=AOvVaw2XtrVtHXJwzY970jLPVO2z"">Chính
                                                                                    sách Quyền riêng tư</a></span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""><img
                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NbM3Nyr77fPOiupqmiHDcc6ktxhIgsg0vznSDjfXk9IIZX3_DDLzI3WZHRBdbBY_YnLXAQm_LpTNGW_UJsOMfHLlHTvEtduHIu0A09Hna5b584BoHzW420iY5MMnKbtwAm1U37j1DmJnTT_66ldmILXpc1CII44z0RTyUrdEbb0QOBtZg=s0-d-e1-ft#http://cdn.mcauto-images-production.sendgrid.net/6c20475da3226ec8/e457af8c-5531-4df1-a265-127217b6d80a/8x8.png""
                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;width:4px;vertical-align:middle;margin:4px 16px""
                                                                                    width=""4"" class=""CToWUd""
                                                                                    data-bit=""iit""><a
                                                                                   
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle""
                                                                                    
                                                                                    >Hỗ
                                                                                    trợ</a></span><span
                                                                                style=""display:inline;vertical-align:middle;font-weight:800;font-size:12.64px;letter-spacing:0.08em;white-space:nowrap;font-family:inherit""><img
                                                                                    src=""https://ci3.googleusercontent.com/meips/ADKq_NbM3Nyr77fPOiupqmiHDcc6ktxhIgsg0vznSDjfXk9IIZX3_DDLzI3WZHRBdbBY_YnLXAQm_LpTNGW_UJsOMfHLlHTvEtduHIu0A09Hna5b584BoHzW420iY5MMnKbtwAm1U37j1DmJnTT_66ldmILXpc1CII44z0RTyUrdEbb0QOBtZg=s0-d-e1-ft#http://cdn.mcauto-images-production.sendgrid.net/6c20475da3226ec8/e457af8c-5531-4df1-a265-127217b6d80a/8x8.png""
                                                                                    style=""border:0;height:auto;line-height:100%;outline:none;text-decoration:none;width:4px;vertical-align:middle;margin:4px 16px""
                                                                                    width=""4"" class=""CToWUd""
                                                                                    data-bit=""iit""><a
                                                                                   
                                                                                    style=""text-decoration:none;text-transform:uppercase;color:#999;vertical-align:middle""
                                                                                 >Điều
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
                                                            align=""center""><span style=""font-family:inherit"">CineX Cinema, Trinh Van Bo Street, Nam Tu Liem, Ha Noi</span></td>
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
                                                                - bởi CineX Cinema.</span>
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

</html>
Đang hiển thị 3243575109743965752.";

                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(email.Trim());
                    mail.From = new MailAddress(_from, "Hệ thống hỗ trợ");
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
