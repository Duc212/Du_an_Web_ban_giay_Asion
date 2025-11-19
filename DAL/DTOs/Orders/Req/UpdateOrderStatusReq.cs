namespace DAL.DTOs.Orders.Req
{
    public class UpdateOrderStatusReq
    {
        public int OrderID { get; set; }
        public int NewStatus { get; set; }
        public string Note { get; set; }
    }
}
