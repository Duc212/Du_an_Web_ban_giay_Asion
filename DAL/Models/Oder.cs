using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int? PaymentID { get; set; }
        public int? ShipmentID { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        // Navigation
        public User User { get; set; }
        public Payment Payment { get; set; }
        public Shipment Shipment { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ReturnRequest> ReturnRequests { get; set; }
        public ICollection<OrderVoucher> OrderVouchers { get; set; }
    }

}
