using System.Text.Json.Serialization;

namespace WebUI.Models
{
    public class AddFavoriteProductReq
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
    }

    public class RemoveFavoriteProductReq
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
    }
}
