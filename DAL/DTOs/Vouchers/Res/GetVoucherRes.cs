namespace DAL.DTOs.Vouchers.Res
{
    public class GetVoucherRes
    {
        public int VoucherID { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public string DiscountType { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
        public int Quantity { get; set; }
        public int UsedCount { get; set; } // Số lần đã sử dụng
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public bool IsExpired => DateTime.Now > EndDate;
        public bool IsActive => Status == "Active" && DateTime.Now >= StartDate && DateTime.Now <= EndDate && Quantity > UsedCount;
    }
}
