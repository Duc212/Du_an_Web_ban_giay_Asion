using WebUI.Models;

namespace WebUI.Services
{
    public static class ProductDetailData
    {
        private static readonly List<Product> _products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Nike Air Max 270",
                Brand = "Nike",
                Price = 2890000,
                OriginalPrice = 3200000,
                Description = "Giày thể thao Nike Air Max 270 với công nghệ đệm khí Max Air lớn nhất từ trước đến nay. Thiết kế hiện đại, phù hợp cho cả tập luyện và phong cách hàng ngày.",
                ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 25,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF0000" },
                Rating = 4.5f,
                ReviewCount = 124,
                Features = new List<string> 
                { 
                    "Đệm khí Max Air 270°",
                    "Upper mesh thoáng khí",
                    "Đế giữa foam nhẹ",
                    "Đế ngoài cao su bền bỉ"
                },
                Images = new List<string>
                {
                    "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1560769629-975ec94e6a86?w=500&h=500&fit=crop"
                }
            },
            new Product
            {
                Id = 2,
                Name = "Adidas Ultraboost 22",
                Brand = "Adidas",
                Price = 3450000,
                OriginalPrice = 3800000,
                Description = "Giày chạy bộ Adidas Ultraboost 22 với công nghệ Boost mang lại năng lượng trở lại mỗi bước chạy. Thiết kế Primeknit+ ôm chân tự nhiên.",
                ImageUrl = "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 18,
                Sizes = new List<string> { "38", "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#FFFFFF", "#000000", "#0066CC" },
                Rating = 4.7f,
                ReviewCount = 89,
                Features = new List<string> 
                { 
                    "Công nghệ Boost",
                    "Upper Primeknit+",
                    "Đế ngoài Continental™",
                    "Hỗ trợ Linear Energy Push"
                },
                Images = new List<string>
                {
                    "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop"
                }
            },
            new Product
            {
                Id = 3,
                Name = "Converse Chuck Taylor All Star",
                Brand = "Converse",
                Price = 1590000,
                OriginalPrice = null,
                Description = "Giày thể thao classic Converse Chuck Taylor All Star. Thiết kế vượt thời gian, phù hợp với mọi phong cách và độ tuổi.",
                ImageUrl = "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 32,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF0000", "#000080" },
                Rating = 4.3f,
                ReviewCount = 203,
                Features = new List<string> 
                { 
                    "Thiết kế classic",
                    "Upper canvas bền bỉ",
                    "Đế cao su vulcanized",
                    "Biểu tượng Chuck Taylor"
                },
                Images = new List<string>
                {
                    "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1552066344-2464c1135c32?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1584735175315-9d5df23860e6?w=500&h=500&fit=crop"
                }
            },
            new Product
            {
                Id = 4,
                Name = "New Balance Fresh Foam X 1080v12",
                Brand = "New Balance",
                Price = 2990000,
                OriginalPrice = 3300000,
                Description = "Giày chạy bộ New Balance 1080v12 với công nghệ Fresh Foam X mang lại cảm giác êm ái và đàn hồi tuyệt vời cho những chuyến chạy dài.",
                ImageUrl = "https://images.unsplash.com/photo-1539185441755-769473a23570?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 15,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#4169E1", "#708090", "#000000" },
                Rating = 4.6f,
                ReviewCount = 67,
                Features = new List<string> 
                { 
                    "Đệm Fresh Foam X",
                    "Upper Hypoknit",
                    "Bootie construction",
                    "Blown rubber outsole"
                },
                Images = new List<string>
                {
                    "https://images.unsplash.com/photo-1539185441755-769473a23570?w=500&h=500&fit=crop",
                    "https://images.unsplash.com/photo-1512374382149-233c42b6a83b?w=500&h=500&fit=crop"
                }
            },
            // Thêm nhiều sản phẩm trending mới
            new Product
            {
                Id = 5,
                Name = "Converse Chuck Taylor All Star",
                Brand = "Converse",
                Price = 1890000,
                OriginalPrice = 2100000,
                Description = "Giày thể thao cổ điển Converse Chuck Taylor All Star - biểu tượng thời trang đường phố không bao giờ lỗi thời.",
                ImageUrl = "https://images.unsplash.com/photo-1595341888016-a392ef81b7de?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 30,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF0000", "#000080" },
                Rating = 4.3f,
                ReviewCount = 156,
                Badge = "TRENDING",
                Features = new List<string> { "Canvas upper", "Rubber sole", "Classic design", "Versatile style" }
            },
            new Product
            {
                Id = 6,
                Name = "Vans Old Skool",
                Brand = "Vans",
                Price = 1690000,
                OriginalPrice = 1890000,
                Description = "Giày Vans Old Skool với thiết kế side stripe đặc trưng. Phù hợp cho skateboarding và phong cách casual hàng ngày.",
                ImageUrl = "https://images.unsplash.com/photo-1525966222134-fcfa99b8ae77?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 22,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#8B4513" },
                Rating = 4.4f,
                ReviewCount = 89,
                Badge = "HOT",


                Features = new List<string> { "Suede and canvas upper", "Waffle outsole", "Padded collar", "Signature side stripe" }
            },
            new Product
            {
                Id = 7,
                Name = "Asics Gel-Kayano 29",
                Brand = "Asics",
                Price = 3890000,
                OriginalPrice = 4200000,
                Description = "Giày chạy bộ Asics Gel-Kayano 29 dành cho những vận động viên cần độ ổn định cao. Công nghệ FlyteFoam và Gel giảm chấn tối ưu.",
                ImageUrl = "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 18,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#4169E1", "#000000", "#32CD32" },
                Rating = 4.7f,
                ReviewCount = 234,
                Features = new List<string> { "FlyteFoam cushioning", "Gel technology", "Dynamic DuoMax", "Guidance Line" }
            },
            new Product
            {
                Id = 8,
                Name = "Puma RS-X Reinvention",
                Brand = "Puma",
                Price = 2590000,
                Description = "Giày thể thao Puma RS-X với thiết kế chunky sneaker xu hướng. Kết hợp phong cách retro và công nghệ hiện đại.",
                ImageUrl = "https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 25,
                Sizes = new List<string> { "38", "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#FFFFFF", "#FF69B4", "#FFD700" },
                Rating = 4.2f,
                ReviewCount = 145,
                Badge = "NEW",

                Features = new List<string> { "RS cushioning", "Leather and mesh upper", "Rubber outsole", "Chunky silhouette" }
            },
            new Product
            {
                Id = 9,
                Name = "Jordan Air 1 Mid",
                Brand = "Jordan",
                Price = 3290000,
                OriginalPrice = 3590000,
                Description = "Giày bóng rổ Jordan Air 1 Mid - huyền thoại basketball với thiết kế iconic. Chất lượng premium cho cả sân bóng và đường phố.",
                ImageUrl = "https://images.unsplash.com/photo-1556906781-9a412961c28c?w=500&h=500&fit=crop",
                CategoryId = 3,
                InStock = true,
                StockQuantity = 12,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF0000" },
                Rating = 4.8f,
                ReviewCount = 312,
                Badge = "TRENDING",

                Features = new List<string> { "Leather upper", "Air-Sole unit", "Rubber outsole", "Iconic design" }
            },
            new Product
            {
                Id = 10,
                Name = "Reebok Club C 85",
                Brand = "Reebok",
                Price = 1990000,
                OriginalPrice = 2290000,
                Description = "Giày tennis cổ điển Reebok Club C 85 với thiết kế tối giản, thanh lịch. Phù hợp cho nhiều hoạt động thể thao và thời trang.",
                ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 28,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#FFFFFF", "#000000", "#008000" },
                Rating = 4.1f,
                ReviewCount = 76,

                Features = new List<string> { "Leather upper", "Low-cut design", "Die-cut EVA midsole", "Rubber outsole" }
            },
            new Product
            {
                Id = 11,
                Name = "Nike Air Force 1 '07",
                Brand = "Nike",
                Price = 2490000,
                Description = "Giày thể thao Nike Air Force 1 '07 - biểu tượng thời trang streetwear với thiết kế vượt thời gian và chất lượng bền bỉ.",
                ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 35,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#FFFFFF", "#000000", "#800080" },
                Rating = 4.6f,
                ReviewCount = 289,
                Badge = "TRENDING",

                Features = new List<string> { "Leather upper", "Air-Sole unit", "Perforations", "Pivot points" }
            },
            new Product
            {
                Id = 12,
                Name = "Adidas Stan Smith",
                Brand = "Adidas",
                Price = 2190000,
                OriginalPrice = 2490000,
                Description = "Giày tennis Adidas Stan Smith - thiết kế tối giản, thanh lịch với màu trắng cổ điển. Phù hợp cho mọi phong cách thời trang.",
                ImageUrl = "https://images.unsplash.com/photo-1586525198428-225f6f12cff5?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 40,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#FFFFFF", "#008000", "#000000" },
                Rating = 4.5f,
                ReviewCount = 198,
                Badge = "CLASSIC",

                Features = new List<string> { "Leather upper", "Perforated 3-Stripes", "Rubber cupsole", "OrthoLite sockliner" }
            },
            new Product
            {
                Id = 13,
                Name = "New Balance 327",
                Brand = "New Balance",
                Price = 2290000,
                OriginalPrice = 2590000,
                Description = "Giày New Balance 327 lấy cảm hứng từ thiết kế vintage 70s với twist hiện đại. Phong cách retro-modern độc đáo.",
                ImageUrl = "https://images.unsplash.com/photo-1605348532760-6753d2c43329?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 20,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#FFD700", "#000080", "#FFFFFF" },
                Rating = 4.3f,
                ReviewCount = 112,
                Badge = "RETRO",

                Features = new List<string> { "Suede and nylon upper", "EVA midsole", "Rubber outsole", "Vintage-inspired design" }
            },
            new Product
            {
                Id = 14,
                Name = "Converse Run Star Hike",
                Brand = "Converse",
                Price = 2890000,
                Description = "Giày Converse Run Star Hike với đế platform độc đáo. Kết hợp phong cách Chuck Taylor cổ điển với xu hướng chunky hiện đại.",
                ImageUrl = "https://images.unsplash.com/photo-1603808033192-082d6919d3e1?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 16,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FFB6C1" },
                Rating = 4.4f,
                ReviewCount = 134,
                Badge = "PLATFORM",

                Features = new List<string> { "Canvas upper", "Platform midsole", "Jagged rubber outsole", "Modern twist" }
            },
            new Product
            {
                Id = 15,
                Name = "Vans Sk8-Hi",
                Brand = "Vans",
                Price = 1990000,
                OriginalPrice = 2190000,
                Description = "Giày Vans Sk8-Hi cổ cao với thiết kế ankle support. Phù hợp cho skateboarding và phong cách streetwear năng động.",
                ImageUrl = "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 24,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF4500" },
                Rating = 4.2f,
                ReviewCount = 87,

                Features = new List<string> { "High-top design", "Suede and canvas upper", "Padded collar", "Signature waffle outsole" }
            },
            new Product
            {
                Id = 16,
                Name = "Asics Gel-Nimbus 25",
                Brand = "Asics",
                Price = 4190000,
                Description = "Giày chạy bộ Asics Gel-Nimbus 25 với công nghệ đệm tiên tiến nhất. Mang lại trải nghiệm chạy êm ái và thoải mái tối đa.",
                ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 14,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#00CED1", "#FF69B4", "#000000" },
                Rating = 4.8f,
                ReviewCount = 176,
                Badge = "PREMIUM",

                Features = new List<string> { "FF BLAST+ cushioning", "PureGEL technology", "Engineered knit upper", "AHAR outsole" }
            },
            new Product
            {
                Id = 17,
                Name = "Puma Suede Classic",
                Brand = "Puma",
                Price = 1790000,
                OriginalPrice = 1990000,
                Description = "Giày Puma Suede Classic - biểu tượng thời trang từ những năm 1960s. Chất liệu da lộn cao cấp với thiết kế vượt thời gian.",
                ImageUrl = "https://images.unsplash.com/photo-1552346154-21d32810aba3?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 32,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#000080", "#FF0000", "#000000" },
                Rating = 4.3f,
                ReviewCount = 156,
                Badge = "HERITAGE",


                Features = new List<string> { "Suede upper", "Rubber sole", "Classic formstrip", "Vintage appeal" }
            },
            new Product
            {
                Id = 18,
                Name = "Jordan Air 4 Retro",
                Brand = "Jordan",
                Price = 4890000,
                Description = "Giày bóng rổ Jordan Air 4 Retro - một trong những mẫu Jordan iconic nhất mọi thời đại với thiết kế wing và mesh panels đặc trưng.",
                ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop",
                CategoryId = 3,
                InStock = true,
                StockQuantity = 8,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44", "45" },
                Colors = new List<string> { "#FFFFFF", "#000000", "#FF0000" },
                Rating = 4.9f,
                ReviewCount = 456,
                Badge = "LIMITED",

                Features = new List<string> { "Leather and nubuck upper", "Air cushioning", "Plastic wing eyelets", "Mesh side panels" }
            },
            new Product
            {
                Id = 19,
                Name = "Nike React Infinity Run",
                Brand = "Nike",
                Price = 3690000,
                OriginalPrice = 3990000,
                Description = "Giày chạy bộ Nike React Infinity Run được thiết kế để giảm chấn thương. Công nghệ React foam mang lại độ đàn hồi tuyệt vời.",
                ImageUrl = "https://images.unsplash.com/photo-1607522370275-f14206abe5d3?w=500&h=500&fit=crop",
                CategoryId = 1,
                InStock = true,
                StockQuantity = 19,
                Sizes = new List<string> { "39", "40", "41", "42", "43", "44" },
                Colors = new List<string> { "#00BFFF", "#000000", "#LIME" },
                Rating = 4.6f,
                ReviewCount = 203,
                Features = new List<string> { "Nike React foam", "Flyknit upper", "Wider platform", "Injury reduction design" }
            },
            new Product
            {
                Id = 20,
                Name = "Adidas NMD R1",
                Brand = "Adidas",
                Price = 3190000,
                OriginalPrice = 3490000,
                Description = "Giày thể thao Adidas NMD R1 với thiết kế futuristic. Kết hợp công nghệ Boost với phong cách streetwear hiện đại.",
                ImageUrl = "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop",
                CategoryId = 2,
                InStock = true,
                StockQuantity = 26,
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                Colors = new List<string> { "#000000", "#FFFFFF", "#FF69B4" },
                Rating = 4.4f,
                ReviewCount = 267,
                Badge = "BOOST",


                Features = new List<string> { "Boost midsole", "Primeknit upper", "EVA plugs", "Continental rubber outsole" }
            }
        };

        public static List<Product> GetAllProducts() => _products;

        public static Product? GetProductById(int id) => 
            _products.FirstOrDefault(p => p.Id == id);

        public static List<Product> GetRelatedProducts(int excludeId, int count = 6) =>
            _products.Where(p => p.Id != excludeId).Take(count).ToList();

        public static List<Product> SearchProducts(string query) =>
            _products.Where(p => 
                p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                p.Brand.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();

        public static List<Product> GetProductsByCategory(int categoryId) =>
            _products.Where(p => p.CategoryId == categoryId).ToList();

        public static List<Product> GetProductsByBrand(string brand) =>
            _products.Where(p => p.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
