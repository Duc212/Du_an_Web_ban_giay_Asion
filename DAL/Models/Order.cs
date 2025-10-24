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
        public int UserID { get; set; }
        public User? User { get; set; }

        public int? PaymentID { get; set; }
        public Payment? Payment { get; set; }

        public int? ShipmentID { get; set; }
        public Shipment? Shipment { get; set; }
        public int VoucherID { get; set; }
        public Voucher? Voucher { get; set; }

        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        // Navigation

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<ReturnRequest> ReturnRequests { get; set; } = new List<ReturnRequest>();
    }

}
