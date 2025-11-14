using System.Net.Http.Json;
using System.Text.Json;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    public interface IPaymentService
    {
        Task<VNPayPaymentResponse> CreateVNPayPaymentUrlAsync(int orderId, decimal amount, string? orderInfo = null);
        Task<PaymentGPayResponse> CreateGPayPaymentAsync(PaymentGPayRequest request);
        Task<CommonResponse<string>> CreatePayPal(PaymentPayPalReq request);
        Task<CommonResponse<PayPalOrderRes>> CapturePayPal(CaptureReq request);

    }

    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;
        private readonly IAuthService _authService;

        public PaymentService(HttpClient httpClient, ConfigurationService configService, IAuthService authService)
        {
            _httpClient = httpClient;
            _configService = configService;
            _authService = authService;
        }

        public async Task<VNPayPaymentResponse> CreateVNPayPaymentUrlAsync(int orderId, decimal amount, string? orderInfo = null)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var request = new VNPayPaymentRequest
                {
                    OrderID = orderId,
                    Amount = amount,
                    OrderInfo = orderInfo ?? $"Thanh toan don hang #{orderId}"
                };

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Payment/vnpay/create-payment-url")
                {
                    Content = JsonContent.Create(request)
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[PaymentService] CreateVNPayPaymentUrl Response: {response.StatusCode}");
                Console.WriteLine($"[PaymentService] Response Body: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<WebUI.Models.CommonResponse<VNPayPaymentData>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                    {
                        return new VNPayPaymentResponse
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Tạo URL thanh toán thành công",
                            PaymentUrl = apiResponse.Data.PaymentUrl
                        };
                    }
                }

                return new VNPayPaymentResponse
                {
                    Success = false,
                    Message = $"Không thể tạo URL thanh toán: {responseContent}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaymentService] Exception in CreateVNPayPaymentUrlAsync: {ex.Message}");
                return new VNPayPaymentResponse
                {
                    Success = false,
                    Message = $"Lỗi khi tạo URL thanh toán: {ex.Message}"
                };
            }
        }

        public async Task<PaymentGPayResponse> CreateGPayPaymentAsync(PaymentGPayRequest request)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Payment/PayMentGpay")
                {
                    Content = JsonContent.Create(request)
                };
                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }
                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<CommonResponse<string>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                    return new PaymentGPayResponse
                    {
                        Success = apiResponse?.Success ?? false,
                        Message = apiResponse?.Message ?? "",
                        TransactionId = apiResponse?.Data
                    };
                }
                return new PaymentGPayResponse
                {
                    Success = false,
                    Message = $"Không thể thanh toán GPay: {responseContent}"
                };
            }
            catch (Exception ex)
            {
                return new PaymentGPayResponse
                {
                    Success = false,
                    Message = $"Lỗi khi thanh toán GPay: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<string>> CreatePayPal(PaymentPayPalReq request)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Payment/CreatePayPal")
                {
                    Content = JsonContent.Create(request)
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[PaymentService] CreatePayPal Response: {response.StatusCode}");
                Console.WriteLine($"[PaymentService] Response Body: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<CommonResponse<string>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (apiResponse != null && apiResponse.Success)
                    {
                        return new CommonResponse<string>
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Tạo order PayPal thành công",
                            Data = apiResponse.Data
                        };
                    }
                }

                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Không thể tạo order PayPal: {responseContent}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaymentService] Exception in CreatePayPal: {ex.Message}");
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi khi tạo order PayPal: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<PayPalOrderRes>> CapturePayPal(CaptureReq request)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Payment/CapturePayPal")
                {
                    Content = JsonContent.Create(request)
                };

                if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[PaymentService] CapturePayPal Response: {response.StatusCode}");
                Console.WriteLine($"[PaymentService] Response Body: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<CommonResponse<PayPalOrderRes>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (apiResponse != null && apiResponse.Success)
                    {
                        return new CommonResponse<PayPalOrderRes>
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Capture PayPal thành công",
                            Data = apiResponse.Data
                        };
                    }
                }

                return new CommonResponse<PayPalOrderRes>
                {
                    Success = false,
                    Message = $"Không thể capture PayPal: {responseContent}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaymentService] Exception in CapturePayPal: {ex.Message}");
                return new CommonResponse<PayPalOrderRes>
                {
                    Success = false,
                    Message = $"Lỗi khi capture PayPal: {ex.Message}"
                };
            }
        }

    }

    // Models for VNPay Payment
    public class VNPayPaymentRequest
    {
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public string? OrderInfo { get; set; }
    }

    public class VNPayPaymentResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? PaymentUrl { get; set; }
    }

    public class VNPayPaymentData
    {
        public bool Success { get; set; }
        public string PaymentUrl { get; set; } = string.Empty;
        public string? Message { get; set; }
    }

    // Models for Google Pay Payment
    public class PaymentGPayRequest
    {
        public string Token { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Currency { get; set; } = "vnd";
        public string Description { get; set; } = "Google Pay Purchase";
    }

    public class PaymentGPayResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? TransactionId { get; set; }
    }
    public class PaymentPayPalReq
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
    }
    public class CaptureReq
    {
        public string? OrderId { get; set; }
    }
    public class PayPalOrderRes
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
        public string? CheckoutPaymentIntent { get; set; }
        public string? CreateTime { get; set; }
        public string? ExpirationTime { get; set; }
        public string? UpdateTime { get; set; }
    }
}

