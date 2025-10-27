using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs
{
    public class CreateOrderDTO
    {
        [Required(ErrorMessage = "UserID is required")]
        public int UserID { get; set; }

        public int? PaymentID { get; set; }
        public int? VoucherID { get; set; }

        [Required(ErrorMessage = "OrderType is required")]
        [MaxLength(50)]
        public string OrderType { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(200)]
        public string? Note { get; set; }

        public CreateShipmentDTO? Shipment { get; set; }

        [Required(ErrorMessage = "OrderDetails is required")]
        public List<CreateOrderDetailsDTO> OrderDetails { get; set; } = new();
    }
}
