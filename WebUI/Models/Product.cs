namespace WebUI.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? OriginalPrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = "/images/products/default-shoe.jpg";
    public int CategoryId { get; set; }
    public bool InStock { get; set; } = true;
    public int StockQuantity { get; set; }
    public List<string> Sizes { get; set; } = new();
    public List<string> Colors { get; set; } = new();
    public float Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<string> Features { get; set; } = new();
    public List<string> Images { get; set; } = new();
    public Dictionary<string, List<string>> ColorImages { get; set; } = new();
    public string? Badge { get; set; }
    
    // Computed properties for backward compatibility
    public string Vendor => Brand;
    public string PriceFormatted => $"{Price:N0}đ";
    public string? OldPriceFormatted => OriginalPrice?.ToString("N0") + "đ";
    public string? Discount => OriginalPrice.HasValue ? 
        $"-{(int)((OriginalPrice.Value - Price) / OriginalPrice.Value * 100)}%" : null;
    public bool HasDiscount => OriginalPrice.HasValue && OriginalPrice > Price;
    public bool HasBadge => !string.IsNullOrEmpty(Badge);
    public bool IsSale => HasDiscount && Badge == "SALE";
    
    // Get primary image URL - priority: Images[0], then ImageUrl, then default
    public string PrimaryImageUrl => 
        (Images != null && Images.Any()) ? Images.First() :
        !string.IsNullOrEmpty(ImageUrl) ? ImageUrl :
        "/images/products/default-shoe.jpg";
}