namespace WebUI.Models;

public class ColorInfo
{
    public string ColorName { get; set; } = string.Empty;
    public string HexColor { get; set; } = string.Empty;
    public int AvailableStock { get; set; } = 0; // Số lượng còn của màu này
    public Dictionary<string, int> SizeStock { get; set; } = new(); // Stock theo từng size
    public Dictionary<string, decimal> SizePrice { get; set; } = new(); // Price theo từng size
}

public class ColorImageInfo
{
    public string Color { get; set; } = string.Empty;
    public List<string> ImageColors { get; set; } = new();
}

public class Product
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
    public List<ColorInfo> Colors { get; set; } = new();
    public float Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<string> Features { get; set; } = new();
    public string ImageUrl { get; set; } = "/images/products/default-shoe.jpg";
    public List<string> Images { get; set; } = new();
    public List<ColorImageInfo> ColorImages { get; set; } = new();
    public string? Badge { get; set; }
    public string Vendor => Brand;
    public string PriceFormatted { get; set; } = string.Empty;
    public string OldPriceFormatted { get; set; } = string.Empty;
    public decimal? Discount { get; set; }
    public bool HasDiscount { get; set; }
    public bool HasBadge { get; set; }
    public bool IsSale { get; set; }
}