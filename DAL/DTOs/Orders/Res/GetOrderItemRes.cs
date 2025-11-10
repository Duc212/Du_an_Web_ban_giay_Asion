namespace DAL.DTOs.Orders.Res
{
    public class GetOrderItemRes
    {
        public string OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }
        public string ImageUrl { get; set; }
    }
}