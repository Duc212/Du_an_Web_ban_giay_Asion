using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Payments.Req
{
    public class VNPayPaymentReq
    {
        [Required]
     public int OrderID { get; set; }

        [Required]
        public decimal Amount { get; set; }

     public string? OrderInfo { get; set; }
    }
}
