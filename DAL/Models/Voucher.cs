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
        [Required]
        [MaxLength(50)]
        public string VoucherCode { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0, 100000000, ErrorMessage = "DiscountValue must be >= 0")]
        public decimal DiscountValue { get; set; }
        [Required]
        [MaxLength(20)]
        public string DiscountType { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? MinOrderAmount { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? MaxDiscountAmount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
