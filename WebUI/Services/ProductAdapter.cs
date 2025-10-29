using WebUI.Models;

namespace WebUI.Services
{
    public static class ProductAdapter
    {
        public static List<Product> ConvertLegacyProducts()
        {
            var legacyProducts = LegacyProductData.TrendProducts.Concat(LegacyProductData.FeaturedProducts).ToList();
            var convertedProducts = new List<Product>();
            
            int id = 1;
            foreach (var legacy in legacyProducts)
            {
                var converted = new Product
                {
                    Id = id++,
                    Name = legacy.Name,
                    Brand = legacy.Brand,
                    Price = legacy.Price,
                    OriginalPrice = legacy.OriginalPrice,
                    Description = $"High-quality {legacy.Brand} sneakers with premium materials and comfortable design.",
                    ImageUrl = legacy.ImageUrl,
                    CategoryId = 1,
                    InStock = true,
                    StockQuantity = new Random().Next(10, 50),
                    Sizes = new List<string> { "38", "39", "40", "41", "42", "43", "44" },
                    Colors = new List<string> { "#000000", "#FFFFFF", "#FF0000" },
                    Rating = 3.5f + (float)(new Random().NextDouble() * 1.5),
                    ReviewCount = new Random().Next(50, 300),
                    Features = new List<string> { "Premium materials", "Comfortable design", "Durable construction" },
                    Images = new List<string> { legacy.ImageUrl },
                    Badge = legacy.Badge
                };
                
                convertedProducts.Add(converted);
            }
            
            return convertedProducts;
        }
        

    }
}