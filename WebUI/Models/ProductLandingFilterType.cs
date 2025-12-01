namespace WebUI.Models
{
    /// <summary>
    /// Enum filter type cho Product Landing API
    /// Match với DAL.Enums.ProductLandingFilterType trong backend
    /// </summary>
    public enum ProductLandingFilterType
    {
        WeeklyTrend = 1,        // Xu Hướng Tuần Này
        NewProducts = 2,        // Sản Phẩm Mới
        FeaturedCollections = 3 // Bộ Sưu Tập Nổi Bật (sản phẩm có discount >=10%)
    }
}
