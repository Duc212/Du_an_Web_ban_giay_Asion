using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Orders.Req
{
    public class CreateOrderReq
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

        public CreateShipmentReq? Shipment { get; set; }

        [Required(ErrorMessage = "OrderDetails is required")]
        public List<CreateOrderDetailsReq> OrderDetails { get; set; } = new();
    }
}
