using BUS.Services.Interfaces;
using DAL.DTOs.Brands.Req;
using DAL.DTOs.Brands.Res;
using DAL.DTOs.Categories.Req;
using DAL.DTOs.Categories.Res;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Enums;
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
        private readonly IRepositoryAsync<FavoriteProduct> _favoriteProductRepository;

        public ProductServices(
            IRepositoryAsync<Product> productRepository,
            IRepositoryAsync<Color> colorRepository,
            IRepositoryAsync<ProductVariant> productVariantRepository,
            IRepositoryAsync<Gender> genderRepository,
            IRepositoryAsync<Brand> brandRepository,
            IRepositoryAsync<Size> sizeRepository,
            IRepositoryAsync<Category> categoryRepository,
            IRepositoryAsync<ProductImage> productImageRepository,
            IRepositoryAsync<FavoriteProduct> favoriteProductRepository)
        {
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _productVariantRepository = productVariantRepository;
            _genderRepository = genderRepository;
            _brandRepository = brandRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _favoriteProductRepository = favoriteProductRepository;
        }
        public async Task<CommonResponse<bool>> CreateBrand(AddBrandReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                if (string.IsNullOrWhiteSpace(req.BrandName))
                {
                    response.Success = false;
                    response.Message = "Tên thương hiệu không được trống.";
                    return response;
                }

                var existed = await _brandRepository.AsNoTrackingQueryable()
                    .AnyAsync(b => b.Name == req.BrandName.Trim());
                if (existed)
                {
                    response.Success = false;
                    response.Message = "Thương hiệu đã tồn tại.";
                    return response;
                }

                var brand = new Brand
                {
                    Name = req.BrandName.Trim(),
                    Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim()
                };
                await _brandRepository.AddAsync(brand);
                await _brandRepository.SaveChangesAsync();

                response.Success = true;
                response.Data = true;
                response.Message = "Tạo thương hiệu thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<CommonResponse<bool>> UpdateBrand(UpdateBrandReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                var brand = await _brandRepository.AsQueryable()
                    .FirstOrDefaultAsync(b => b.BrandID == req.BrandID);
                if (brand == null)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không tìm thấy thương hiệu.";
                    return response;
                }

                if (string.IsNullOrWhiteSpace(req.Name))
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Tên thương hiệu không được trống.";
                    return response;
                }

                // Kiểm tra trùng tên với brand khác
                var duplicate = await _brandRepository.AsNoTrackingQueryable()
                    .AnyAsync(b => b.BrandID != req.BrandID && b.Name == req.Name.Trim());
                if (duplicate)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Tên thương hiệu đã được sử dụng.";
                    return response;
                }

                brand.Name = req.Name.Trim();
                brand.Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim();
                await _brandRepository.UpdateAsync(brand);
                await _brandRepository.SaveChangesAsync();

                response.Success = true;
                response.Data = true;
                response.Message = "Cập nhật thương hiệu thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<CommonResponse<bool>> RemoveBrand(RemoveBrandReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                var brand = await _brandRepository.AsQueryable()
                    .FirstOrDefaultAsync(b => b.BrandID == req.BrandID);
                if (brand == null)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không tìm thấy thương hiệu.";
                    return response;
                }

                // Có thể kiểm tra ràng buộc (ví dụ còn sản phẩm) trước khi xóa
                var hasProducts = await _productRepository.AsNoTrackingQueryable()
                    .AnyAsync(p => p.BrandId == brand.BrandID);
                if (hasProducts)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không thể xóa: thương hiệu đang có sản phẩm.";
                    return response;
                }

                await _brandRepository.RemoveAsync(brand);
                await _brandRepository.SaveChangesAsync();

                response.Success = true;
                response.Data = true;
                response.Message = "Xóa thương hiệu thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

   

        public async Task<CommonPagination<GetALLBrandRes>> GetBrandsPaged(int currentPage, int recordPerPage)
        {
            try
            {
                if (currentPage < 1) currentPage = 1;
                if (recordPerPage < 1) recordPerPage = 10;

                var query = _brandRepository.AsNoTrackingQueryable();
                var total = await query.CountAsync();

                var brands = await query
                    .OrderBy(b => b.BrandID)
                    .Skip((currentPage - 1) * recordPerPage)
                    .Take(recordPerPage)
                    .Include(b => b.Products)
                    .ToListAsync();

                var brandIds = brands.Select(b => b.BrandID).ToList();
                var productCounts = await _productRepository.AsNoTrackingQueryable()
                    .Where(p => brandIds.Contains(p.BrandId))
                    .GroupBy(p => p.BrandId)
                    .Select(g => new { BrandId = g.Key, Count = g.Count() })
                    .ToListAsync();

                var data = brands.Select(b => new GetALLBrandRes
                {
                    BrandId = b.BrandID,
                    BrandName = b.Name,
                    Description = b.Description,
                    ProductCount = productCounts.FirstOrDefault(pc => pc.BrandId == b.BrandID)?.Count ?? 0,
                   
                }).ToList();

                return new CommonPagination<GetALLBrandRes>
                {
                    Success = true,
                    Message = "Lấy danh sách thương hiệu phân trang thành công",
                    Data = data,
                    TotalRecords = total
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetALLBrandRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetALLBrandRes>(),
                    TotalRecords = 0
                };
            }
        }
        #region Public Methods

        public async Task<CommonPagination<GetProductRes>> GetProductLanding(int? CategoryId, int currentPage, int recordPerPage, ProductLandingFilterType? filterType = null)
        {
            try
            {
                var query = from product in _productRepository.AsNoTrackingQueryable()
                            join brand in _brandRepository.AsNoTrackingQueryable() on product.BrandId equals brand.BrandID
                            join gender in _genderRepository.AsNoTrackingQueryable() on product.GenderId equals gender.GenderID
                            where _productVariantRepository.AsNoTrackingQueryable().Any(v => v.ProductID == product.ProductID && (v.Status == "Active" || v.Status == "Available"))
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

                            break; 
                    }
                }

                var totalRecordsBeforeFilter = await query.CountAsync();

                var pagedProductsBase = await query.Skip((currentPage - 1) * recordPerPage)
                                                   .Take(recordPerPage)
                                                   .ToListAsync();

                var productIdsBase = pagedProductsBase.Select(p => p.product.ProductID).ToList();

                var variantsAll = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIdsBase.Contains(v.ProductID) && (v.Status == "Active" || v.Status == "Available"))
                    .Include(v => v.Size)
                    .Include(v => v.Color)
                    .ToListAsync();

                var productImagesAll = await _productImageRepository.AsNoTrackingQueryable()
                    .Where(img => productIdsBase.Contains(img.ProductID) && img.IsActive)
                    .Include(img => img.Color)
                    .OrderBy(img => img.DisplayOrder)
                    .ToListAsync();

                // Tạm thời bỏ filter discount cho FeaturedCollections - hiển thị tất cả sản phẩm
                // if (filterType == ProductLandingFilterType.FeaturedCollections)
                // {
                //     var discountQualifiedIds = variantsAll
                //         .GroupBy(v => v.ProductID)
                //         .Select(g => new
                //         {
                //             ProductID = g.Key,
                //             MaxImport = g.Max(x => x.ImportPrice),
                //             MinSelling = g.Min(x => x.SellingPrice)
                //         })
                //         .Where(x => x.MaxImport > 0 && ((x.MaxImport - x.MinSelling) / x.MaxImport * 100) >= 10)
                //         .Select(x => x.ProductID)
                //         .ToHashSet();

                //     query = query.Where(x => discountQualifiedIds.Contains(x.product.ProductID));

                //     var totalRecordsAfterDiscount = await query.CountAsync();

                //     var pagedProductsAfterDiscount = await query.Skip((currentPage - 1) * recordPerPage)
                //                                                 .Take(recordPerPage)
                //                                                 .ToListAsync();

                //     var productIdsDiscount = pagedProductsAfterDiscount.Select(p => p.product.ProductID).ToList();

                //     variantsAll = await _productVariantRepository.AsNoTrackingQueryable()
                //         .Where(v => productIdsDiscount.Contains(v.ProductID))
                //         .Include(v => v.Size)
                //         .Include(v => v.Color)
                //         .ToListAsync();

                //     productImagesAll = await _productImageRepository.AsNoTrackingQueryable()
                //         .Where(img => productIdsDiscount.Contains(img.ProductID) && img.IsActive)
                //         .Include(img => img.Color)
                //         .OrderBy(img => img.DisplayOrder)
                //         .ToListAsync();

                //     var variantGroupsDiscount = variantsAll.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
                //     var imageGroupsDiscount = productImagesAll.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                //     var productListDiscount = pagedProductsAfterDiscount.Select(p => MapToGetProductRes(p.product, p.brand, variantGroupsDiscount, imageGroupsDiscount)).ToList();

                //     return new CommonPagination<GetProductRes>
                //     {
                //         Success = true,
                //         Message = "Lấy danh sách sản phẩm Landing thành công",
                //         Data = productListDiscount,
                //         TotalRecords = totalRecordsAfterDiscount
                //     };
                // }

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
                    TotalRecords = totalRecordsBeforeFilter
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetProductRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetProductRes>(),
                    TotalRecords = 0
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
                            where _productVariantRepository.AsNoTrackingQueryable().Any(v => v.ProductID == product.ProductID && (v.Status == "Active" || v.Status == "Available"))
                            select new { product, brand, gender };

                if (categoryId.HasValue && categoryId != -1)
                    query = query.Where(x => x.product.CategoryId == categoryId.Value);

                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(x => x.product.Name.Contains(keyword));

                var productIds = await query.Select(x => x.product.ProductID).ToListAsync();

                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIds.Contains(v.ProductID) && (v.Status == "Active" || v.Status == "Available"))
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
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetProductRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetProductRes>(),
                    TotalRecords = 0
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
            var brands = await _brandRepository.AsNoTrackingQueryable().ToListAsync();
            var productCounts = await _productRepository.AsNoTrackingQueryable()
                .GroupBy(p => p.BrandId)
                .Select(g => new { BrandId = g.Key, Count = g.Count() })
                .ToListAsync();

            var result = brands.Select(b => new GetListBrandRes
            {
                BrandID = b.BrandID,
                Name = b.Name,
            }).ToList();

            return new CommonResponse<List<GetListBrandRes>>
            {
                Success = true,
                Message = "Lấy danh sách thương hiệu thành công",
                Data = result
            };
        }

        public async Task<CommonResponse<GetProductRes>> GetProductById(int productId)
        {
            var product = await _productRepository.AsNoTrackingQueryable()
                .FirstOrDefaultAsync(p => p.ProductID == productId);
            if (product == null)
            {
                return new CommonResponse<GetProductRes>
                {
                    Success = false,
                    Message = "Không tìm thấy sản phẩm.",
                    Data = null
                };
            }
            var brand = await _brandRepository.AsNoTrackingQueryable()
                .FirstOrDefaultAsync(b => b.BrandID == product.BrandId);
            var variants = await _productVariantRepository.AsNoTrackingQueryable()
                .Where(v => v.ProductID == productId && (v.Status == "Active" || v.Status == "Available"))
                .Include(v => v.Size)
                .Include(v => v.Color)
                .ToListAsync();
            var images = await _productImageRepository.AsNoTrackingQueryable()
                .Where(img => img.ProductID == productId && img.IsActive)
                .Include(img => img.Color)
                .OrderBy(img => img.DisplayOrder)
                .ToListAsync();
            var variantGroups = variants.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
            var imageGroups = images.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());
            var productRes = MapToGetProductRes(product, brand, variantGroups, imageGroups);
            return new CommonResponse<GetProductRes>
            {
                Success = true,
                Message = "Lấy thông tin sản phẩm thành công.",
                Data = productRes
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

            // Tính AvailableStock cho mỗi màu (tổng stock của tất cả size với màu đó)
            var colors = variants
                .Where(v => v.Color != null)
                .GroupBy(v => new { v.Color.ColorID, v.Color.Name, v.Color.HexCode })
                .Select(g => new GetColorRes 
                { 
                    ColorID = g.Key.ColorID,
                    ColorName = g.Key.Name, 
                    HexColor = g.Key.HexCode,
                    AvailableStock = g.Sum(v => v.StockQuantity), // Tổng stock của màu này
                    SizeStock = g.Where(v => v.Size != null)
                                 .ToDictionary(
                                     v => v.Size.Value, 
                                     v => v.StockQuantity
                                 ), // Stock theo từng size của màu này
                    SizePrice = g.Where(v => v.Size != null)
                                 .ToDictionary(
                                     v => v.Size.Value,
                                     v => v.SellingPrice
                                 ) // Price theo từng size của màu này
                })
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

        public async Task<CommonResponse<bool>> AddFavoriteProduct(int userId, int productId)
        {
            var existed = await _favoriteProductRepository.AsQueryable()
                .AnyAsync(x => x.UserId == userId && x.ProductId == productId);
            if (existed)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Sản phẩm đã có trong danh sách yêu thích.",
                    Data = false
                };
            }
            var favorite = new FavoriteProduct
            {
                UserId = userId,
                ProductId = productId,
                CreatedDate = DateTime.Now
            };
            await _favoriteProductRepository.AddAsync(favorite);
            await _favoriteProductRepository.SaveChangesAsync();
            return new CommonResponse<bool>
            {
                Success = true,
                Message = "Thêm sản phẩm yêu thích thành công.",
                Data = true
            };
        }

        public async Task<CommonResponse<bool>> RemoveFavoriteProduct(int userId, int productId)
        {
            var favorite = await _favoriteProductRepository.AsQueryable()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (favorite == null)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = "Không tìm thấy sản phẩm yêu thích để xóa.",
                    Data = false
                };
            }
            await _favoriteProductRepository.RemoveAsync(favorite);
            await _favoriteProductRepository.SaveChangesAsync();
            return new CommonResponse<bool>
            {
                Success = true,
                Message = "Xóa sản phẩm yêu thích thành công.",
                Data = true
            };
        }

        public async Task<CommonResponse<List<GetProductRes>>> GetFavoriteProducts(int userId)
        {
            var favoriteProductIds = await _favoriteProductRepository.AsQueryable()
                .Where(x => x.UserId == userId)
                .Select(x => x.ProductId)
                .ToListAsync();
            var products = await _productRepository.AsNoTrackingQueryable()
                .Where(p => favoriteProductIds.Contains(p.ProductID))
                .ToListAsync();
            var brands = await _brandRepository.AsNoTrackingQueryable().ToListAsync();
            var variants = await _productVariantRepository.AsNoTrackingQueryable()
                .Where(v => favoriteProductIds.Contains(v.ProductID) && (v.Status == "Active" || v.Status == "Available"))
                .Include(v => v.Size)
                .Include(v => v.Color)
                .ToListAsync();
            var images = await _productImageRepository.AsNoTrackingQueryable()
                .Where(img => favoriteProductIds.Contains(img.ProductID) && img.IsActive)
                .Include(img => img.Color)
                .OrderBy(img => img.DisplayOrder)
                .ToListAsync();
            var variantGroups = variants.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());
            var imageGroups = images.GroupBy(img => img.ProductID).ToDictionary(g => g.Key, g => g.ToList());
            var productList = products.Select(p =>
            {
                var brand = brands.FirstOrDefault(b => b.BrandID == p.BrandId);
                return MapToGetProductRes(p, brand, variantGroups, imageGroups);
            }).ToList();
            return new CommonResponse<List<GetProductRes>>
            {
                Success = true,
                Message = "Lấy danh sách sản phẩm yêu thích thành công.",
                Data = productList
            };
        }

        public async Task<CommonResponse<bool>> CreateCategory(AddCategoryReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                if (string.IsNullOrWhiteSpace(req.Name))
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Tên danh mục không được trống.";
                    return response;
                }
                var existed = await _categoryRepository.AsNoTrackingQueryable()
                    .AnyAsync(c => c.Name == req.Name.Trim());
                if (existed)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Danh mục đã tồn tại.";
                    return response;
                }
                var category = new Category
                {
                    Name = req.Name.Trim(),
                    Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim(),
                    Icon = string.IsNullOrWhiteSpace(req.Icon) ? "" : req.Icon.Trim()
                };
                await _categoryRepository.AddAsync(category);
                await _categoryRepository.SaveChangesAsync();
                response.Success = true;
                response.Data = true;
                response.Message = "Tạo danh mục thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<CommonResponse<bool>> UpdateCategory(UpdateCategoryReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                var category = await _categoryRepository.AsQueryable()
                    .FirstOrDefaultAsync(c => c.CategoryID == req.CategoryID);
                if (category == null)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không tìm thấy danh mục.";
                    return response;
                }
                if (string.IsNullOrWhiteSpace(req.Name))
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Tên danh mục không được trống.";
                    return response;
                }
                var duplicate = await _categoryRepository.AsNoTrackingQueryable()
                    .AnyAsync(c => c.CategoryID != req.CategoryID && c.Name == req.Name.Trim());
                if (duplicate)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Tên danh mục đã được sử dụng.";
                    return response;
                }
                category.Name = req.Name.Trim();
                category.Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim();
                category.Icon = string.IsNullOrWhiteSpace(req.Icon) ? "" : req.Icon.Trim();
                await _categoryRepository.UpdateAsync(category);
                await _categoryRepository.SaveChangesAsync();
                response.Success = true;
                response.Data = true;
                response.Message = "Cập nhật danh mục thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<CommonResponse<bool>> RemoveCategoryReq(RemoveCategoryReq req)
        {
            var response = new CommonResponse<bool>();
            try
            {
                var category = await _categoryRepository.AsQueryable()
                    .FirstOrDefaultAsync(c => c.CategoryID == req.CategoryID);
                if (category == null)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không tìm thấy danh mục.";
                    return response;
                }
                var hasProducts = await _productRepository.AsNoTrackingQueryable()
                    .AnyAsync(p => p.CategoryId == category.CategoryID);
                if (hasProducts)
                {
                    response.Success = false;
                    response.Data = false;
                    response.Message = "Không thể xóa: danh mục đang có sản phẩm.";
                    return response;
                }
                await _categoryRepository.RemoveAsync(category);
                await _categoryRepository.SaveChangesAsync();
                response.Success = true;
                response.Data = true;
                response.Message = "Xóa danh mục thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = $"Lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<CommonPagination<GetAllCategoryRes>> GetAllCategory(int currentPage, int recordPerPage)
        {
            try
            {
                if (currentPage < 1) currentPage = 1;
                if (recordPerPage < 1) recordPerPage = 10;
                var query = _categoryRepository.AsNoTrackingQueryable();
                var total = await query.CountAsync();
                var categories = await query
                    .OrderBy(c => c.CategoryID)
                    .Skip((currentPage - 1) * recordPerPage)
                    .Take(recordPerPage)
                    .ToListAsync();
                var categoryIds = categories.Select(c => c.CategoryID).ToList();
                var productCounts = await _productRepository.AsNoTrackingQueryable()
                    .Where(p => categoryIds.Contains(p.CategoryId))
                    .GroupBy(p => p.CategoryId)
                    .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                    .ToListAsync();
                var data = categories.Select(c => new GetAllCategoryRes
                {
                    CategoryID = c.CategoryID,
                    Name = c.Name,
                    Description = c.Description ?? "",
                    Icon = c.Icon ?? "",
                    TotalProduct = productCounts.FirstOrDefault(pc => pc.CategoryId == c.CategoryID)?.Count ?? 0
                }).ToList();
                return new CommonPagination<GetAllCategoryRes>
                {
                    Success = true,
                    Message = "Lấy danh sách danh mục thành công",
                    Data = data,
                    TotalRecords = total
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetAllCategoryRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = new List<GetAllCategoryRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<CommonResponse<GetGenderRes>> GetGender()
        {
            var response = new CommonResponse<GetGenderRes>();
            try
            {
                var gender = await _genderRepository.AsQueryable().FirstOrDefaultAsync();
                if (gender == null)
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy giới tính.";
                    response.Data = null;
                    return response;
                }
                response.Success = true;
                response.Message = "Lấy giới tính thành công.";
                response.Data = new GetGenderRes
                {
                    GenderId = gender.GenderID,
                    Name = gender.Name
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Lỗi: {ex.Message}";
                response.Data = null;
            }
            return response;
        }

        #endregion
    }
}
