using System.ComponentModel.DataAnnotations;
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
        public int DeliveryStatus { get; set; }

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
