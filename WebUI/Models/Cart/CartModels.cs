namespace WebUI.Models.Cart
{
    /// <summary>
    /// Request để lấy thông tin giỏ hàng
    /// </summary>
    public class GetCartRequest
    {
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
    }

    /// <summary>
    /// Response chứa thông tin giỏ hàng
    /// </summary>
    public class GetCartResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public CartData? Data { get; set; }
    }

    /// <summary>
    /// Dữ liệu giỏ hàng đầy đủ
    /// </summary>
    public class CartData
    {
        public string CartId { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
        public List<CartItemDetail> Items { get; set; } = new();
        public CartSummary Summary { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

    /// <summary>
    /// Chi tiết từng item trong giỏ hàng
    /// </summary>
    public class CartItemDetail
    {
        public string ItemId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public string? ColorName { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public string ImageUrl { get; set; } = string.Empty;
        public bool InStock { get; set; } = true;
        public int StockQuantity { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Computed properties
        public bool HasDiscount => OriginalPrice.HasValue && OriginalPrice > Price;
        public decimal? DiscountAmount => HasDiscount ? (OriginalPrice!.Value - Price) * Quantity : null;
        public string? DiscountPercent => HasDiscount 
            ? $"-{(int)((OriginalPrice!.Value - Price) / OriginalPrice.Value * 100)}%" 
            : null;
    }

    /// <summary>
    /// Request để cập nhật số lượng cart item
    /// </summary>
    public class UpdateCartItemRequest
    {
        public string ItemId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
    }

    /// <summary>
    /// Request để xóa cart item
    /// </summary>
    public class RemoveCartItemRequest
    {
        public string ItemId { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
    }

    /// <summary>
    /// Request để xóa toàn bộ giỏ hàng
    /// </summary>
    public class ClearCartRequest
    {
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
    }

    /// <summary>
    /// Request để merge giỏ hàng (khi guest login)
    /// </summary>
    public class MergeCartRequest
    {
        public string UserId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
    }

    /// <summary>
    /// Generic response cho cart operations
    /// </summary>
    public class CartOperationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public CartSummary? CartSummary { get; set; }
    }
}
