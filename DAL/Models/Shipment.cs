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
        [Required]
        [MaxLength(100)]
        public string ShippingProvider { get; set; }
        [Required]
        [MaxLength(100)]
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string DeliveryStatus { get; set; }

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
