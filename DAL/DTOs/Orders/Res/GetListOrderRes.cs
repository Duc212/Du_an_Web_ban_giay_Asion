namespace DAL.DTOs.Orders.Res
{
    public class GetListOrderRes
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string OrderType { get; set; }        
        public DateTime OrderDate { get; set; }

        public int Status { get; set; }           
        public string Address { get; set; }         
        public decimal TotalAmount { get; set; }      
    }
}
