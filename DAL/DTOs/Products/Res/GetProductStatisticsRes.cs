namespace DAL.DTOs.Products.Res
{
    public class GetProductStatisticsRes
    {
        public int TotalProducts { get; set; }
        public int ActiveProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public int LowStockProducts { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public List<CategoryStatistic> CategoryStats { get; set; } = new List<CategoryStatistic>();
        public List<BrandStatistic> BrandStats { get; set; } = new List<BrandStatistic>();
    }

    public class CategoryStatistic
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
    }

    public class BrandStatistic
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
    }
}
