using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs
{
    public class CreateOrderDetailsDTO
    {
        [Required(ErrorMessage = "VariantID is required")]
        public int VariantID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100000, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
