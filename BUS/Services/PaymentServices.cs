using BUS.Services.Interfaces;
using DAL.DTOs.Payments.Req;
using DAL.DTOs.Payments.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Helper.Utils;
using Helper.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BUS.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryAsync<Order> _orderRepository;
        private readonly IRepositoryAsync<Payment> _paymentRepository;

        public PaymentServices(
      IConfiguration configuration,
       IRepositoryAsync<Order> orderRepository,
         IRepositoryAsync<Payment> paymentRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<CommonResponse<VNPayPaymentRes>> CreateVNPayPaymentUrl(VNPayPaymentReq request, string ipAddress)
        {
            try
            {
                // Kiểm tra order tồn tại
                var order = await _orderRepository.AsNoTrackingQueryable()
    .FirstOrDefaultAsync(o => o.OrderID == request.OrderID);

                if (order == null)
                {
                    return new CommonResponse<VNPayPaymentRes>
                    {
                        Success = false,
                        Message = "Đơn hàng không tồn tại"
                    };
                }

                // Lấy cấu hình VNPay
                var vnpayConfig = _configuration.GetSection("VNPay");
                var tmnCode = vnpayConfig["TmnCode"];
                var hashSecret = vnpayConfig["HashSecret"];
                var paymentUrl = vnpayConfig["PaymentUrl"];
                var returnUrl = vnpayConfig["ReturnUrl"];

                var vnpay = new VNPayLibrary();
                var tick = DateTime.Now.Ticks.ToString();

                // Thông tin thanh toán
                vnpay.AddRequestData("vnp_Version", vnpayConfig["Version"]);
                vnpay.AddRequestData("vnp_Command", vnpayConfig["Command"]);
                vnpay.AddRequestData("vnp_TmnCode", tmnCode);
                vnpay.AddRequestData("vnp_Amount", ((long)(request.Amount * 100)).ToString());
                vnpay.AddRequestData("vnp_BankCode", ""); // Để trống để hiển thị tất cả ngân hàng
                vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", vnpayConfig["CurrCode"]);
                vnpay.AddRequestData("vnp_IpAddr", ipAddress);
                vnpay.AddRequestData("vnp_Locale", vnpayConfig["Locale"]);
                vnpay.AddRequestData("vnp_OrderInfo", request.OrderInfo ?? $"Thanh toan don hang {order.OrderCode}");
                vnpay.AddRequestData("vnp_OrderType", "other");
                vnpay.AddRequestData("vnp_ReturnUrl", returnUrl);
                vnpay.AddRequestData("vnp_TxnRef", tick);

                var paymentUrlResult = vnpay.CreateRequestUrl(paymentUrl, hashSecret);

                return new CommonResponse<VNPayPaymentRes>
                {
                    Success = true,
                    Message = "Tạo URL thanh toán thành công",
                    Data = new VNPayPaymentRes
                    {
                        Success = true,
                        PaymentUrl = paymentUrlResult
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<VNPayPaymentRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<VNPayReturnRes>> ProcessVNPayReturn(IQueryCollection queryParams)
        {
            try
            {
                var vnpay = new VNPayLibrary();

                // Đọc dữ liệu trả về từ VNPay
                foreach (var (key, value) in queryParams)
                {
                    if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(key, value.ToString());
                    }
                }

                var vnpSecureHash = queryParams["vnp_SecureHash"];
                var hashSecret = _configuration["VNPay:HashSecret"];

                // Kiểm tra chữ ký
                if (!vnpay.ValidateSignature(vnpSecureHash, hashSecret))
                {
                    return new CommonResponse<VNPayReturnRes>
                    {
                        Success = false,
                        Message = "Chữ ký không hợp lệ",
                        Data = new VNPayReturnRes { Success = false, Message = "Invalid signature" }
                    };
                }

                var vnpTxnRef = vnpay.GetResponseData("vnp_TxnRef");
                var vnpTransactionNo = vnpay.GetResponseData("vnp_TransactionNo");
                var vnpResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                var vnpAmount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                var vnpBankCode = vnpay.GetResponseData("vnp_BankCode");
                var vnpPayDate = vnpay.GetResponseData("vnp_PayDate");
                var vnpOrderInfo = vnpay.GetResponseData("vnp_OrderInfo");

                // Xử lý kết quả thanh toán
                var isSuccess = vnpResponseCode == "00";
                string message;

                switch (vnpResponseCode)
                {
                    case "00":
                        message = "Giao dịch thành công";
                        break;
                    case "07":
                        message = "Trừ tiền thành công. Giao dịch bị nghi ngờ (liên quan tới lừa đảo, giao dịch bất thường)";
                        break;
                    case "09":
                        message = "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng chưa đăng ký dịch vụ InternetBanking tại ngân hàng";
                        break;
                    case "10":
                        message = "Giao dịch không thành công do: Khách hàng xác thực thông tin thẻ/tài khoản không đúng quá 3 lần";
                        break;
                    case "11":
                        message = "Giao dịch không thành công do: Đã hết hạn chờ thanh toán";
                        break;
                    case "12":
                        message = "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng bị khóa";
                        break;
                    case "13":
                        message = "Giao dịch không thành công do Quý khách nhập sai mật khẩu xác thực giao dịch (OTP)";
                        break;
                    case "24":
                        message = "Giao dịch không thành công do: Khách hàng hủy giao dịch";
                        break;
                    case "51":
                        message = "Giao dịch không thành công do: Tài khoản của quý khách không đủ số dư để thực hiện giao dịch";
                        break;
                    case "65":
                        message = "Giao dịch không thành công do: Tài khoản của Quý khách đã vượt quá hạn mức giao dịch trong ngày";
                        break;
                    case "75":
                        message = "Ngân hàng thanh toán đang bảo trì";
                        break;
                    case "79":
                        message = "Giao dịch không thành công do: KH nhập sai mật khẩu thanh toán quá số lần quy định";
                        break;
                    default:
                        message = "Giao dịch thất bại";
                        break;
                }

                // Lưu thông tin thanh toán vào database
                var payment = new Payment
                {
                    Amount = vnpAmount,
                    PaymentMethod = "VNPay",
                    PaymentStatus = isSuccess ? "Completed" : "Failed",
                    TransactionID = vnpTransactionNo,
                    PaymentDate = DateTime.ParseExact(vnpPayDate, "yyyyMMddHHmmss", null)
                };

                await _paymentRepository.AddAsync(payment);
                await _paymentRepository.SaveChangesAsync();

                // TODO: Tạo liên kết OrderPayment giữa Order và Payment
                // TODO: Cập nhật trạng thái đơn hàng nếu thanh toán thành công

                return new CommonResponse<VNPayReturnRes>
                {
                    Success = isSuccess,
                    Message = message,
                    Data = new VNPayReturnRes
                    {
                        Success = isSuccess,
                        TransactionId = vnpTransactionNo,
                        OrderId = vnpOrderInfo,
                        Amount = vnpAmount,
                        BankCode = vnpBankCode,
                        PayDate = vnpPayDate,
                        Message = message,
                        ResponseCode = vnpResponseCode
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<VNPayReturnRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }
    }
}
