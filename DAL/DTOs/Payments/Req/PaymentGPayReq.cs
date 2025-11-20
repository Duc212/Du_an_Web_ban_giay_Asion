namespace DAL.DTOs.Payments.Req
{
    public class PaymentGPayReq
    {
        public int OrderID { get; set; }
        public string Token { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Currency { get; set; } = "vnd";
        public string Description { get; set; } = "Google Pay Purchase";
    }
}
