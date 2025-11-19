using BUS.Services.Interfaces;
using DAL.DTOs.Products.Req;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using DAL.UnitOfWork;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class ProductAdminServices : IProductAdminServices
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IRepositoryAsync<ProductVariant> _productVariantRepository;
        private readonly IRepositoryAsync<ProductImage> _productImageRepository;
        private readonly IRepositoryAsync<Color> _colorRepository;
        private readonly IRepositoryAsync<Size> _sizeRepository;
        private readonly IRepositoryAsync<Brand> _brandRepository;
        private readonly IRepositoryAsync<Category> _categoryRepository;
        private readonly IRepositoryAsync<Gender> _genderRepository;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public ProductAdminServices(
            IRepositoryAsync<Product> productRepository,
            IRepositoryAsync<ProductVariant> productVariantRepository,
            IRepositoryAsync<ProductImage> productImageRepository,
            IRepositoryAsync<Color> colorRepository,
            IRepositoryAsync<Size> sizeRepository,
            IRepositoryAsync<Brand> brandRepository,
            IRepositoryAsync<Category> categoryRepository,
            IRepositoryAsync<Gender> genderRepository,
            IUnitOfWork<AppDbContext> unitOfWork)
        {
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
            _productImageRepository = productImageRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _genderRepository = genderRepository;
            _unitOfWork = unitOfWork;
        }

        #region CRUD Product

        public async Task<CommonPagination<GetProductAdminRes>> GetAllProducts(
            int pageIndex, 
            int pageSize, 
            string? keyword = null, 
            int? categoryId = null, 
            int? brandId = null, 
            string? sortBy = null, 
            string? sortOrder = null)
        {
            try
            {
                if (pageIndex < 1) pageIndex = 1;
                if (pageSize < 1) pageSize = 10;

                var query = from p in _productRepository.AsNoTrackingQueryable()
                            join b in _brandRepository.AsNoTrackingQueryable() on p.BrandId equals b.BrandID
                            join c in _categoryRepository.AsNoTrackingQueryable() on p.CategoryId equals c.CategoryID
                            join g in _genderRepository.AsNoTrackingQueryable() on p.GenderId equals g.GenderID
                            select new { p, b, c, g };

                // Filter by keyword
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(x => x.p.Name.Contains(keyword) || x.p.Description.Contains(keyword));
                }

                // Filter by category
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query = query.Where(x => x.p.CategoryId == categoryId.Value);
                }

                // Filter by brand
                if (brandId.HasValue && brandId.Value > 0)
                {
                    query = query.Where(x => x.p.BrandId == brandId.Value);
                }

                // Sorting
                query = sortBy?.ToLower() switch
                {
                    "name" => sortOrder?.ToLower() == "desc" 
                        ? query.OrderByDescending(x => x.p.Name) 
                        : query.OrderBy(x => x.p.Name),
                    "createdat" => sortOrder?.ToLower() == "desc" 
                        ? query.OrderByDescending(x => x.p.CreatedAt) 
                        : query.OrderBy(x => x.p.CreatedAt),
                    _ => query.OrderByDescending(x => x.p.CreatedAt)
                };

                var totalRecords = await query.CountAsync();

                var products = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var productIds = products.Select(x => x.p.ProductID).ToList();

                // Get variants info
                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIds.Contains(v.ProductID))
                    .ToListAsync();

                var variantsByProduct = variants.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                var result = products.Select(x =>
                {
                    var productVariants = variantsByProduct.GetValueOrDefault(x.p.ProductID, new List<ProductVariant>());
                    
                    return new GetProductAdminRes
                    {
                        ProductID = x.p.ProductID,
                        Name = x.p.Name,
                        Description = x.p.Description,
                        ImageUrl = x.p.ImageUrl,
                        BrandId = x.b.BrandID,
                        BrandName = x.b.Name,
                        CategoryId = x.c.CategoryID,
                        CategoryName = x.c.Name,
                        GenderId = x.g.GenderID,
                        GenderName = x.g.Name,
                        TotalStock = productVariants.Sum(v => v.StockQuantity),
                        MinPrice = productVariants.Any() ? productVariants.Min(v => v.SellingPrice) : 0,
                        MaxPrice = productVariants.Any() ? productVariants.Max(v => v.SellingPrice) : 0,
                        VariantCount = productVariants.Count,
                        CreatedAt = x.p.CreatedAt
                    };
                }).ToList();

                return new CommonPagination<GetProductAdminRes>
                {
                    Success = true,
                    Message = "L?y danh s�ch s?n ph?m th�nh c�ng",
                    Data = result,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetProductAdminRes>
                {
                    Success = false,
                    Message = $"L?i: {ex.Message}",
                    Data = new List<GetProductAdminRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<CommonResponse<GetProductDetailAdminRes>> GetProductDetail(int productId)
        {
            var response = new CommonResponse<GetProductDetailAdminRes>();

            try
            {
                var product = await _productRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(p => p.ProductID == productId);

                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Kh�ng t�m th?y s?n ph?m";
                    return response;
                }

                var brand = await _brandRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(b => b.BrandID == product.BrandId);

                var category = await _categoryRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(c => c.CategoryID == product.CategoryId);

                var gender = await _genderRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(g => g.GenderID == product.GenderId);

                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => v.ProductID == productId)
                    .Include(v => v.Color)
                    .Include(v => v.Size)
                    .Select(v => new GetVariantRes
                    {
                        VariantID = v.VariantID,
                        ColorID = v.ColorID ?? 0,
                        ColorName = v.Color != null ? v.Color.Name : "",
                        ColorHex = v.Color != null ? v.Color.HexCode : "",
                        SizeID = v.SizeID ?? 0,
                        SizeValue = v.Size != null ? v.Size.Value : "",
                        ImportPrice = v.ImportPrice,
                        SellingPrice = v.SellingPrice,
                        StockQuantity = v.StockQuantity,
                        Status = v.Status
                    })
                    .ToListAsync();

                var images = await _productImageRepository.AsNoTrackingQueryable()
                    .Where(img => img.ProductID == productId)
                    .Include(img => img.Color)
                    .OrderBy(img => img.DisplayOrder)
                    .Select(img => new GetProductImageRes
                    {
                        ImageID = img.ImageID,
                        ColorID = img.ColorID,
                        ColorName = img.Color != null ? img.Color.Name : "",
                        ImageUrl = img.ImageUrl,
                        DisplayOrder = img.DisplayOrder,
                        ImageType = img.ImageType,
                        IsDefault = img.IsDefault,
                        IsActive = img.IsActive
                    })
                    .ToListAsync();

                response.Success = true;
                response.Message = "L?y chi ti?t s?n ph?m th�nh c�ng";
                response.Data = new GetProductDetailAdminRes
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    BrandId = product.BrandId,
                    BrandName = brand?.Name ?? "",
                    CategoryId = product.CategoryId,
                    CategoryName = category?.Name ?? "",
                    GenderId = product.GenderId,
                    GenderName = gender?.Name ?? "",
                    CreatedAt = product.CreatedAt,
                    Variants = variants,
                    Images = images
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
            }

            return response;
        }

        public async Task<CommonResponse<bool>> AddProduct(AddProductReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(req.Name))
                {
                    response.Success = false;
                    response.Message = "T�n s?n ph?m kh�ng ???c tr?ng";
                    response.Data = false;
                    return response;
                }

                // Check duplicate name
                var existingProduct = await _productRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(p => p.Name == req.Name);

                if (existingProduct != null)
                {
                    response.Success = false;
                    response.Message = "T�n s?n ph?m ?� t?n t?i";
                    response.Data = false;
                    return response;
                }

                // Create product
                var product = new Product
                {
                    Name = req.Name,
                    Description = req.Description ?? "",
                    ImageUrl = req.ImageUrl ?? "",
                    BrandId = req.BrandId,
                    CategoryId = req.CategoryId,
                    GenderId = req.GenderId,
                    CreatedAt = DateTime.UtcNow
                };

                await _productRepository.AddAsync(product);
                await _productRepository.SaveChangesAsync();

                // Add variants
                if (req.Variants != null && req.Variants.Any())
                {
                    foreach (var variantDto in req.Variants)
                    {
                        var variant = new ProductVariant
                        {
                            ProductID = product.ProductID,
                            ColorID = variantDto.ColorID,
                            SizeID = variantDto.SizeID,
                            ImportPrice = variantDto.ImportPrice,
                            SellingPrice = variantDto.SellingPrice,
                            StockQuantity = variantDto.StockQuantity,
                            Status = "Active"
                        };
                        await _productVariantRepository.AddAsync(variant);
                    }
                    await _productVariantRepository.SaveChangesAsync();
                }

                // Add images
                if (req.Images != null && req.Images.Any())
                {
                    foreach (var imageDto in req.Images)
                    {
                        var image = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ColorID = imageDto.ColorID,
                            ImageUrl = imageDto.ImageUrl,
                            DisplayOrder = imageDto.DisplayOrder,
                            ImageType = imageDto.ImageType,
                            IsDefault = imageDto.IsDefault,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        };
                        await _productImageRepository.AddAsync(image);
                    }
                    await _productImageRepository.SaveChangesAsync();
                }

                response.Success = true;
                response.Message = "Th�m s?n ph?m th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> UpdateProduct(UpdateProductReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                var product = await _productRepository.AsQueryable()
                    .FirstOrDefaultAsync(p => p.ProductID == req.ProductID);

                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Kh�ng t�m th?y s?n ph?m";
                    response.Data = false;
                    return response;
                }

                // Check duplicate name (exclude current product)
                var duplicate = await _productRepository.AsNoTrackingQueryable()
                    .AnyAsync(p => p.ProductID != req.ProductID && p.Name == req.Name);

                if (duplicate)
                {
                    response.Success = false;
                    response.Message = "T�n s?n ph?m ?� ???c s? d?ng";
                    response.Data = false;
                    return response;
                }

                // Update product
                product.Name = req.Name;
                product.Description = req.Description ?? "";
                product.ImageUrl = req.ImageUrl ?? "";
                product.BrandId = req.BrandId;
                product.CategoryId = req.CategoryId;
                product.GenderId = req.GenderId;

                await _productRepository.UpdateAsync(product);
                await _productRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "C?p nh?t s?n ph?m th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> DeleteProduct(int productId)
        {
            var response = new CommonResponse<bool>();

            try
            {
                var product = await _productRepository.AsQueryable()
                    .FirstOrDefaultAsync(p => p.ProductID == productId);

                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Kh�ng t�m th?y s?n ph?m";
                    response.Data = false;
                    return response;
                }

                // Check if product has orders (optional - add OrderDetail check if needed)
                // For now, we'll allow deletion and cascade delete variants and images

                // Delete variants
                var variants = await _productVariantRepository.AsQueryable()
                    .Where(v => v.ProductID == productId)
                    .ToListAsync();

                foreach (var variant in variants)
                {
                    await _productVariantRepository.RemoveAsync(variant);
                }

                // Delete images
                var images = await _productImageRepository.AsQueryable()
                    .Where(img => img.ProductID == productId)
                    .ToListAsync();

                foreach (var image in images)
                {
                    await _productImageRepository.RemoveAsync(image);
                }

                // Delete product
                await _productRepository.RemoveAsync(product);
                await _productRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "X�a s?n ph?m th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        #endregion

        #region Variant Management

        public async Task<CommonResponse<List<GetVariantRes>>> GetProductVariants(int productId)
        {
            var response = new CommonResponse<List<GetVariantRes>>();

            try
            {
                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => v.ProductID == productId)
                    .Include(v => v.Color)
                    .Include(v => v.Size)
                    .Select(v => new GetVariantRes
                    {
                        VariantID = v.VariantID,
                        ColorID = v.ColorID ?? 0,
                        ColorName = v.Color != null ? v.Color.Name : "",
                        ColorHex = v.Color != null ? v.Color.HexCode : "",
                        SizeID = v.SizeID ?? 0,
                        SizeValue = v.Size != null ? v.Size.Value : "",
                        ImportPrice = v.ImportPrice,
                        SellingPrice = v.SellingPrice,
                        StockQuantity = v.StockQuantity,
                        Status = v.Status
                    })
                    .ToListAsync();

                response.Success = true;
                response.Message = "L?y danh s�ch variant th�nh c�ng";
                response.Data = variants;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = new List<GetVariantRes>();
            }

            return response;
        }

        public async Task<CommonResponse<bool>> AddVariant(AddVariantReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                // Check if variant already exists
                var existingVariant = await _productVariantRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(v => v.ProductID == req.ProductID 
                                            && v.ColorID == req.ColorID 
                                            && v.SizeID == req.SizeID);

                if (existingVariant != null)
                {
                    response.Success = false;
                    response.Message = "Variant n�y ?� t?n t?i (tr�ng m�u v� size)";
                    response.Data = false;
                    return response;
                }

                var variant = new ProductVariant
                {
                    ProductID = req.ProductID,
                    ColorID = req.ColorID,
                    SizeID = req.SizeID,
                    ImportPrice = req.ImportPrice,
                    SellingPrice = req.SellingPrice,
                    StockQuantity = req.StockQuantity,
                    Status = "Active"
                };

                await _productVariantRepository.AddAsync(variant);
                await _productVariantRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "Th�m variant th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> UpdateVariant(UpdateVariantReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                var variant = await _productVariantRepository.AsQueryable()
                    .FirstOrDefaultAsync(v => v.VariantID == req.VariantID);

                if (variant == null)
                {
                    response.Success = false;
                    response.Message = "Kh�ng t�m th?y variant";
                    response.Data = false;
                    return response;
                }

                variant.ImportPrice = req.ImportPrice;
                variant.SellingPrice = req.SellingPrice;
                variant.StockQuantity = req.StockQuantity;
                variant.Status = req.Status;

                await _productVariantRepository.UpdateAsync(variant);
                await _productVariantRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "C?p nh?t variant th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> DeleteVariant(int variantId)
        {
            var response = new CommonResponse<bool>();

            try
            {
                var variant = await _productVariantRepository.AsQueryable()
                    .FirstOrDefaultAsync(v => v.VariantID == variantId);

                if (variant == null)
                {
                    response.Success = false;
                    response.Message = "Kh�ng t�m th?y variant";
                    response.Data = false;
                    return response;
                }

                await _productVariantRepository.RemoveAsync(variant);
                await _productVariantRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "X�a variant th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public async Task<CommonResponse<bool>> UpdateStock(UpdateStockReq req)
        {
            var response = new CommonResponse<bool>();

            try
            {
                if (req.Items == null || !req.Items.Any())
                {
                    response.Success = false;
                    response.Message = "Danh s�ch c?p nh?t tr?ng";
                    response.Data = false;
                    return response;
                }

                var variantIds = req.Items.Select(i => i.VariantID).ToList();
                var variants = await _productVariantRepository.AsQueryable()
                    .Where(v => variantIds.Contains(v.VariantID))
                    .ToListAsync();

                foreach (var item in req.Items)
                {
                    var variant = variants.FirstOrDefault(v => v.VariantID == item.VariantID);
                    if (variant != null)
                    {
                        variant.StockQuantity = item.NewStock;
                        await _productVariantRepository.UpdateAsync(variant);
                    }
                }

                await _productVariantRepository.SaveChangesAsync();

                response.Success = true;
                response.Message = "C?p nh?t t?n kho th�nh c�ng";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        #endregion

        #region Support APIs

        public async Task<CommonResponse<List<GetColorRes>>> GetColors()
        {
            var response = new CommonResponse<List<GetColorRes>>();

            try
            {
                var colors = await _colorRepository.AsNoTrackingQueryable()
                    .Select(c => new GetColorRes
                    {
                        ColorID = c.ColorID,
                        ColorName = c.Name,
                        HexColor = c.HexCode
                    })
                    .ToListAsync();

                response.Success = true;
                response.Message = "L?y danh s�ch m�u th�nh c�ng";
                response.Data = colors;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = new List<GetColorRes>();
            }

            return response;
        }

        public async Task<CommonResponse<List<GetSizeRes>>> GetSizes()
        {
            var response = new CommonResponse<List<GetSizeRes>>();

            try
            {
                var sizes = await _sizeRepository.AsNoTrackingQueryable()
                    .Select(s => new GetSizeRes
                    {
                        SizeID = s.SizeID,
                        Value = s.Value
                    })
                    .OrderBy(s => s.Value)
                    .ToListAsync();

                response.Success = true;
                response.Message = "L?y danh s�ch size th�nh c�ng";
                response.Data = sizes;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = new List<GetSizeRes>();
            }

            return response;
        }

        public async Task<CommonResponse<List<GetGenderRes>>> GetGenders()
        {
            var response = new CommonResponse<List<GetGenderRes>>();

            try
            {
                var genders = await _genderRepository.AsNoTrackingQueryable()
                    .Select(g => new GetGenderRes
                    {
                        GenderId = g.GenderID,
                        Name = g.Name
                    })
                    .ToListAsync();

                response.Success = true;
                response.Message = "L?y danh s�ch gi?i t�nh th�nh c�ng";
                response.Data = genders;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
                response.Data = new List<GetGenderRes>();
            }

            return response;
        }

        public async Task<CommonResponse<GetProductStatisticsRes>> GetProductStatistics()
        {
            var response = new CommonResponse<GetProductStatisticsRes>();

            try
            {
                var products = await _productRepository.AsNoTrackingQueryable().ToListAsync();
                var variants = await _productVariantRepository.AsNoTrackingQueryable().ToListAsync();

                var totalProducts = products.Count;
                var outOfStockProducts = variants.GroupBy(v => v.ProductID)
                    .Count(g => g.Sum(v => v.StockQuantity) == 0);
                var lowStockProducts = variants.GroupBy(v => v.ProductID)
                    .Count(g => g.Sum(v => v.StockQuantity) > 0 && g.Sum(v => v.StockQuantity) < 10);
                var totalInventoryValue = variants.Sum(v => v.ImportPrice * v.StockQuantity);

                // Category stats
                var categoryStats = await (from p in _productRepository.AsNoTrackingQueryable()
                                           join c in _categoryRepository.AsNoTrackingQueryable() on p.CategoryId equals c.CategoryID
                                           group p by new { c.CategoryID, c.Name } into g
                                           select new CategoryStatistic
                                           {
                                               CategoryID = g.Key.CategoryID,
                                               CategoryName = g.Key.Name,
                                               ProductCount = g.Count(),
                                               TotalStock = variants.Where(v => g.Select(p => p.ProductID).Contains(v.ProductID)).Sum(v => v.StockQuantity)
                                           }).ToListAsync();

                // Brand stats
                var brandStats = await (from p in _productRepository.AsNoTrackingQueryable()
                                        join b in _brandRepository.AsNoTrackingQueryable() on p.BrandId equals b.BrandID
                                        group p by new { b.BrandID, b.Name } into g
                                        select new BrandStatistic
                                        {
                                            BrandID = g.Key.BrandID,
                                            BrandName = g.Key.Name,
                                            ProductCount = g.Count(),
                                            TotalStock = variants.Where(v => g.Select(p => p.ProductID).Contains(v.ProductID)).Sum(v => v.StockQuantity)
                                        }).ToListAsync();

                response.Success = true;
                response.Message = "L?y th?ng k� th�nh c�ng";
                response.Data = new GetProductStatisticsRes
                {
                    TotalProducts = totalProducts,
                    ActiveProducts = totalProducts - outOfStockProducts,
                    OutOfStockProducts = outOfStockProducts,
                    LowStockProducts = lowStockProducts,
                    TotalInventoryValue = totalInventoryValue,
                    CategoryStats = categoryStats,
                    BrandStats = brandStats
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"L?i: {ex.Message}";
            }

            return response;
        }

        public async Task<CommonPagination<GetProductAdminRes>> GetLowStockProducts(int pageIndex, int pageSize, int threshold = 10)
        {
            try
            {
                if (pageIndex < 1) pageIndex = 1;
                if (pageSize < 1) pageSize = 10;

                var query = from p in _productRepository.AsNoTrackingQueryable()
                            join b in _brandRepository.AsNoTrackingQueryable() on p.BrandId equals b.BrandID
                            join c in _categoryRepository.AsNoTrackingQueryable() on p.CategoryId equals c.CategoryID
                            join g in _genderRepository.AsNoTrackingQueryable() on p.GenderId equals g.GenderID
                            select new { p, b, c, g };

                var allProducts = await query.ToListAsync();
                var productIds = allProducts.Select(x => x.p.ProductID).ToList();

                var variants = await _productVariantRepository.AsNoTrackingQueryable()
                    .Where(v => productIds.Contains(v.ProductID))
                    .ToListAsync();

                var variantsByProduct = variants.GroupBy(v => v.ProductID).ToDictionary(g => g.Key, g => g.ToList());

                // Filter low stock products
                var lowStockProducts = allProducts
                    .Where(x =>
                    {
                        var productVariants = variantsByProduct.GetValueOrDefault(x.p.ProductID, new List<ProductVariant>());
                        var totalStock = productVariants.Sum(v => v.StockQuantity);
                        return totalStock > 0 && totalStock < threshold;
                    })
                    .ToList();

                var totalRecords = lowStockProducts.Count;

                var pagedProducts = lowStockProducts
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var result = pagedProducts.Select(x =>
                {
                    var productVariants = variantsByProduct.GetValueOrDefault(x.p.ProductID, new List<ProductVariant>());

                    return new GetProductAdminRes
                    {
                        ProductID = x.p.ProductID,
                        Name = x.p.Name,
                        Description = x.p.Description,
                        ImageUrl = x.p.ImageUrl,
                        BrandId = x.b.BrandID,
                        BrandName = x.b.Name,
                        CategoryId = x.c.CategoryID,
                        CategoryName = x.c.Name,
                        GenderId = x.g.GenderID,
                        GenderName = x.g.Name,
                        TotalStock = productVariants.Sum(v => v.StockQuantity),
                        MinPrice = productVariants.Any() ? productVariants.Min(v => v.SellingPrice) : 0,
                        MaxPrice = productVariants.Any() ? productVariants.Max(v => v.SellingPrice) : 0,
                        VariantCount = productVariants.Count,
                        CreatedAt = x.p.CreatedAt
                    };
                }).ToList();

                return new CommonPagination<GetProductAdminRes>
                {
                    Success = true,
                    Message = "L?y danh s�ch s?n ph?m s?p h?t h�ng th�nh c�ng",
                    Data = result,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                return new CommonPagination<GetProductAdminRes>
                {
                    Success = false,
                    Message = $"L?i: {ex.Message}",
                    Data = new List<GetProductAdminRes>(),
                    TotalRecords = 0
                };
            }
        }

        public async Task<CommonResponse<bool>> AddProductImage(AddProductImageReq req)
        {
            try
            {
                // Validate product exists
                var product = await _productRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(p => p.ProductID == req.ProductID);
                if (product == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy sản phẩm"
                    };
                }

                // Validate color exists
                var color = await _colorRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(c => c.ColorID == req.ColorID);
                if (color == null)
                {
                    return new CommonResponse<bool>
                    {
                        Success = false,
                        Message = "Không tìm thấy màu sắc"
                    };
                }

                // Create new product image
                var productImage = new ProductImage
                {
                    ProductID = req.ProductID,
                    ColorID = req.ColorID,
                    ImageUrl = req.ImageUrl,
                    DisplayOrder = req.DisplayOrder,
                    ImageType = req.ImageType,
                    IsDefault = req.IsDefault,
                    CreatedAt = DateTime.Now
                };

                await _productImageRepository.AddAsync(productImage);
                await _unitOfWork.SaveChangesAsync();

                return new CommonResponse<bool>
                {
                    Success = true,
                    Message = "Thêm ảnh sản phẩm thành công",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

        #endregion
    }
}
