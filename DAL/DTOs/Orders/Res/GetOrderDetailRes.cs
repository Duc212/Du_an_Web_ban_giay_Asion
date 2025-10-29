namespace DAL.DTOs.Orders.Res
{
    public class GetOrderDetailRes
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string? ShippingProvider { get; set; }
 
        public string? TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string VoucherCode { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Address { get; set; }
        public string Note { get; set; }
        public List<GetProductDetailRes> ListProduct { get; set; }
    }
}
