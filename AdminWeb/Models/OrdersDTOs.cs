namespace DAL.DTOs.Orders.Res;

public class GetOrderItemRes
{
    public string OrderItemId { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string SelectedSize { get; set; } = string.Empty;
    public string SelectedColor { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

public class GetOrderRes
{
    public string OrderId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string ReceiverName { get; set; } = string.Empty;
    public string ReceiverPhone { get; set; } = string.Empty;
    public string ReceiverEmail { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
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
    public List<GetOrderItemRes> Items { get; set; } = new();
}
