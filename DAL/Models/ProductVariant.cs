using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = "Available";

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
        public List<Cart> Carts { get; set; } = new();
        public List<ReturnDetail> ReturnDetails { get; set; } = new();
    }
}
