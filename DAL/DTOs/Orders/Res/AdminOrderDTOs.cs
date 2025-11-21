namespace DAL.DTOs.Orders.Res;

// Admin Order Management DTOs

public class AdminOrderListItem
{
    public int OrderID { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; } = string.Empty;
    public int PaymentMethod { get; set; }
    public string PaymentMethodText { get; set; } = string.Empty;
    public int PaymentStatus { get; set; }
    public string PaymentStatusText { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public int ItemCount { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
}

public class OrderCustomerInfo
{
    public int UserID { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

public class OrderShippingInfo
{
    public string ReceiverName { get; set; } = string.Empty;
    public string ReceiverPhone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Ward { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string FullAddress { get; set; } = string.Empty;
    public string? Note { get; set; }
}

public class OrderPaymentInfo
{
    public int PaymentMethod { get; set; }
    public string PaymentMethodText { get; set; } = string.Empty;
    public int PaymentStatus { get; set; }
    public string PaymentStatusText { get; set; } = string.Empty;
    public DateTime? PaidAt { get; set; }
}

public class OrderShipmentInfo
{
    public string? ShippingProvider { get; set; }
    public string? TrackingNumber { get; set; }
    public DateTime? ShippedDate { get; set; }
    public DateTime? EstimatedDelivery { get; set; }
    public int DeliveryStatus { get; set; }
    
    // GHN Integration
    public string? GhnOrderCode { get; set; }
    public string? GhnStatus { get; set; }
    public int? GhnFee { get; set; }
    public bool CodCollected { get; set; }
    public DateTime? GhnCreatedAt { get; set; }
    public DateTime? GhnUpdatedAt { get; set; }
}

public class OrderVoucherInfo
{
    public string? VoucherCode { get; set; }
    public decimal DiscountValue { get; set; }
}

public class OrderItemDetail
{
    public int OrderDetailID { get; set; }
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public string SizeName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}

public class OrderStatusHistory
{
    public int Status { get; set; }
    public string StatusText { get; set; } = string.Empty;
    public DateTime ChangedAt { get; set; }
    public string? Note { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
}

public class AdminOrderDetail
{
    public int OrderID { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; } = string.Empty;
    public List<OrderStatusHistory> StatusHistory { get; set; } = new();
    public OrderCustomerInfo Customer { get; set; } = new();
    public OrderShippingInfo ShippingInfo { get; set; } = new();
    public OrderPaymentInfo Payment { get; set; } = new();
    public OrderShipmentInfo Shipment { get; set; } = new();
    public OrderVoucherInfo? Voucher { get; set; }
    public List<OrderItemDetail> Items { get; set; } = new();
    public OrderSummary Summary { get; set; } = new();
    public string? Note { get; set; }
}

public class OrderStatistics
{
    public int TotalOrders { get; set; }
    public int PendingOrders { get; set; }
    public int ConfirmedOrders { get; set; }
    public int ProcessingOrders { get; set; }
    public int ShippingOrders { get; set; }
    public int DeliveredOrders { get; set; }
    public int CancelledOrders { get; set; }
    public int ReturnedOrders { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal AverageOrderValue { get; set; }
}

// Request DTOs
public class UpdateOrderStatusRequest
{
    public int OrderID { get; set; }
    public int NewStatus { get; set; }
    public string? Note { get; set; }
}

public class ConfirmOrderResponse
{
    public string TrackingNumber { get; set; } = string.Empty;
    public int ShipmentID { get; set; }
}

public class ConfirmOrderRequest
{
    public int OrderID { get; set; }
    public string ShippingProvider { get; set; } = string.Empty;
    public DateTime EstimatedDelivery { get; set; }
    public string? Note { get; set; }
}

public class CancelOrderRequest
{
    public int OrderID { get; set; }
    public string CancelReason { get; set; } = string.Empty;
    public bool RefundRequired { get; set; }
}

public class UpdatePaymentStatusRequest
{
    public int OrderID { get; set; }
    public int PaymentStatus { get; set; }
    public string? Note { get; set; }
}

public class UpdateShippingInfoRequest
{
    public int OrderID { get; set; }
    public string ShippingProvider { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public DateTime? ShippedDate { get; set; }
    public DateTime? EstimatedDelivery { get; set; }
    public string? Note { get; set; }
}
