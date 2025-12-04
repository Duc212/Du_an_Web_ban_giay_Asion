using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace DAL.Entities
{
    [Table("Revenues")]
    public class Revenue
    {
        [Key]
        public int RevenueID { get; set; }

        public int OrderID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime RecordedDate { get; set; }

        public string? Note { get; set; }

        // Navigation
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }
    }
}
