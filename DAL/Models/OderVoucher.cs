using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderVoucher
    {
        public int OrderVoucherID { get; set; }
        public int OrderID { get; set; }
        public int VoucherID { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool AppliedAll { get; set; }

        // Navigation
        public Order Order { get; set; }
        public Voucher Voucher { get; set; }
    }

}
