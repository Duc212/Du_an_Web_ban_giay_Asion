using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Carts.Req
{
    public class AddToCartReq
    {
        [Required(ErrorMessage = "ProductID is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "SelectedSize is required")]
        public string SelectedSize { get; set; } = string.Empty;

        [Required(ErrorMessage = "SelectedColor is required")]
        public string SelectedColor { get; set; } = string.Empty;
        public string? SessionId { get; set; }
    }
}