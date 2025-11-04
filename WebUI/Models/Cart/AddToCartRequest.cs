using System.Text.Json.Serialization;

namespace WebUI.Models.Cart
{
    /// <summary>
    /// Request model để thêm sản phẩm vào giỏ hàng
    /// Match với API backend: POST /api/Cart/AddToCart
    /// </summary>
    public class AddToCartRequest
    {
        /// <summary>
        /// ID sản phẩm - Bắt buộc
        /// </summary>
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        /// <summary>
        /// Số lượng - Bắt buộc, min = 1
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// Size được chọn (nếu sản phẩm có size)
        /// </summary>
        [JsonPropertyName("selectedSize")]
        public string? SelectedSize { get; set; }

        /// <summary>
        /// Màu được chọn dưới dạng hex code hoặc tên màu
        /// </summary>
        [JsonPropertyName("selectedColor")]
        public string? SelectedColor { get; set; }

        /// <summary>
        /// Session ID (cho guest user chưa đăng nhập)
        /// Backend sẽ tạo session nếu chưa có
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string? SessionId { get; set; }

        // Optional fields - không bắt buộc cho API
        /// <summary>
        /// Tên màu dễ đọc (optional, để hiển thị)
        /// </summary>
        [JsonPropertyName("colorName")]
        public string? ColorName { get; set; }

        /// <summary>
        /// User ID (nếu đã đăng nhập) - thường lấy từ JWT token
        /// </summary>
        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        /// <summary>
        /// Tên sản phẩm (cache - không cần gửi lên API)
        /// </summary>
        [JsonIgnore]
        public string? ProductName { get; set; }

        /// <summary>
        /// Giá sản phẩm (cache - không cần gửi lên API)
        /// </summary>
        [JsonIgnore]
        public decimal? Price { get; set; }

        /// <summary>
        /// URL ảnh sản phẩm (cache - không cần gửi lên API)
        /// </summary>
        [JsonIgnore]
        public string? ImageUrl { get; set; }
    }
}
