using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int VariantID { get; set; }
        public int Quantity { get; set; }

        // Navigation
        public Order Order { get; set; }
        public ProductVariant Variant { get; set; }
        public ICollection<ReturnDetail> ReturnDetails { get; set; }
    }

}
