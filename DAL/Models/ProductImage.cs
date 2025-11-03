using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{

    public class ProductImage
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int ColorID { get; set; }

        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int DisplayOrder { get; set; } = 1;

        [Required]
        [MaxLength(20)]
        public string ImageType { get; set; } = "Main";

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public bool IsDefault { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Product? Product { get; set; }
        public Color? Color { get; set; }
    }
}