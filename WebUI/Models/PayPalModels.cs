namespace WebUI.Models
{
    public class PayPalCreateOrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? OrderId { get; set; }
    }

    public class PayPalCaptureResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public PayPalOrderRes? Data { get; set; }
    }

    public class PayPalOrderRes
    {
        public required string Id { get; set; }
        public required string Status { get; set; }
        public required string CheckoutPaymentIntent { get; set; }
        public required string CreateTime { get; set; }
        public required string ExpirationTime { get; set; }
        public required string UpdateTime { get; set; }
    }
}
