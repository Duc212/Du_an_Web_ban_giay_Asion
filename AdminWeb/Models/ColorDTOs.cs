using System.ComponentModel.DataAnnotations;

namespace AdminWeb.Models
{
    // Request DTOs
    public class AddColorReq
    {
        [Required(ErrorMessage = "Tên màu là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên màu không được vượt quá 50 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mã màu hex là bắt buộc")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Mã màu hex không hợp lệ (ví dụ: #FF0000)")]
        public string HexCode { get; set; } = string.Empty;
    }

    public class UpdateColorReq
    {
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Tên màu là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên màu không được vượt quá 50 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mã màu hex là bắt buộc")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Mã màu hex không hợp lệ (ví dụ: #FF0000)")]
        public string HexCode { get; set; } = string.Empty;
    }

    // Response DTOs
    public class GetColorRes
    {
        public int ColorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;
        public int ProductCount { get; set; }
    }

    public class ColorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GetColorRes>? Data { get; set; }
    }

    public class ColorPaginationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GetColorRes>? Data { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ColorSingleResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public GetColorRes? Data { get; set; }
    }

    public class ColorBoolResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Data { get; set; }
    }
}
