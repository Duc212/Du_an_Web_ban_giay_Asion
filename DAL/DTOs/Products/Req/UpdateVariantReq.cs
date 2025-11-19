namespace DAL.DTOs.Products.Req
{
    public class UpdateVariantReq
    {
        public int VariantID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
    }
}
