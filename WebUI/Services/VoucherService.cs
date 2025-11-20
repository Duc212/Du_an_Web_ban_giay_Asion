using System.Net.Http.Json;

namespace WebUI.Services
{
    public class VoucherService
    {
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;

        public VoucherService(HttpClient httpClient, ConfigurationService configService)
        {
            _httpClient = httpClient;
            _configService = configService;
        }

        public async Task<ValidateVoucherResponse?> ValidateVoucherAsync(string voucherCode, decimal orderAmount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(voucherCode))
                    return null;

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var request = new ValidateVoucherRequest
                {
                    VoucherCode = voucherCode.ToUpper().Trim(),
                    OrderAmount = orderAmount
                };

                var response = await _httpClient.PostAsJsonAsync($"{apiBaseUrl}/api/Voucher/ValidateVoucher", request);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ValidateVoucherApiResponse>();
                    return result?.Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[VoucherService] Error validating voucher: {ex.Message}");
                return null;
            }
        }
    }

    public class ValidateVoucherRequest
    {
        public string VoucherCode { get; set; }
        public decimal OrderAmount { get; set; }
    }

    public class ValidateVoucherResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public int? VoucherID { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public string DiscountType { get; set; }
        public decimal CalculatedDiscount { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
    }

    public class ValidateVoucherApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidateVoucherResponse Data { get; set; }
    }
}
