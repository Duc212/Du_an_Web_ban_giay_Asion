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