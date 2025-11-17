using DAL.Enums;

namespace DAL.DTOs.Payments.Req
{
    public class UpdatePaymentReq
    {
        public int OrderId { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
