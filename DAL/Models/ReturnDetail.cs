using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReturnDetail
    {
        public int ReturnDetailID { get; set; }
        public int ReturnID { get; set; }
        public int OrderDetailID { get; set; }
        public int QuantityReturned { get; set; }
        public decimal RefundAmount { get; set; }

        // Navigation
        public ReturnRequest ReturnRequest { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }

}
