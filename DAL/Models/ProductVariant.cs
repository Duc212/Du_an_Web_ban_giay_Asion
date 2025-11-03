using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ProductVariant
    {
        [Key]
        public int VariantID { get; set; }
        public int? ColorID { get; set; }
        public Color? Color { get; set; }
        public int? SizeID { get; set; }
        public Size? Size { get; set; }
        [Required]
        [Range(0, 1000000000, ErrorMessage = "ImportPrice must be >= 0")]
        public decimal ImportPrice { get; set; }
        [Required]
        [Range(0, 1000000000, ErrorMessage = "SellingPrice must be >= 0")]
        public decimal SellingPrice { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage = "StockQuantity must be >= 0")]
        public int StockQuantity { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Available";

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
