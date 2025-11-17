using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Bảng trung gian giữa Order và Payment
    /// Cho phép một Order có nhiều Payment (thanh toán nhiều lần, thanh toán lại khi thất bại)
    /// </summary>
    public class OrderPayment
    {
        [Key]
        public int OrderPaymentID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        [Required]
        public int PaymentID { get; set; }

        [ForeignKey(nameof(PaymentID))]
        public Payment Payment { get; set; }

        /// <summary>
        /// Số tiền thanh toán trong lần này
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Thời gian liên kết payment với order
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Trạng thái: Pending, Completed, Failed, Refunded
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Ghi chú về thanh toán này
        /// </summary>
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}
