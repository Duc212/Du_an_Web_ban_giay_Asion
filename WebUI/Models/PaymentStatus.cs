namespace WebUI.Models
{
    /// <summary>
    /// Frontend mirror of DAL.Enums.PaymentStatus
    /// </summary>
    public enum PaymentStatus
    {
        Unpaid = 0,
        Paid = 1,
        Refunded = 2,
        Failed = 3
    }
}
