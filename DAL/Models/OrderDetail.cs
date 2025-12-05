using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order? Order { get; set; }

        public int VariantID { get; set; }
        public ProductVariant? Variant { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        
        // Snapshot giá tại thời điểm đặt hàng
        [Required]
        public decimal UnitPrice { get; set; }

    }

}
