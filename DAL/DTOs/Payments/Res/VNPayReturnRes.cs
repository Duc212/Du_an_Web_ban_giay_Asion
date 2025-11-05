namespace DAL.DTOs.Payments.Res
{
    public class VNPayReturnRes
    {
      public bool Success { get; set; }
     public string? TransactionId { get; set; }
        public string? OrderId { get; set; }
        public decimal Amount { get; set; }
        public string? BankCode { get; set; }
        public string? PayDate { get; set; }
     public string? Message { get; set; }
    public string? ResponseCode { get; set; }
    }
}
