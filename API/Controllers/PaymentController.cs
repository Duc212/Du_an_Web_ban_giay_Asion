using BUS.Services.Interfaces;
using DAL.DTOs.Payments.Req;
using DAL.DTOs.Payments.Res;
using DAL.Entities;
using Helper.Utils;
using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Payments;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        /// <summary>
        /// Tạo URL thanh toán VNPay
        /// </summary>
        [HttpPost("vnpay/create-payment-url")]
        public async Task<ActionResult<CommonResponse<VNPayPaymentRes>>> CreateVNPayPaymentUrl([FromBody] VNPayPaymentReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new CommonResponse<VNPayPaymentRes>
                {
                    Success = false,
                    Message = "Dữ liệu không hợp lệ"
                });
            }

            // Lấy IP address của client
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";

            var result = await _paymentServices.CreateVNPayPaymentUrl(request, ipAddress);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Xử lý callback từ VNPay sau khi thanh toán
        /// </summary>
        [HttpGet("vnpay-return")]
        public async Task<IActionResult> VNPayReturn()
        {
            var queryParams = HttpContext.Request.Query;

            var result = await _paymentServices.ProcessVNPayReturn(queryParams);

            if (result.Success)
            {
                // Redirect về trang thành công trên frontend với orderId
                var returnUrl = $"https://localhost:7100/payment-success?transactionId={result.Data?.TransactionId}&amount={result.Data?.Amount}&orderId={result.Data?.OrderId}";
                return Redirect(returnUrl);
            }
            else
            {
                // Redirect về trang thất bại trên frontend
                var returnUrl = $"https://localhost:7100/payment-failed?message={Uri.EscapeDataString(result.Message ?? "Payment failed")}";
                return Redirect(returnUrl);
            }
        }

        /// <summary>
        /// IPN (Instant Payment Notification) - Webhook từ VNPay
        /// </summary>
        [HttpGet("vnpay-ipn")]
        public async Task<IActionResult> VNPayIPN()
        {
            var queryParams = HttpContext.Request.Query;

            var result = await _paymentServices.ProcessVNPayReturn(queryParams);

            if (result.Success)
            {
                return Ok(new { RspCode = "00", Message = "Confirm Success" });
            }

            return Ok(new { RspCode = "97", Message = "Checksum failed" });
        }
        [HttpPost]
        [Route("PayMentGpay")]
        public async Task<CommonResponse<string>> PaymentGPay(PaymentGPayReq request)
        {
            return await _paymentServices.PaymentGPay(request);
        }
        [HttpPost("CreatePayPal")]
        public async Task<CommonResponse<string>> CreateOrder([FromBody] PaymentPayPalReq request)
        {
            return await _paymentServices.CreateOrder(request.Amount, request.Currency);
        }

        [HttpPost("CapturePayPal")]
        public async Task<CommonResponse<PayPalOrderRes>> CaptureOrder([FromBody] CaptureReq request)
        {
            return await _paymentServices.CaptureOrder(request.OrderId);
        }
    }
}