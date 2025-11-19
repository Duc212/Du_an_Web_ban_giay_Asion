namespace DAL.DTOs.Products.Req
{
    public class UpdateStockReq
    {
        public List<StockUpdateItem> Items { get; set; } = new List<StockUpdateItem>();
    }

    public class StockUpdateItem
    {
        public int VariantID { get; set; }
        public int NewStock { get; set; }
    }
}
