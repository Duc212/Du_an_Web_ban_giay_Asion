using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Orders.Req
{
    public class CreateOrderDetailsReq
    {
        // VariantID: Nếu có (user đã login và có cart API)
        public int VariantID { get; set; }
        
        // Alternative: Nếu không có VariantID (guest user), dùng ProductID + Color + Size
        public int? ProductID { get; set; }
        public string? SelectedColor { get; set; }
        public string? SelectedSize { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100000, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
