using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Orders.Req
{
    public class UpdateStatusOrderReq
    {
        [Required(ErrorMessage = "OrderId là bắt buộc.")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Trạng thái đơn hàng là bắt buộc.")]
        public OrderStatusEnums Status { get; set; }
    }
}
