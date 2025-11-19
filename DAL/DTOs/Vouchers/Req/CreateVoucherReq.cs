using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Vouchers.Req
{
    public class CreateVoucherReq
    {
        [Required(ErrorMessage = "Mã voucher là bắt buộc")]
        [MaxLength(50, ErrorMessage = "Mã voucher không được quá 50 ký tự")]
        public string VoucherCode { get; set; }

        [Required(ErrorMessage = "Tên voucher là bắt buộc")]
        [MaxLength(150, ErrorMessage = "Tên voucher không được quá 150 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá trị giảm là bắt buộc")]
        [Range(0, 100000000, ErrorMessage = "Giá trị giảm phải >= 0")]
        public decimal DiscountValue { get; set; }

        [Required(ErrorMessage = "Loại giảm giá là bắt buộc")]
        [MaxLength(20)]
        public string DiscountType { get; set; } // "Percentage" hoặc "FixedAmount"

        [Range(0, double.MaxValue, ErrorMessage = "Giá trị đơn hàng tối thiểu phải >= 0")]
        public decimal? MinOrderAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giảm giá tối đa phải >= 0")]
        public decimal? MaxDiscountAmount { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải >= 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [MaxLength(20)]
        public string Status { get; set; } // "Active", "Inactive", "Expired"
    }
}
