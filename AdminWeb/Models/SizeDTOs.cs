using System.ComponentModel.DataAnnotations;

namespace AdminWeb.Models
{
    // Request DTOs
    public class AddSizeReq
    {
        [Required(ErrorMessage = "Giá trị size là bắt buộc")]
        [StringLength(10, ErrorMessage = "Giá trị size không được vượt quá 10 ký tự")]
        public string Value { get; set; } = string.Empty;
    }

    public class UpdateSizeReq
    {
        public int SizeID { get; set; }

        [Required(ErrorMessage = "Giá trị size là bắt buộc")]
        [StringLength(10, ErrorMessage = "Giá trị size không được vượt quá 10 ký tự")]
        public string Value { get; set; } = string.Empty;
    }

    // Response DTOs
    public class GetSizeRes
    {
        public int SizeID { get; set; }
        public string Value { get; set; } = string.Empty;
        public int ProductCount { get; set; }
    }

    public class SizeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GetSizeRes>? Data { get; set; }
    }

    public class SizePaginationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GetSizeRes>? Data { get; set; }
        public int TotalRecords { get; set; }
    }

    public class SizeSingleResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public GetSizeRes? Data { get; set; }
    }

    public class SizeBoolResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Data { get; set; }
    }
}
