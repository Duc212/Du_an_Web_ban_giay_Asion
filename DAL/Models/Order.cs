using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }

        public int? ShipmentID { get; set; }
        public Shipment? Shipment { get; set; }
        public int? VoucherID { get; set; }
        public Voucher? Voucher { get; set; }
        [Required, MaxLength(50)]
        public string OrderType { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        [Required]
        [Range(0, 1000000000, ErrorMessage = "TotalAmount must be >= 0")]
        public decimal TotalAmount { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }
        [MaxLength(2000)]
        public string? Note { get; set; }

        // GHN Integration Fields
        [MaxLength(50)]
        public string? GhnOrderCode { get; set; }
        
        [MaxLength(50)]
        public string? GhnStatus { get; set; }
        
        public bool CodCollected { get; set; } = false;
        
        public int? GhnFee { get; set; }
        
        public DateTime? GhnCreatedAt { get; set; }
        
        public DateTime? GhnUpdatedAt { get; set; }

        // GHN Address Fields
        public int? GhnProvinceId { get; set; }
        
        public int? GhnDistrictId { get; set; }
        
        [MaxLength(20)]
        public string? GhnWardCode { get; set; }
        
        [MaxLength(500)]
        public string? GhnFullAddress { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<ReturnRequest> ReturnRequests { get; set; } = new List<ReturnRequest>();
        public ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();
    }
}
