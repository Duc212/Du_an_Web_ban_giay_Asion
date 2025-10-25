using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Size
    {
        [Key]
        public int SizeID { get; set; }
        [Required,Range(30,60,ErrorMessage ="Size Value from 30 to 60 ")]
        public string Value { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
