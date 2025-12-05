namespace WebUI.Models
{
    /// <summary>
    /// Request để tạo đơn hàng mới theo API backend
    /// </summary>
    public class CreateOrderRequest
    {
        public int UserID { get; set; }
        public int PaymentID { get; set; }
        public int? VoucherID { get; set; } = null;
        public string OrderType { get; set; } = "online";
        public string Address { get; set; } = string.Empty;
        public string? Note { get; set; }
        public List<OrderDetailRequest> OrderDetails { get; set; } = new();
        
        // GHN Address Fields
        public int? GhnProvinceId { get; set; }
        public int? GhnDistrictId { get; set; }
        public string? GhnWardCode { get; set; }
        public string? GhnFullAddress { get; set; }
    }

    /// <summary>
    /// Chi tiết sản phẩm trong đơn hàng
    /// </summary>
    public class OrderDetailRequest
    {
        // VariantID: Nếu có (user đã login và có cart API)
        public int VariantID { get; set; }
        
        // Alternative: Nếu không có VariantID (guest user), dùng ProductID + Color + Size
        public int? ProductID { get; set; }
        public string? SelectedColor { get; set; }
        public string? SelectedSize { get; set; }
        
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Model mở rộng để lưu thông tin UI (không gửi lên API)
    /// </summary>
    public class CreateOrderUIModel
    {
        // Thông tin người nhận
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverPhone { get; set; } = string.Empty;
        public string ReceiverEmail { get; set; } = string.Empty;

        // Địa chỉ giao hàng
        public string ShippingAddress { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        // Thông tin đơn hàng
        public List<OrderItemUI> Items { get; set; } = new();
        public string? Note { get; set; }
        public string PaymentMethod { get; set; } = "cod"; // cod, card, wallet, transfer
        public string ShippingMethod { get; set; } = "standard"; // standard, express, super
        public decimal ShippingFee { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public string? CouponCode { get; set; }
    }

    /// <summary>
    /// Thông tin sản phẩm cho UI
    /// </summary>
    public class OrderItemUI
    {
        public int ProductId { get; set; }
        public int VariantID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }

    /// <summary>
    /// Response sau khi tạo đơn hàng
    /// </summary>
    public class CreateOrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public OrderData? Data { get; set; }
    }

    /// <summary>
    /// Thông tin đơn hàng đã tạo
    /// </summary>
    public class OrderData
    {
        public string OrderId { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? PaymentUrl { get; set; } // Nếu thanh toán online
    }

    /// <summary>
    /// Model đầy đủ của đơn hàng
    /// </summary>
    public class Order
    {
        public string OrderId { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        
        // Thông tin người nhận
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverPhone { get; set; } = string.Empty;
        public string ReceiverEmail { get; set; } = string.Empty;
        
        // Địa chỉ giao hàng
        public string ShippingAddress { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        
        // Thông tin đơn hàng
        public List<OrderItem> Items { get; set; } = new();
        public string Status { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        
        // Giá tiền
        public decimal SubTotal { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string FullAddress => $"{ShippingAddress}, {Ward}, {District}, {City}";
    }

    /// <summary>
    /// Sản phẩm trong đơn hàng
    /// </summary>
    public class OrderItem
    {
        public string OrderItemId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }

    /// <summary>
    /// Shipping method options
    /// </summary>
    public class ShippingOption
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
