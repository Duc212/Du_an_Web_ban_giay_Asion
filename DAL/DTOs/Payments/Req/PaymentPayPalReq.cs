namespace DAL.DTOs.Payments.Req
{
    public class PaymentPayPalReq
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
    public class CaptureReq
    {
        public string OrderId { get; set; }
    }

}
