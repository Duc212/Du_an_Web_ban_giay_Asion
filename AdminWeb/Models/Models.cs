namespace AdminWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ImageUrl { get; set; } = "";
        public List<string> Images { get; set; } = new();
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string Brand { get; set; } = "";
        public int Stock { get; set; }
        public List<string> Sizes { get; set; } = new();
        public List<string> Colors { get; set; } = new();
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; }
        public int SoldCount { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int ProductCount { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = "";
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerEmail { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public string ShippingAddress { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public List<OrderItem> Items { get; set; } = new();
        public string Note { get; set; } = "";
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ProductImage { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; } = "";
        public string Color { get; set; } = "";
        public decimal Subtotal => Price * Quantity;
    }

    public enum OrderStatus
    {
        Pending,        // Chờ xác nhận
        Confirmed,      // Đã xác nhận
        Processing,     // Đang xử lý
        Shipping,       // Đang giao hàng
        Delivered,      // Đã giao hàng
        Cancelled,      // Đã hủy
        Returned        // Đã trả hàng
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string AvatarUrl { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public string MembershipLevel { get; set; } = "Silver";
        public bool IsActive { get; set; } = true;
    }
}
