namespace DAL.DTOs.Orders.Res
{
    public class GetOrderDetailAdminRes
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }

        public CustomerInfo Customer { get; set; }
        public ShippingInfo ShippingInfo { get; set; }
        public PaymentInfo Payment { get; set; }
        public ShipmentInfo Shipment { get; set; }
        public VoucherInfo Voucher { get; set; }
        public List<OrderItemInfo> Items { get; set; } = new List<OrderItemInfo>();
        public OrderSummary Summary { get; set; }
        public string Note { get; set; }
    }

    public class CustomerInfo
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ShippingInfo
    {
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string Address { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public string Note { get; set; }
    }

    public class PaymentInfo
    {
        public int PaymentMethod { get; set; }
        public string PaymentMethodText { get; set; }
        public int PaymentStatus { get; set; }
        public string PaymentStatusText { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class ShipmentInfo
    {
        public string ShippingProvider { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public int DeliveryStatus { get; set; }
    }

    public class VoucherInfo
    {
        public string VoucherCode { get; set; }
        public decimal DiscountValue { get; set; }
    }

    public class OrderItemInfo
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class OrderSummary
    {
        public decimal Subtotal { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
