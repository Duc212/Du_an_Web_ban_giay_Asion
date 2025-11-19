namespace DAL.DTOs.Orders.Res
{
    public class GetOrderAdminRes
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodText { get; set; }
        public int PaymentStatus { get; set; }
        public string PaymentStatusText { get; set; }
        public DateTime OrderDate { get; set; }
        public int ItemCount { get; set; }
        public string ShippingAddress { get; set; }
    }
}
