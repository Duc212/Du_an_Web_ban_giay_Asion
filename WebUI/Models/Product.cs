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

public class LegacyProductData
{
    public static List<Product> TrendProducts { get; } = new List<Product>
    {
        new Product
        {
            Id = 1,
            Brand = "NEW BALANCE | Nữ",
            Name = "GIÀY U204LSWB - SILVER METALLIC (901)",
            Price = 2859000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-pickleball-tennis-asics-gel-dedicate-8-wide-1041a410-105-4.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Id = 2,
            Brand = "NEW BALANCE | Nữ",
            Name = "GIÀY U204LSWD - SILVER METALLIC (901)",
            Price = 2859000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/10/Giay-New-Balance-550-White-Green-BBW550VG-1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Id = 3,
            Brand = "NEW BALANCE | Unisex",
            Name = "GIÀY MR530KC - LIGHT ALUMINUM (042)",
            Price = 2859000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/05/Giay-New-Balance-327-White-Brown-WS327LH1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Id = 4,
            Brand = "NEW BALANCE | Trẻ em",
            Name = "GIÀY GR530SB1 - WHITE (100)",
            Price = 1799000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Nike-Air-Force-1-Low-Triple-White-CW2288-111.jpg"
        },
        new Product
        {
            Id = 5,
            Brand = "NEW BALANCE | Unisex",
            Name = "GIÀY ML2002RA - CASTLEROCK (105)",
            Price = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/10/Giay-Nike-Air-Force-1-Low-Panda-DV0788-001-1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Id = 6,
            Brand = "NEW BALANCE | Nam",
            Name = "GIÀY M2002RFA(D) - LIGHT BEIGE",
            Price = 2000000,
            OriginalPrice = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/06/Giay-Adidas-Forum-Low-White-Blue-Red-GY8556.jpg"
        },
        new Product
        {
            Id = 7,
            Brand = "NEW BALANCE | Nam",
            Name = "GIÀY M2002RFB(D) - GRAY",
            Price = 2000000,
            OriginalPrice = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/06/Giay-Air-Jordan-1-Low-White-Wolf-Grey-DC0774-105.jpg"
        },
        new Product
        {
            Id = 8,
            Brand = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002REK(D) - OFF WHITE",
            Price = 2000000,
            OriginalPrice = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/02/Nike-Dunk-Low-Retro-White-Black-Panda-DD1391-100.jpg"
        },
        new Product
        {
            Id = 9,
            Brand = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002REL(D) - GREY",
            Price = 2000000,
            OriginalPrice = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Giay-Adidas-Superstar-White-Black-EG4958.jpg"
        },
        new Product
        {
            Id = 10,
            Brand = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002RSF(D) - NAVY(SF)",
            Price = 2000000,
            OriginalPrice = 3999000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Nike-Air-Force-1-Low-Triple-Black-CW2288-001.jpg"
        }
    };

    public static List<Product> FeaturedProducts { get; } = new List<Product>
    {
        new Product
        {
            Id = 11,
            Brand = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - WHITE/WHITE",
            Price = 3299000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-pickleball-tennis-asics-gel-dedicate-8-wide-1041a410-105-4.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Unisex",
            Name = "GIÀY GEL-NYC - POLAR NIGHT/CREAM",
            Price = 3199000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nyc-cream-white-1201a789-250-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Nữ",
            Name = "GIÀY NOVABLAST 5 - GRAVEL/BLUE FADE",
            Price = 3599000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nyc-oyster-grey-pure-silver-1201a789-020-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Nam",
            Name = "GIÀY NOVABLAST 5 - BLACK/BLUE FADE",
            Price = 3599000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-cumulus-26-black-electric-red-1011b795-002-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - WHITE/IRONCLAD",
            Price = 3299000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nimbus-26-platinum-white-electric-red-1011b794-100-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - CREAM/CLAY GREY",
            Price = 3299000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nimbus-26-birch-black-1011b794-200-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Brand = "ASICS | Nam",
            Name = "GIÀY GEL-1130 - WHITE/CLOUDGREY",
            Price = 2599000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-1130-white-polar-shade-1201a256-101-1.jpeg"
        },
        new Product
        {
            Brand = "ASICS | Nữ",
            Name = "GIÀY NOVABLAST 5 - WHITE/FAWN",
            Price = 3599000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-kayano-31-white-pure-silver-1011b723-100-1.jpeg"
        },
        new Product
        {
            Brand = "ASICS | Unisex",
            Name = "GIÀY GT-2160 - SMOKE GREY/PEPPERMINT",
            Price = 2479200,
            OriginalPrice = 3099000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gt-2160-white-pure-silver-1201a275-100-1.jpeg"
        },
        new Product
        {
            Brand = "ASICS | Unisex",
            Name = "GIÀY GEL-KAYANO 14 - WHITE/SLATE GREY",
            Price = 3499000,
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-kayano-14-white-pure-silver-1201a019-101-1.jpeg",
            Badge = "LIMITED"
        }
    };
}