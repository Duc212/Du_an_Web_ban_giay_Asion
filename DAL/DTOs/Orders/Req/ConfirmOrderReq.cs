namespace DAL.DTOs.Orders.Req
{
    public class ConfirmOrderReq
    {
        public int OrderID { get; set; }
        public string? ShippingProvider { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public string? Note { get; set; }
    }
}
