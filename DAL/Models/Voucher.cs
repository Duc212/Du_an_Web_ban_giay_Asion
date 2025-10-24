using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public string DiscountType { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
