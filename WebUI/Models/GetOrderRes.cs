using System.Text.Json.Serialization;

namespace WebUI.Models
{
    /// <summary>
    /// Response từ API GET /api/Orders/GetListOrderByUser
    /// </summary>
    public class GetOrderRes
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; } = string.Empty;

        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("receiverName")]
        public string ReceiverName { get; set; } = string.Empty;

        [JsonPropertyName("receiverPhone")]
        public string ReceiverPhone { get; set; } = string.Empty;

        [JsonPropertyName("receiverEmail")]
        public string ReceiverEmail { get; set; } = string.Empty;

        [JsonPropertyName("shippingAddress")]
        public string ShippingAddress { get; set; } = string.Empty;

        [JsonPropertyName("ward")]
        public string Ward { get; set; } = string.Empty;

        [JsonPropertyName("district")]
        public string District { get; set; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("paymentMethod")]
        public int PaymentMethod { get; set; }

        [JsonPropertyName("paymentStatus")]
        public int PaymentStatus { get; set; }

        [JsonPropertyName("subTotal")]
        public decimal SubTotal { get; set; }

        [JsonPropertyName("shippingFee")]
        public decimal ShippingFee { get; set; }

        [JsonPropertyName("discount")]
        public decimal Discount { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("items")]
        public List<GetOrderItemRes> Items { get; set; } = new();

        // GHN Tracking
        [JsonPropertyName("ghnOrderCode")]
        public string? GhnOrderCode { get; set; }

        [JsonPropertyName("ghnStatus")]
        public string? GhnStatus { get; set; }

        [JsonPropertyName("ghnFee")]
        public int? GhnFee { get; set; }

        [JsonPropertyName("codCollected")]
        public bool CodCollected { get; set; }

        // Computed
        public string FullAddress => $"{ShippingAddress}, {Ward}, {District}, {City}";
    }

    public class GetOrderItemRes
    {
        [JsonPropertyName("orderItemId")]
        public string OrderItemId { get; set; } = string.Empty;

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("selectedSize")]
        public string? SelectedSize { get; set; }

        [JsonPropertyName("selectedColor")]
        public string? SelectedColor { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        public decimal TotalPrice => Price * Quantity;
    }
}
