namespace DAL.DTOs.Orders.Req
{
    public class UpdateShippingInfoReq
    {
        public int OrderID { get; set; }
        public string ShippingProvider { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public string Note { get; set; }
    }
}
