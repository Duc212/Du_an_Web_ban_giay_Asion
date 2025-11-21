using Azure.Core;
using BUS.Services.Interfaces;
using DAL.DTOs.Payments.Req;
using DAL.DTOs.Payments.Res;
using DAL.Entities;
using DAL.Enums;
using DAL.Models;
using DAL.RepositoryAsyns;
using Helper.Utils;
using Helper.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Stripe;
using System.Text.Json;
using PayPalOrder = PayPalCheckoutSdk.Orders.Order;

namespace BUS.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryAsync<DAL.Models.Order> _orderRepository;
        private readonly IRepositoryAsync<Payment> _paymentRepository;
        private readonly IRepositoryAsync<OrderPayment> _orderPaymentRepository;
        private readonly PayPalHttpClient _client;
        public PaymentServices(
      IConfiguration configuration,
       IRepositoryAsync<DAL.Models.Order> orderRepository,
         IRepositoryAsync<Payment> paymentRepository,
         IRepositoryAsync<OrderPayment> orderPaymentRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;
            _orderPaymentRepository = orderPaymentRepository;
            var environment = new SandboxEnvironment(
 _configuration["PayPal:ClientId"], // lấy từ appsettings
 _configuration["PayPal:ClientSecret"] // lấy từ appsettings
);

            _client = new PayPalHttpClient(environment);
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

        public async Task<CommonResponse<string>> PaymentGPay(PaymentGPayReq request)
        {
            var response = new CommonResponse<string>();
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            try
            {
                string tokenId = ExtractStripeTokenId(request.Token);
                var amount = GetStripeAmount(request.Amount, request.Currency);
                var currency = NormalizeCurrency(request.Currency);

                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = currency,
                    Description = request.Description ?? "Payment via GPay",
                    Source = tokenId,
                };

                var chargeService = new ChargeService();
                var charge = await chargeService.CreateAsync(options);

                if (charge.Status == "succeeded")
                {
                    // CẬP NHẬT ORDERPAYMENT KHI GPAY THÀNH CÔNG
                    if (request.OrderID > 0)
                    {
                        var orderPayment = await _orderPaymentRepository
                            .AsQueryable()
                            .FirstOrDefaultAsync(op => op.OrderID == request.OrderID);

                        if (orderPayment != null)
                        {
                            orderPayment.Status = (int)PaymentStatus.Paid;
                            await _orderPaymentRepository.UpdateAsync(orderPayment);
                        }
                    }

                    response.Success = true;
                    response.Message = "Thanh toán thành công";
                    response.Data = charge.Id;
                }
                else
                {
                    // CẬP NHẬT ORDERPAYMENT KHI GPAY THẤT BẠI
                    if (request.OrderID > 0)
                    {
                        var orderPayment = await _orderPaymentRepository
                            .AsQueryable()
                            .FirstOrDefaultAsync(op => op.OrderID == request.OrderID);

                        if (orderPayment != null)
                        {
                            orderPayment.Status = (int)PaymentStatus.Failed;
                            await _orderPaymentRepository.UpdateAsync(orderPayment);
                        }
                    }

                    response.Success = false;
                    response.Message = $"Thanh toán thất bại: {charge.Status}";
                }
            }
            catch (StripeException ex)
            {
                response.Success = false;
                response.Message = $"Stripe error: {ex.StripeError?.Message ?? ex.Message}";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi hệ thống: {ex.Message}";
            }

            return response;
        }

        private static string ExtractStripeTokenId(string token)
        {
            try
            {
                var jsonDoc = JsonDocument.Parse(token);
                if (jsonDoc.RootElement.TryGetProperty("id", out var idProp))
                {
                    return idProp.GetString() ?? token;
                }
            }
            catch { }
            return token;
        }

        private static long GetStripeAmount(long amount, string currency)
        {
            if ((currency?.ToLower() ?? "usd") == "usd")
                return amount * 100; // Stripe USD dùng cent
            return amount; // VND giữ nguyên
        }

        private static string NormalizeCurrency(string currency)
        {
            return (currency?.ToLower() == "vnd") ? "vnd" : "usd";
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

                // CẬP NHẬT TRẠNG THÁI ORDERPAYMENT
                if (!string.IsNullOrEmpty(vnpTxnRef) && int.TryParse(vnpTxnRef, out int orderId))
                {
                    // Tìm OrderPayment dựa trên OrderID
                    var orderPayment = await _orderPaymentRepository
                        .AsQueryable()
                        .Include(op => op.Payment)
                        .FirstOrDefaultAsync(op => op.OrderID == orderId);

                    if (orderPayment != null)
                    {
                        // Cập nhật trạng thái OrderPayment
                        if (isSuccess)
                        {
                            orderPayment.Status = (int)PaymentStatus.Paid;
                        }
                        else
                        {
                            orderPayment.Status = (int)PaymentStatus.Failed;
                        }

                        await _orderPaymentRepository.UpdateAsync(orderPayment);
                    }
                }

             

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

        public async Task<CommonResponse<string>> CreateOrder(decimal amount, string currency)
        {
            try
            {
                var request = new OrdersCreateRequest();
                request.Prefer("return=representation");
                request.RequestBody(new OrderRequest
                {
                    CheckoutPaymentIntent = "CAPTURE",
                    PurchaseUnits = new List<PurchaseUnitRequest>
            {
                new PurchaseUnitRequest
                {
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        CurrencyCode = currency ?? "USD", // Sử dụng currency truyền vào
                        Value = amount.ToString("F2") 
                    }
                }
            }
                });

                var response = await _client.Execute(request);
                var result = response.Result<PayPalOrder>();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Tạo đơn hàng thành công",
                    Data = result.Id
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo đơn hàng: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<PayPalOrderRes>> CaptureOrder(string orderId)
        {
            try
            {
                var request = new OrdersCaptureRequest(orderId);
                request.RequestBody(new OrderActionRequest());
                var response = await _client.Execute(request);
                var result = response.Result<PayPalOrder>();

                var dto = new PayPalOrderRes
                {
                    Id = result.Id,
                    Status = result.Status,
                    CheckoutPaymentIntent = result.CheckoutPaymentIntent,
                    CreateTime = result.CreateTime,
                    ExpirationTime = result.ExpirationTime,
                    UpdateTime = result.UpdateTime
                };

                return new CommonResponse<PayPalOrderRes>
                {
                    Success = true,
                    Message = "Thanh toán thành công",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<PayPalOrderRes>
                {
                    Success = false,
                    Message = $"Lỗi khi xác nhận đơn hàng: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<CommonResponse<PayPalOrderRes>> CaptureOrderWithUpdate(CaptureReq captureReq)
        {
            try
            {
                var request = new OrdersCaptureRequest(captureReq.OrderId);
                request.RequestBody(new OrderActionRequest());
                var response = await _client.Execute(request);
                var result = response.Result<PayPalOrder>();

                // CẬP NHẬT ORDERPAYMENT KHI PAYPAL THÀNH CÔNG
                if (captureReq.SystemOrderID > 0 && result.Status == "COMPLETED")
                {
                    var orderPayment = await _orderPaymentRepository
                        .AsQueryable()
                        .FirstOrDefaultAsync(op => op.OrderID == captureReq.SystemOrderID);

                    if (orderPayment != null)
                    {
                        orderPayment.Status = (int)PaymentStatus.Paid;
                        await _orderPaymentRepository.UpdateAsync(orderPayment);
                    }
                }

                var dto = new PayPalOrderRes
                {
                    Id = result.Id,
                    Status = result.Status,
                    CheckoutPaymentIntent = result.CheckoutPaymentIntent,
                    CreateTime = result.CreateTime,
                    ExpirationTime = result.ExpirationTime,
                    UpdateTime = result.UpdateTime
                };

                return new CommonResponse<PayPalOrderRes>
                {
                    Success = true,
                    Message = "Thanh toán thành công",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<PayPalOrderRes>
                {
                    Success = false,
                    Message = $"Lỗi khi xác nhận đơn hàng: {ex.Message}",
                    Data = null
                };
            }
        }


    }
}
