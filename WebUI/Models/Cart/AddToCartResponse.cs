namespace WebUI.Models.Cart
{
    /// <summary>
    /// Response model từ API Add to Cart
    /// </summary>
    public class AddToCartResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ErrorCode { get; set; }
        public CartItemData? Data { get; set; }
        public CartSummary? CartSummary { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
    }

    /// <summary>
    /// Thông tin cart item vừa được thêm
    /// </summary>
    public class CartItemData
    {
        public string CartId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public string? ColorName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime AddedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Tóm tắt giỏ hàng sau khi thêm sản phẩm
    /// </summary>
    public class CartSummary
    {
        /// <summary>
        /// Tổng số loại sản phẩm khác nhau trong giỏ
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Tổng số lượng sản phẩm (bao gồm cả quantity)
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Tổng tiền trước giảm giá
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Số tiền giảm giá (nếu có)
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Tổng tiền sau giảm giá
        /// </summary>
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Phí vận chuyển (nếu có)
        /// </summary>
        public decimal? ShippingFee { get; set; }

        /// <summary>
        /// Tổng cuối cùng (bao gồm phí vận chuyển)
        /// </summary>
        public decimal GrandTotal => FinalAmount + (ShippingFee ?? 0);
    }
}
