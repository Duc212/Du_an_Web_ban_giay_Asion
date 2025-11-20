namespace DAL.DTOs.Vouchers.Res
{
    public class ValidateVoucherRes
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public int? VoucherID { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public string DiscountType { get; set; } // "Percentage" or "FixedAmount"
        public decimal CalculatedDiscount { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
    }
}
