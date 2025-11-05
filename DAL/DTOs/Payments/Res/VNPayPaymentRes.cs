namespace DAL.DTOs.Payments.Res
{
    public class VNPayPaymentRes
    {
 public bool Success { get; set; }
  public string PaymentUrl { get; set; } = string.Empty;
  public string? Message { get; set; }
    }
}
