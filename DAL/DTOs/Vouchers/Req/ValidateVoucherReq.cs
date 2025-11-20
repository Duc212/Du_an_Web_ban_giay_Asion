using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Vouchers.Req
{
    public class ValidateVoucherReq
    {
        [Required(ErrorMessage = "VoucherCode is required")]
        public string VoucherCode { get; set; }

        [Required(ErrorMessage = "OrderAmount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "OrderAmount must be >= 0")]
        public decimal OrderAmount { get; set; }
    }
}
