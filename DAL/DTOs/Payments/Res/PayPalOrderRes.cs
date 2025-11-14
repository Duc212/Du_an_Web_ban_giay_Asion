namespace DAL.DTOs.Payments.Res
{
    public class PayPalOrderRes
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string CheckoutPaymentIntent { get; set; }
        public string CreateTime { get; set; }
        public string ExpirationTime { get; set; }
        public string UpdateTime { get; set; }
    }
}
