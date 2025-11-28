using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.Sizes.Req
{
    public class AddSizeReq
    {
        [Required(ErrorMessage = "Giá trị size là bắt buộc")]
        [StringLength(10, ErrorMessage = "Giá trị size không được vượt quá 10 ký tự")]
        public string Value { get; set; } = string.Empty;
    }
}
