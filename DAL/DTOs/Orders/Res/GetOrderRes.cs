namespace DAL.DTOs.Orders.Res
{
    public class GetOrderRes
    {
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string UserId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public string ShippingAddress { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public int Status { get; set; }
        public int PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Note { get; set; }
        public List<GetOrderItemRes> Items { get; set; }
    }
}
