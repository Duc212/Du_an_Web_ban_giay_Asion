using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required, Unicode(true), MaxLength(50)]
        public string Name { get; set; }
        [Unicode(true), MaxLength(250)]
        public string? Description { get; set; }
        [MaxLength(250)]
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
