using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(300)]
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }

        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
