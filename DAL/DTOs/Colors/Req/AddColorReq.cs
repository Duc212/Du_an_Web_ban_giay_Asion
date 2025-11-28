using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Colors.Req
{
    public class AddColorReq
    {
        [Required(ErrorMessage = "Tên màu là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên màu không được vượt quá 50 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mã màu hex là bắt buộc")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Mã màu hex không hợp lệ (ví dụ: #FF0000)")]
        public string HexCode { get; set; } = string.Empty;
    }
}
