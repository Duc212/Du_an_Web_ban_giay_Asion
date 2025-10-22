using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
