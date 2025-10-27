using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs
{
    public class CreateShipmentDTO
    {
        [Required(ErrorMessage = "ShippingProvider is required")]
        [MaxLength(100)]
        public string ShippingProvider { get; set; }

        [Required(ErrorMessage = "TrackingNumber is required")]
        [MaxLength(100)]
        public string TrackingNumber { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required(ErrorMessage = "DeliveryStatus is required")]
        [MaxLength(50)]
        public string DeliveryStatus { get; set; } = "Pending";
    }
}
