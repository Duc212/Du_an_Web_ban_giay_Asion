namespace DAL.DTOs.Products.Res
{
    public class GetProductRes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool InStock { get; set; } = true;
        public int StockQuantity { get; set; }
        public List<string> Sizes { get; set; } = new();
        public List<GetColorRes> Colors { get; set; } = new();
        public float Rating { get; set; }
        public int ReviewCount { get; set; }
        public List<string> Features { get; set; } = new();
        public string ImageUrl {  get; set; }
        public List<string> Images { get; set; } = new();
        public List<GetColorImageRes> ColorImages { get; set; } = new();
        public string? Badge { get; set; }

        public string Vendor => Brand;
        public string PriceFormatted => $"{Price:N0}đ";
        public string? OldPriceFormatted => OriginalPrice?.ToString("N0") + "đ";
        public string? Discount => OriginalPrice.HasValue && OriginalPrice > Price ?
            $"-{(int)((OriginalPrice.Value - Price) / OriginalPrice.Value * 100)}%" : null;
        public bool HasDiscount => OriginalPrice.HasValue && OriginalPrice > Price;
        public bool HasBadge => !string.IsNullOrEmpty(Badge);
        public bool IsSale => HasDiscount && Badge == "SALE";
    }
}