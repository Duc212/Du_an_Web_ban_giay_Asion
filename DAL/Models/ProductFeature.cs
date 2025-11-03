using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ProductFeature
    {
        [Key]
        public int FeatureID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FeatureName { get; set; } = string.Empty;


        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int DisplayOrder { get; set; } = 1;


        public bool IsActive { get; set; } = true;

        [MaxLength(50)]
        public string? IconClass { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Product? Product { get; set; }
    }
}