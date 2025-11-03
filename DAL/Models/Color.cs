using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Color
    {
        [Key]
        public int ColorID { get; set; }
        [Required, Unicode(true), MaxLength(30)]
        public string Name { get; set; }
        public string HexCode { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
