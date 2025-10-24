using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public string ShippingProvider { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string DeliveryStatus { get; set; }

        // Navigation
        public Order? Order { get; set; }
    }

}
