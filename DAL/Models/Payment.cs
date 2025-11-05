using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        
        public DateTime PaymentDate { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [MaxLength(100)]
        public string? TransactionID { get; set; }
        
        // Navigation
        public ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();
    }
}
