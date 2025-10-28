namespace DAL.DTOs.Orders.Res
{
    public class GetProductDetailRes
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string imageUrl { get; set; }
        public string GendersName { get; set; }
        public string BrandName { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string Value { get; set; }
    }
}
