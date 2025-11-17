using BUS.Services.Interfaces;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;
using DAL.Enums;

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

        #region Public Methods

        public async Task<CommonPagination<GetProductRes>> GetProductLanding(int? CategoryId, int currentPage, int recordPerPage, ProductLandingFilterType? filterType = null)
        {
            try
            {
                var query = from product in _productRepository.AsNoTrackingQueryable()
                            join brand in _brandRepository.AsNoTrackingQueryable() on product.BrandId equals brand.BrandID
                            join gender in _genderRepository.AsNoTrackingQueryable() on product.GenderId equals gender.GenderID
                            select new { product, brand, gender };

                if (CategoryId.HasValue && CategoryId.Value != -1)
                {
                    query = query.Where(x => x.product.CategoryId == CategoryId.Value);
                }

                // Áp dụng filter bổ sung theo loại section
                if (filterType.HasValue)
                {
                    switch (filterType.Value)
                    {
                        case ProductLandingFilterType.WeeklyTrend:
                            // Xu hướng tuần này: sản phẩm tạo trong 30 ngày
                            query = query.Where(x => x.product.CreatedAt >= DateTime.UtcNow.AddDays(-30));
                            break;
                        case ProductLandingFilterType.NewProducts:
                            // Sản phẩm mới: 7 ngày gần nhất
                            query = query.Where(x => x.product.CreatedAt >= DateTime.UtcNow.AddDays(-30));
                            break;
                        case ProductLandingFilterType.FeaturedCollections:
                            query = query;
                            break;
                    }
                }

                var totalRecordsBeforeFilter = await query.CountAsync();

                var pagedProductsBase = await query.Skip((currentPage - 1) * recordPerPage)
                                                   .Take(recordPerPage)
                                                   .ToListAsync();

                var productIdsBase = pagedProductsBase.Select(p => p.product.ProductID).ToList();

                var variantsAll = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIdsBase.Contains(v.ProductID))
                    .Include(v => v.Size)
                    .Include(v => v.Color)
                    .ToListAsync();

                var productImagesAll = await _productImageRepository.AsNoTrackingQueryable()
                    .Where(img => productIdsBase.Contains(img.ProductID) && img.IsActive)
                    .Include(img => img.Color)
                    .OrderBy(img => img.DisplayOrder)
                    .ToListAsync();

                // Nếu filter FeaturedCollections cần loại bỏ những sản phẩm không đủ điều kiện và nạp lại phân trang
                if (filterType == ProductLandingFilterType.FeaturedCollections)
                {
                    var discountQualifiedIds = variantsAll
                        .GroupBy(v => v.ProductID)
                        .Select(g => new
                        {
                            ProductID = g.Key,
                            MaxImport = g.Max(x => x.ImportPrice),
                            MinSelling = g.Min(x => x.SellingPrice)
                        })
                        .Where(x => x.MaxImport > 0 && ((x.MaxImport - x.MinSelling) / x.MaxImport * 100) >= 20)
                        .Select(x => x.ProductID)
                        .ToHashSet();

                    query = query.Where(x => discountQualifiedIds.Contains(x.product.ProductID));

                    var totalRecordsAfterDiscount = await query.CountAsync();

                    var pagedProductsAfterDiscount = await query.Skip((currentPage - 1) * recordPerPage)
                                                                .Take(recordPerPage)
                                                                .ToListAsync();

                    var productIdsDiscount = pagedProductsAfterDiscount.Select(p => p.product.ProductID).ToList();

                    variantsAll = await _productVariantRepository.AsNoTrackingQueryable()
                        .Where(v => productIdsDiscount.Contains(v.ProductID))
                        .Include(v => v.Size)
                        .Include(v => v.Color)
                        .ToListAsync();

                    productImagesAll = await _productImageRepository.AsNoTrackingQueryable()
                        .Where(img => productIdsDiscount.Contains(img.ProductID) && img.IsActive)
                        .Include(img => img.Color)
                        .OrderBy(img => img.DisplayOrder)
                        .ToListAsync();

                    var variantGroupsDiscount = variantsAll.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
                    var imageGroupsDiscount = productImagesAll.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                    var productListDiscount = pagedProductsAfterDiscount.Select(p => MapToGetProductRes(p.product, p.brand, variantGroupsDiscount, imageGroupsDiscount)).ToList();

                    return new CommonPagination<GetProductRes>
                    {
                        Success = true,
                        Message = "Lấy danh sách sản phẩm Landing thành công",
                        Data = productListDiscount,
                        TotalRecord = totalRecordsAfterDiscount
                    };
                }

                // WeeklyTrend sắp xếp theo một tiêu chí giả định: mức giảm giá lớn nhất trước + ngày tạo mới
                if (filterType == ProductLandingFilterType.WeeklyTrend)
                {
                    var trendScoreDict = variantsAll
                        .GroupBy(v => v.ProductID)
                        .Select(g => new
                        {
                            ProductID = g.Key,
                            DiscountPercent = g.Max(x => x.ImportPrice) > 0 ? (double)((g.Max(x => x.ImportPrice) - g.Min(x => x.SellingPrice)) / g.Max(x => x.ImportPrice) * 100) : 0,
                            VariantCount = g.Count()
                        })
                        .ToDictionary(x => x.ProductID, x => x.DiscountPercent + x.VariantCount * 0.5);

                    pagedProductsBase = pagedProductsBase
                        .OrderByDescending(p => trendScoreDict.TryGetValue(p.product.ProductID, out var score) ? score : 0)
                        .ThenByDescending(p => p.product.CreatedAt)
                        .ToList();
                }

                // NewProducts sort mới nhất
                if (filterType == ProductLandingFilterType.NewProducts)
                {
                    pagedProductsBase = pagedProductsBase
                        .OrderByDescending(p => p.product.CreatedAt)
                        .ToList();
                }

                var variantGroups = variantsAll.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
                var imageGroups = productImagesAll.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                var productList = pagedProductsBase.Select(p => MapToGetProductRes(p.product, p.brand, variantGroups, imageGroups)).ToList();

                return new CommonPagination<GetProductRes>
                {
                    Success = true,
                    Message = "Lấy danh sách sản phẩm Landing thành công",
                    Data = productList,
                    TotalRecord = totalRecordsBeforeFilter
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

        public async Task<CommonPagination<GetProductRes>> GetProductShop(int? categoryId, string? keyword, int? sortType, int? sortPrice, int currentPage, int recordPerPage)
        {
            try
            {
                var query = from product in _productRepository.AsNoTrackingQueryable()
                            join brand in _brandRepository.AsNoTrackingQueryable() on product.BrandId equals brand.BrandID
                            join gender in _genderRepository.AsNoTrackingQueryable() on product.GenderId equals gender.GenderID
                            select new { product, brand, gender };

                if (categoryId.HasValue && categoryId != -1)
                    query = query.Where(x => x.product.CategoryId == categoryId.Value);

                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(x => x.product.Name.Contains(keyword));

                var productIds = await query.Select(x => x.product.ProductID).ToListAsync();

                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIds.Contains(v.ProductID))
                    .Include(v => v.Size)
                    .Include(v => v.Color)
                    .ToListAsync();

                // Filter by price
                if (sortPrice.HasValue && sortPrice > 0)
                {
                    var priceDict = variants
                        .GroupBy(v => v.ProductID)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Any() ? g.Min(v => v.SellingPrice) : 0
                        );

                    var filteredIds = priceDict
                        .Where(kvp =>
                        {
                            var price = kvp.Value;
                            return sortPrice.Value switch
                            {
                                1 => price < 500_000,
                                2 => price >= 500_000 && price < 1_000_000,
                                3 => price >= 1_000_000 && price < 2_000_000,
                                4 => price > 5_000_000,
                                _ => true
                            };
                        })
                        .Select(kvp => kvp.Key)
                        .ToList();

                    query = query.Where(x => filteredIds.Contains(x.product.ProductID));
                }

                // Sorting
                query = sortType switch
                {
                    1 => query.OrderBy(x => x.product.Name),
                    2 => query.OrderByDescending(x => x.product.Name),
                    3 => query.OrderBy(x => variants.Where(v => v.ProductID == x.product.ProductID).Min(v => v.SellingPrice)),
                    4 => query.OrderByDescending(x => variants.Where(v => v.ProductID == x.product.ProductID).Min(v => v.SellingPrice)),
                    5 => query.OrderByDescending(x => x.product.CreatedAt),
                    6 => query.OrderByDescending(x => x.product.ProductID),
                    _ => query.OrderBy(x => x.product.ProductID)
                };

                var totalRecords = await query.CountAsync();
                var pagedProducts = await query.Skip((currentPage - 1) * recordPerPage)
                                               .Take(recordPerPage)
                                               .ToListAsync();

                var pagedIds = pagedProducts.Select(p => p.product.ProductID).ToList();

                var productImages = await _productImageRepository.AsNoTrackingQueryable()
                    .Where(img => pagedIds.Contains(img.ProductID) && img.IsActive)
                    .Include(img => img.Color)
                    .OrderBy(img => img.DisplayOrder)
                    .ToListAsync();

                var variantGroups = variants.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
                var imageGroups = productImages.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                var productList = pagedProducts.Select(p => MapToGetProductRes(p.product, p.brand, variantGroups, imageGroups)).ToList();

                return new CommonPagination<GetProductRes>
                {
                    Success = true,
                    Message = "Lấy danh sách sản phẩm Shop thành công",
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

        public async Task<CommonResponse<List<GetListCategoryRes>>> GetListCategory()
        {
            var categories = await _categoryRepository.AsQueryable().ToListAsync();
            var productCounts = await _productRepository.AsQueryable()
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToListAsync();

            var result = categories.Select(c => new GetListCategoryRes
            {
                CategoryID = c.CategoryID,
                Name = c.Name,
                Icon = c.Icon,
                Count = productCounts.FirstOrDefault(x => x.CategoryId == c.CategoryID)?.Count ?? 0
            }).ToList();

            return new CommonResponse<List<GetListCategoryRes>>
            {
                Success = true,
                Message = "Lấy danh sách danh mục thành công",
                Data = result
            };
        }

        public async Task<CommonResponse<List<GetListBrandRes>>> GetListBrand()
        {
            var brands = await _brandRepository.AsQueryable().ToListAsync();
            var result = brands.Select(b => new GetListBrandRes
            {
                BrandID = b.BrandID,
                Name = b.Name
            }).ToList();

            return new CommonResponse<List<GetListBrandRes>>
            {
                Success = true,
                Message = "Lấy danh sách thương hiệu thành công",
                Data = result
            };
        }

        #endregion

        #region Private Helpers

        private GetProductRes MapToGetProductRes(Product product, Brand brand, Dictionary<int, List<ProductVariant>> variantGroups, Dictionary<int, List<ProductImage>> imageGroups)
        {
            var variants = variantGroups.GetValueOrDefault(product.ProductID, new List<ProductVariant>());
            var images = imageGroups.GetValueOrDefault(product.ProductID, new List<ProductImage>());

            var mainImages = BuildMainImages(product.ImageUrl, images);
            var colorImages = BuildColorImages(variants, images, mainImages);
            var sizes = GetAvailableSizes(variants);

            // Loại bỏ trùng lặp màu dựa trên giá trị
            var colors = variants
                .Where(v => v.Color != null && v.StockQuantity >0)
                .Select(v => new GetColorRes { ColorName = v.Color.Name, HexColor = v.Color.HexCode })
                .GroupBy(c => new { c.ColorName, c.HexColor })
                .Select(g => g.First())
                .ToList();

            var minSelling = variants.Any() ? variants.Min(v => v.SellingPrice) :0;
            var maxImport = variants.Any() ? variants.Max(v => v.ImportPrice) :0;
            var originalPrice = maxImport > minSelling ? maxImport : (decimal?)null;

            return new GetProductRes
            {
                Id = product.ProductID,
                Name = product.Name,
                Brand = brand.Name,
                Price = minSelling,
                OriginalPrice = originalPrice,
                Description = product.Description ?? string.Empty,
                CategoryId = product.CategoryId,
                InStock = variants.Sum(v => v.StockQuantity) >0,
                StockQuantity = variants.Sum(v => v.StockQuantity),
                Sizes = sizes,
                Colors = colors,
                ImageUrl = product.ImageUrl,
                Rating = GetProductRating(product.ProductID),
                ReviewCount = GetProductReviewCount(product.ProductID),
                Features = GetProductFeatures(product.ProductID),
                Images = mainImages,
                ColorImages = colorImages,
                Badge = DetermineBadge(product, variants)
            };
        }

        private List<string> BuildMainImages(string productImageUrl, List<ProductImage> images)
        {
            if (images.Any())
            {
                var defaultImg = images.FirstOrDefault(img => img.IsDefault)?.ImageUrl;
                var otherImgs = images.Where(img => !img.IsDefault).OrderBy(img => img.DisplayOrder).Select(img => img.ImageUrl).ToList();

                var list = new List<string>();
                if (!string.IsNullOrEmpty(defaultImg)) list.Add(defaultImg);
                list.AddRange(otherImgs);
                return list;
            }

            return !string.IsNullOrEmpty(productImageUrl) ? new List<string> { productImageUrl } : new List<string> { "/images/products/default-shoe.jpg" };
        }

        private List<GetColorImageRes> BuildColorImages(List<ProductVariant> variants, List<ProductImage> images, List<string> fallbackImages)
        {
            var result = new List<GetColorImageRes>();
            var colors = variants.Where(v => v.Color != null && v.StockQuantity > 0)
                                 .Select(v => v.Color!.Name)
                                 .Distinct();

            foreach (var colorName in colors)
            {
                var variant = variants.First(v => v.Color?.Name == colorName);
                var colorImgs = images.Where(img => img.ColorID == variant.Color!.ColorID)
                                      .OrderBy(img => img.DisplayOrder)
                                      .Select(img => img.ImageUrl)
                                      .ToList();

                result.Add(new GetColorImageRes
                {
                    Color = colorName,
                    ImageColors = colorImgs.Any() ? colorImgs : fallbackImages.Take(1).ToList()
                });
            }

            return result;
        }

        private List<string> GetAvailableSizes(List<ProductVariant> variants)
        {
            return variants.Where(v => v.Size != null && v.StockQuantity > 0)
                           .Select(v => v.Size!.Value)
                           .Distinct()
                           .OrderBy(s => s)
                           .ToList();
        }

        private string? DetermineBadge(Product product, List<ProductVariant> variants)
        {
            if (product.CreatedAt >= DateTime.Now.AddDays(-7)) return "NEW";

            if (variants.Any())
            {
                var maxImport = variants.Max(v => v.ImportPrice);
                var minSelling = variants.Min(v => v.SellingPrice);
                var discountPercent = (maxImport - minSelling) / maxImport * 100;
                if (discountPercent >= 20) return "SALE";
            }

            return IsBestSeller(product.ProductID) ? "HOT" : null;
        }

        private float GetProductRating(int productId)
        {
            var random = new Random(productId);
            return (float)(4.0 + random.NextDouble());
        }

        private int GetProductReviewCount(int productId)
        {
            var random = new Random(productId);
            return random.Next(10, 200);
        }

        private List<string> GetProductFeatures(int productId)
        {
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

        private bool IsBestSeller(int productId)
        {
            return new Random().Next(2) == 0;
        }

        #endregion
    }
}
