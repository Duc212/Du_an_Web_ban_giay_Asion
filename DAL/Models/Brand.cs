using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [Required,Unicode(true),MaxLength(50)]
        public string Name { get; set; }
        [Unicode(true),MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>(); 
    }
}
