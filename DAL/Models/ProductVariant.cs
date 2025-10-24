using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = "Available";

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
