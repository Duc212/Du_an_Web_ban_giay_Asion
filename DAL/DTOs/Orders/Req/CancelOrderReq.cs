namespace DAL.DTOs.Orders.Req
{
    public class CancelOrderReq
    {
        public int OrderID { get; set; }
        public string CancelReason { get; set; }
        public bool RefundRequired { get; set; }
    }
}
