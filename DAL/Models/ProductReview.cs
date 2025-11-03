using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductReview
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }

        public int? VariantID { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        /// <summary>
        /// User đã mua sản phẩm này chưa (verified purchase)
        /// </summary>
        public bool IsVerifiedPurchase { get; set; } = false;

        /// <summary>
        /// Số lượng người thấy review này hữu ích
        /// </summary>
        public int HelpfulCount { get; set; } = 0;

        /// <summary>
        /// Review có được approve bởi admin chưa
        /// </summary>
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// Lý do từ chối review (nếu có)
        /// </summary>
        [MaxLength(200)]
        public string? RejectReason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Product? Product { get; set; }
        public User? User { get; set; }
        public ProductVariant? Variant { get; set; }

        // Computed properties
        [NotMapped]
        public string UserDisplayName => User?.FullName ?? "Ẩn danh";

        [NotMapped]
        public string RatingStars => new string('★', Rating) + new string('☆', 5 - Rating);

        [NotMapped]
        public bool CanEdit => (DateTime.UtcNow - CreatedAt).TotalHours <= 24;

        [NotMapped]
        public string TimeAgo
        {
            get
            {
                var timeSpan = DateTime.UtcNow - CreatedAt;
                return timeSpan.TotalDays >= 1
            ? $"{(int)timeSpan.TotalDays} ngày trước"
                : timeSpan.TotalHours >= 1
                   ? $"{(int)timeSpan.TotalHours} giờ trước"
               : $"{(int)timeSpan.TotalMinutes} phút trước";
            }
        }
    }
}