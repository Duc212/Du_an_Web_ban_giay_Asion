using System.Text.Json.Serialization;

namespace WebUI.Models.Cart
{
    /// <summary>
    /// Cart item từ API backend
    /// </summary>
    public class CartItemResponse
    {
        [JsonPropertyName("cartItemID")]
        public int CartItemID { get; set; }

        [JsonPropertyName("productID")]
        public int ProductID { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonPropertyName("color")]
        public string Color { get; set; } = string.Empty;

        [JsonPropertyName("colorHex")]
        public string ColorHex { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public string Size { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("totalPrice")]
        public decimal TotalPrice => Price * Quantity;

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("images")]
        public List<string> Images { get; set; } = new();

        [JsonPropertyName("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("variantID")]
        public int VariantID { get; set; }

        [JsonPropertyName("priceFormatted")]
        public string PriceFormatted => $"{Price:N0}đ";

        [JsonPropertyName("totalPriceFormatted")]
        public string TotalPriceFormatted => $"{TotalPrice:N0}đ";
    }

    /// <summary>
    /// Cart summary từ API backend
    /// </summary>
    public class CartSummaryResponse
    {
        [JsonPropertyName("cartID")]
        public int CartID { get; set; }

        [JsonPropertyName("items")]
        public List<CartItemResponse> Items { get; set; } = new();

        [JsonPropertyName("totalItems")]
        public int TotalItems => Items.Sum(x => x.Quantity);

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

        [JsonPropertyName("totalAmountFormatted")]
        public string TotalAmountFormatted => $"{TotalAmount:N0}đ";

        [JsonPropertyName("uniqueProductCount")]
        public int UniqueProductCount => Items.Count;
    }
}
