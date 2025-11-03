using BUS.Services.Interfaces;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IRepositoryAsync<Color> _colorRepository;
        private readonly IRepositoryAsync<ProductVariant> _productVariantRepository;
        private readonly IRepositoryAsync<Gender> _genderRepository;
        private readonly IRepositoryAsync<Brand> _brandRepository;
        private readonly IRepositoryAsync<Size> _sizeRepository;
        private readonly IRepositoryAsync<Category> _categoryRepository;
        private readonly IRepositoryAsync<ProductImage> _productImageRepository;

        public ProductServices(
    IRepositoryAsync<Product> productRepository,
         IRepositoryAsync<Color> colorRepository,
    IRepositoryAsync<ProductVariant> productVariantRepository,
            IRepositoryAsync<Gender> genderRepository,
     IRepositoryAsync<Brand> brandRepository,
            IRepositoryAsync<Size> sizeRepository,
            IRepositoryAsync<Category> categoryRepository,
            IRepositoryAsync<ProductImage> productImageRepository)
        {
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _productVariantRepository = productVariantRepository;
            _genderRepository = genderRepository;
            _brandRepository = brandRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
        }

        public async Task<CommonPagination<GetProductRes>> GetProductLangding(int currentPage, int recordPerPage)
        {
            try
            {
                var query = from product in _productRepository.AsNoTrackingQueryable()
                            join brand in _brandRepository.AsNoTrackingQueryable()
                             on product.BrandId equals brand.BrandID
                            join gender in _genderRepository.AsNoTrackingQueryable()
                              on product.GenderId equals gender.GenderID
                            select new
                            {
                                product,
                                brand,
                                gender
                            };

                var totalRecords = await query.CountAsync();

                var pagedProducts = await query
                      .Skip((currentPage - 1) * recordPerPage)
                         .Take(recordPerPage)
                 .ToListAsync();

                var productIds = pagedProducts.Select(p => p.product.ProductID).ToList();

                // Get variants with Color and Size information
                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                       .Where(v => productIds.Contains(v.ProductID))
                    .Include(v => v.Size)
                .Include(v => v.Color)
                                .ToListAsync();

                // Get product images with Color information
                var productImages = await _productImageRepository.AsNoTrackingQueryable()
             .Where(img => productIds.Contains(img.ProductID) && img.IsActive)
                .Include(img => img.Color)
              .OrderBy(img => img.DisplayOrder)
    .ToListAsync();

                var variantGroups = variants.GroupBy(v => v.ProductID)
               .ToDictionary(g => g.Key, g => g.ToList());

                var imageGroups = productImages.GroupBy(img => img.ProductID)
                .ToDictionary(g => g.Key, g => g.ToList());

                var productList = pagedProducts.Select(item =>
                               {
                                   var productVariants = variantGroups.GetValueOrDefault(item.product.ProductID, new List<ProductVariant>());
                                   var images = imageGroups.GetValueOrDefault(item.product.ProductID, new List<ProductImage>());

                                   // Build main images list with fallback logic
                                   var imageUrls = new List<string>();

                                   if (images.Any())
                                   {
                                       // Get default image first
                                       var defaultImage = images.FirstOrDefault(img => img.IsDefault);
                                       if (defaultImage != null)
                                       {
                                           imageUrls.Add(defaultImage.ImageUrl);
                                       }

                                       // Add other images ordered by DisplayOrder
                                       var otherImages = images.Where(img => !img.IsDefault)
                       .OrderBy(img => img.DisplayOrder)
                              .Select(img => img.ImageUrl);
                                       imageUrls.AddRange(otherImages);
                                   }
                                   else if (!string.IsNullOrEmpty(item.product.ImageUrl))
                                   {
                                       imageUrls.Add(item.product.ImageUrl);
                                   }
                                   else
                                   {
                                       imageUrls.Add("/images/products/default-shoe.jpg");
                                   }

                                   // Build ColorImages dictionary
                                   var colorImages = new Dictionary<string, List<string>>();
                                   var availableColors = productVariants
                  .Where(v => v.Color != null && v.StockQuantity > 0)
              .Select(v => v.Color!.Name)
             .Distinct()
                 .ToList();

                                   foreach (var colorName in availableColors)
                                   {
                                       // Find color ID for this color name
                                       var colorVariant = productVariants.FirstOrDefault(v => v.Color?.Name == colorName);
                                       if (colorVariant?.Color != null)
                                       {
                                           var colorSpecificImages = images
                      .Where(img => img.ColorID == colorVariant.Color.ColorID)
                      .OrderBy(img => img.DisplayOrder)
                     .Select(img => img.ImageUrl)
                     .ToList();

                                           if (colorSpecificImages.Any())
                                           {
                                               colorImages[colorName] = colorSpecificImages;
                                           }
                                           else
                                           {
                                               // Fallback to main images if no color-specific images
                                               colorImages[colorName] = imageUrls.Take(1).ToList();
                                           }
                                       }
                                   }

                                   // Calculate pricing
                                   var minSellingPrice = productVariants.Any() ? productVariants.Min(v => v.SellingPrice) : 0;
                                   var maxImportPrice = productVariants.Any() ? productVariants.Max(v => v.ImportPrice) : 0;
                                   var originalPrice = maxImportPrice > minSellingPrice ? maxImportPrice : (decimal?)null;

                                   // Get available sizes and colors
                                   var availableSizes = productVariants
                .Where(v => v.Size != null && v.StockQuantity > 0)
                  .Select(v => v.Size!.Value)
                     .Distinct()
                         .OrderBy(s => s)
                          .ToList();

                                   return new GetProductRes
                                   {
                                       Id = item.product.ProductID,
                                       Name = item.product.Name,
                                       Brand = item.brand.Name,
                                       Price = minSellingPrice,
                                       OriginalPrice = originalPrice,
                                       Description = item.product.Description ?? string.Empty,
                                       CategoryId = item.product.CategoryId,
                                       InStock = productVariants.Sum(v => v.StockQuantity) > 0,
                                       StockQuantity = productVariants.Sum(v => v.StockQuantity),
                                       Sizes = availableSizes,
                                       Colors = availableColors,
                                       Rating = GetProductRating(item.product.ProductID), 
                                       ReviewCount = GetProductReviewCount(item.product.ProductID), 
                                       Features = GetProductFeatures(item.product.ProductID), 
                                       Images = imageUrls,
                                       ColorImages = colorImages,
                                       Badge = DetermineBadge(item.product, productVariants)
                                   };
                               }).ToList();

                return new CommonPagination<GetProductRes>
                {
                    Success = true,
                    Message = "Lấy danh sách sản phẩm thành công",
                    Data = productList,
                    TotalRecord = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetProductRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetProductRes>(),
                    TotalRecord = 0
                };
            }
        }

        /// <summary>
        /// Logic xác định badge cho sản phẩm
        /// </summary>
        private string? DetermineBadge(Product product, List<ProductVariant> variants)
        {
            // Sản phẩm mới (tạo trong 7 ngày qua)
            if (product.CreatedAt >= DateTime.Now.AddDays(-7))
            {
                return "NEW";
            }

            // Sản phẩm có giảm giá >= 20%
            if (variants.Any())
            {
                var maxImport = variants.Max(v => v.ImportPrice);
                var minSelling = variants.Min(v => v.SellingPrice);

                if (maxImport > minSelling)
                {
                    var discountPercent = (maxImport - minSelling) / maxImport * 100;
                    if (discountPercent >= 20)
                    {
                        return "SALE";
                    }
                }
            }

            if (IsBestSeller(product.ProductID))
            {
                return "HOT";
            }

            return null;
        }

        /// <summary>
        /// Temporary method to get product rating - implement with real review data later
        /// </summary>
        private float GetProductRating(int productId)
        {
            // TODO: Implement real rating calculation from ProductReview table
            var random = new Random(productId); // Use productId as seed for consistent results
            return (float)(4.0 + random.NextDouble() * 1.0); // Random rating between 4.0-5.0
        }

        /// <summary>
        /// Temporary method to get review count - implement with real review data later
        /// </summary>
        private int GetProductReviewCount(int productId)
        {
            // TODO: Implement real review count from ProductReview table
            var random = new Random(productId);
            return random.Next(10, 200); // Random count between 10-200
        }

        /// <summary>
        /// Get product features - implement with real ProductFeature data later
        /// </summary>
        private List<string> GetProductFeatures(int productId)
        {
            // TODO: Implement real features from ProductFeature table
            // For now, return standard shoe features
            return new List<string>
            {
                "Đệm khí Max Air 270°",
         "Upper mesh thoáng khí",
                 "Đế giữa foam nhẹ",
              "Đế ngoài cao su bền bỉ",
           "Thiết kế hiện đại",
             "Phù hợp tập luyện hàng ngày"
              };
        }

        /// <summary>
        /// Check if product is best seller - implement with OrderDetail data later
        /// </summary>
        private bool IsBestSeller(int productId)
        {
            Random random = new Random();
            return random.Next(2) == 0;
        }

    }
}
