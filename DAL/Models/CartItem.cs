using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int VariantID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public  Cart? Cart { get; set; }
        public  ProductVariant? ProductVariant { get; set; }
    }
}
