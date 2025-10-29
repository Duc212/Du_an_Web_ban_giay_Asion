namespace WebUI.Models;

public class Product
{
    public string Vendor { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string? OldPrice { get; set; }
    public string? Discount { get; set; }
    public string ImageUrl { get; set; } = "/images/products/default-shoe.jpg";
    public string? Badge { get; set; }
    public bool HasDiscount => !string.IsNullOrEmpty(Discount);
    public bool HasBadge => !string.IsNullOrEmpty(Badge);
    public bool IsSale => HasDiscount && Badge == "SALE";
}

public class ProductData
{
    public static List<Product> TrendProducts { get; } = new List<Product>
    {
        new Product
        {
            Vendor = "NEW BALANCE | Nữ",
            Name = "GIÀY U204LSWB - SILVER METALLIC (901)",
            Price = "2.859.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-pickleball-tennis-asics-gel-dedicate-8-wide-1041a410-105-4.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Nữ",
            Name = "GIÀY U204LSWD - SILVER METALLIC (901)",
            Price = "2.859.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/10/Giay-New-Balance-550-White-Green-BBW550VG-1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Unisex",
            Name = "GIÀY MR530KC - LIGHT ALUMINUM (042)",
            Price = "2.859.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/05/Giay-New-Balance-327-White-Brown-WS327LH1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Trẻ em",
            Name = "GIÀY GR530SB1 - WHITE (100)",
            Price = "1.799.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Nike-Air-Force-1-Low-Triple-White-CW2288-111.jpg"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Unisex",
            Name = "GIÀY ML2002RA - CASTLEROCK (105)",
            Price = "3.999.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/10/Giay-Nike-Air-Force-1-Low-Panda-DV0788-001-1.jpg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Nam",
            Name = "GIÀY M2002RFA(D) - LIGHT BEIGE",
            Price = "2.000.000đ",
            OldPrice = "3.999.000đ",
            Discount = "-49%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/06/Giay-Adidas-Forum-Low-White-Blue-Red-GY8556.jpg"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Nam",
            Name = "GIÀY M2002RFB(D) - GRAY",
            Price = "2.000.000đ",
            OldPrice = "3.999.000đ",
            Discount = "-49%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/06/Giay-Air-Jordan-1-Low-White-Wolf-Grey-DC0774-105.jpg"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002REK(D) - OFF WHITE",
            Price = "2.000.000đ",
            OldPrice = "3.999.000đ",
            Discount = "-49%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2023/02/Nike-Dunk-Low-Retro-White-Black-Panda-DD1391-100.jpg"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002REL(D) - GREY",
            Price = "2.000.000đ",
            OldPrice = "3.999.000đ",
            Discount = "-49%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Giay-Adidas-Superstar-White-Black-EG4958.jpg"
        },
        new Product
        {
            Vendor = "NEW BALANCE | Unisex",
            Name = "GIÀY M2002RSF(D) - NAVY(SF)",
            Price = "2.000.000đ",
            OldPrice = "3.999.000đ",
            Discount = "-49%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2021/08/Nike-Air-Force-1-Low-Triple-Black-CW2288-001.jpg"
        }
    };

    public static List<Product> FeaturedProducts { get; } = new List<Product>
    {
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - WHITE/WHITE",
            Price = "3.299.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-pickleball-tennis-asics-gel-dedicate-8-wide-1041a410-105-4.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GEL-NYC - POLAR NIGHT/CREAM",
            Price = "3.199.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nyc-cream-white-1201a789-250-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Nữ",
            Name = "GIÀY NOVABLAST 5 - GRAVEL/BLUE FADE",
            Price = "3.599.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nyc-oyster-grey-pure-silver-1201a789-020-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Nam",
            Name = "GIÀY NOVABLAST 5 - BLACK/BLUE FADE",
            Price = "3.599.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-cumulus-26-black-electric-red-1011b795-002-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - WHITE/IRONCLAD",
            Price = "3.299.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nimbus-26-platinum-white-electric-red-1011b794-100-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GEL-CUMULUS 16 - CREAM/CLAY GREY",
            Price = "3.299.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-nimbus-26-birch-black-1011b794-200-1.jpeg",
            Badge = "NEW"
        },
        new Product
        {
            Vendor = "ASICS | Nam",
            Name = "GIÀY GEL-1130 - WHITE/CLOUDGREY",
            Price = "2.599.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-1130-white-polar-shade-1201a256-101-1.jpeg"
        },
        new Product
        {
            Vendor = "ASICS | Nữ",
            Name = "GIÀY NOVABLAST 5 - WHITE/FAWN",
            Price = "3.599.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-kayano-31-white-pure-silver-1011b723-100-1.jpeg"
        },
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GT-2160 - SMOKE GREY/PEPPERMINT",
            Price = "2.479.200đ",
            OldPrice = "3.099.000đ",
            Discount = "-20%",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gt-2160-white-pure-silver-1201a275-100-1.jpeg"
        },
        new Product
        {
            Vendor = "ASICS | Unisex",
            Name = "GIÀY GEL-KAYANO 14 - WHITE/SLATE GREY",
            Price = "3.499.000đ",
            ImageUrl = "https://trungsneaker.com/wp-content/uploads/2025/10/giay-asics-gel-kayano-14-white-pure-silver-1201a019-101-1.jpeg",
            Badge = "LIMITED"
        }
    };
}