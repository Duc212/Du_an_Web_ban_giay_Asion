using BUS.Services.Interfaces;
using DAL.DTOs.Carts.Req;
using DAL.DTOs.Carts.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class CartServices : ICartServices
    {
        private readonly IRepositoryAsync<Cart> _cartRepository;
        private readonly IRepositoryAsync<CartItem> _cartItemRepository;
        private readonly IRepositoryAsync<ProductVariant> _productVariantRepository;
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IRepositoryAsync<Color> _colorRepository;
        private readonly IRepositoryAsync<Size> _sizeRepository;
        private readonly IRepositoryAsync<Brand> _brandRepository;
        private readonly IRepositoryAsync<ProductImage> _productImageRepository;

        public CartServices(
            IRepositoryAsync<Cart> cartRepository,
            IRepositoryAsync<CartItem> cartItemRepository,
            IRepositoryAsync<ProductVariant> productVariantRepository,
            IRepositoryAsync<Product> productRepository,
            IRepositoryAsync<Color> colorRepository,
            IRepositoryAsync<Size> sizeRepository,
            IRepositoryAsync<Brand> brandRepository,
            IRepositoryAsync<ProductImage> productImageRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productVariantRepository = productVariantRepository;
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _brandRepository = brandRepository;
            _productImageRepository = productImageRepository;
        }

        public async Task<CommonResponse<CartSummaryRes>> AddToCartAsync(int userId, AddToCartReq request)
        {
            try
            {
                var variant = await (from v in _productVariantRepository.AsNoTrackingQueryable()
                                     join c in _colorRepository.AsNoTrackingQueryable() on v.ColorID equals c.ColorID
                                     join s in _sizeRepository.AsNoTrackingQueryable() on v.SizeID equals s.SizeID
                                     where v.ProductID == request.ProductId &&
                                           (c.HexCode == request.SelectedColor || c.Name == request.SelectedColor) &&
                                           s.Value == request.SelectedSize
                                     select v)
                    .FirstOrDefaultAsync();

                if (variant == null)
                {
                    return new CommonResponse<CartSummaryRes>
                    {
                        Success = false,
                        Message = $"Sản phẩm với màu '{request.SelectedColor}' và size '{request.SelectedSize}' không tồn tại"
                    };
                }

                // Check stock
                if (variant.StockQuantity < request.Quantity)
                {
                    return new CommonResponse<CartSummaryRes>
                    {
                        Success = false,
                        Message = $"Chỉ còn {variant.StockQuantity} sản phẩm trong kho"
                    };
                }

                // Get or create user cart
                var cart = await _cartRepository.AsQueryable()
                    .FirstOrDefaultAsync(c => c.UserID == userId);

                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserID = userId,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _cartRepository.AddAsync(cart);
                    await _cartRepository.SaveChangesAsync();
                }

                // Check if item already exists in cart
                var existingCartItem = await _cartItemRepository.AsQueryable()
                    .FirstOrDefaultAsync(ci => ci.CartID == cart.CartID && ci.VariantID == variant.VariantID);

                if (existingCartItem != null)
                {
                    // Update quantity
                    var newQuantity = existingCartItem.Quantity + request.Quantity;

                    if (newQuantity > variant.StockQuantity)
                    {
                        return new CommonResponse<CartSummaryRes>
                        {
                            Success = false,
                            Message = $"Số lượng vượt quá tồn kho. Hiện tại trong giỏ: {existingCartItem.Quantity}, tồn kho: {variant.StockQuantity}"
                        };
                    }

                    existingCartItem.Quantity = newQuantity;
                    await _cartItemRepository.UpdateAsync(existingCartItem);
                }
                else
                {
                    // Add new cart item
                    var cartItem = new CartItem
                    {
                        CartID = cart.CartID,
                        VariantID = variant.VariantID,
                        Quantity = request.Quantity
                    };
                    await _cartItemRepository.AddAsync(cartItem);
                }

                await _cartItemRepository.SaveChangesAsync();

                // Return updated cart
                var cartSummary = await GetCartAsync(userId);
                return new CommonResponse<CartSummaryRes>
                {
                    Success = true,
                    Message = "Thêm vào giỏ hàng thành công",
                    Data = cartSummary.Data
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<CartSummaryRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<CartSummaryRes>> GetCartAsync(int userId)
        {
            try
            {
                var cart = await _cartRepository.AsNoTrackingQueryable()
                    .FirstOrDefaultAsync(c => c.UserID == userId);

                if (cart == null)
                {
                    return new CommonResponse<CartSummaryRes>
                    {
                        Success = true,
                        Message = "Giỏ hàng trống",
                        Data = new CartSummaryRes { CartID = 0 }
                    };
                }

                // Get cart items with product details
                var cartItems = await (from ci in _cartItemRepository.AsNoTrackingQueryable()
                                       join v in _productVariantRepository.AsNoTrackingQueryable() on ci.VariantID equals v.VariantID
                                       join p in _productRepository.AsNoTrackingQueryable() on v.ProductID equals p.ProductID
                                       join b in _brandRepository.AsNoTrackingQueryable() on p.BrandId equals b.BrandID
                                       join c in _colorRepository.AsNoTrackingQueryable() on v.ColorID equals c.ColorID into colors
                                       from color in colors.DefaultIfEmpty()
                                       join s in _sizeRepository.AsNoTrackingQueryable() on v.SizeID equals s.SizeID into sizes
                                       from size in sizes.DefaultIfEmpty()
                                       where ci.CartID == cart.CartID
                                       select new { ci, v, p, b, color, size })
                    .ToListAsync();

                // Get product images
                var productIds = cartItems.Select(x => x.p.ProductID).Distinct().ToList();
                var images = await _productImageRepository.AsNoTrackingQueryable()
                    .Where(img => productIds.Contains(img.ProductID) && img.IsActive)
                    .ToListAsync();

                var imageDict = images.GroupBy(img => new { img.ProductID, img.ColorID })
                    .ToDictionary(g => g.Key, g => g.OrderBy(img => img.DisplayOrder).First().ImageUrl);

                var cartItemList = cartItems.Select(item =>
                {
                    var imageKey = new { ProductID = item.p.ProductID, ColorID = item.color?.ColorID ?? 0 };

                    // Get all images for this color
                    var colorImages = images
                   .Where(img => img.ProductID == item.p.ProductID && img.ColorID == item.color?.ColorID)
                         .OrderBy(img => img.DisplayOrder)
                    .Select(img => img.ImageUrl)
                         .ToList();

                    // Primary image with fallback
                    var primaryImage = colorImages.FirstOrDefault() ??
                        imageDict.GetValueOrDefault(imageKey, item.p.ImageUrl ?? "/images/products/default-shoe.jpg");

                    return new CartItemRes
                    {
                        CartItemID = item.ci.CartItemID,
                        ProductID = item.p.ProductID,
                        ProductName = item.p.Name,
                        Brand = item.b.Name,
                        Color = item.color?.Name ?? "N/A",
                        ColorHex = item.color?.HexCode ?? "#000000",
                        Size = item.size?.Value ?? "N/A",
                        Quantity = item.ci.Quantity,
                        Price = item.v.SellingPrice,
                        ImageUrl = primaryImage,
                        Images = colorImages.Any() ? colorImages : new List<string> { primaryImage },
                        StockQuantity = item.v.StockQuantity,
                        VariantID = item.v.VariantID
                    };
                }).ToList();

                return new CommonResponse<CartSummaryRes>
                {
                    Success = true,
                    Message = "Lấy giỏ hàng thành công",
                    Data = new CartSummaryRes
                    {
                        CartID = cart.CartID,
                        Items = cartItemList
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<CartSummaryRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<CartItemRes>> UpdateCartItemAsync(int userId, int cartItemId, int quantity)
        {
            try
            {
                // Validate quantity
                if (quantity <= 0)
                {
                    return new CommonResponse<CartItemRes>
                    {
                        Success = false,
                        Message = "Số lượng phải lớn hơn 0"
                    };
                }

                // Get cart item
                var cartItem = await (from ci in _cartItemRepository.AsQueryable()
                                      join c in _cartRepository.AsQueryable() on ci.CartID equals c.CartID
                                      join v in _productVariantRepository.AsQueryable() on ci.VariantID equals v.VariantID
                                      where ci.CartItemID == cartItemId && c.UserID == userId
                                      select new { ci, v })
                    .FirstOrDefaultAsync();

                if (cartItem == null)
                {
                    return new CommonResponse<CartItemRes>
                    {
                        Success = false,
                        Message = "Sản phẩm không tồn tại trong giỏ hàng"
                    };
                }

                // Check stock
                if (quantity > cartItem.v.StockQuantity)
                {
                    return new CommonResponse<CartItemRes>
                    {
                        Success = false,
                        Message = $"Chỉ còn {cartItem.v.StockQuantity} sản phẩm trong kho"
                    };
                }

                // Update quantity
                cartItem.ci.Quantity = quantity;
                await _cartItemRepository.UpdateAsync(cartItem.ci);
                await _cartItemRepository.SaveChangesAsync();

                return new CommonResponse<CartItemRes>
                {
                    Success = true,
                    Message = "Cập nhật số lượng thành công"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<CartItemRes>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<string>> RemoveCartItemAsync(int userId, int cartItemId)
        {
            try
            {
                // Get cart item
                var cartItem = await (from ci in _cartItemRepository.AsQueryable()
                                      join c in _cartRepository.AsQueryable() on ci.CartID equals c.CartID
                                      where ci.CartItemID == cartItemId && c.UserID == userId
                                      select ci)
                    .FirstOrDefaultAsync();

                if (cartItem == null)
                {
                    return new CommonResponse<string>
                    {
                        Success = false,
                        Message = "Sản phẩm không tồn tại trong giỏ hàng"
                    };
                }

                await _cartItemRepository.RemoveAsync(cartItem);
                await _cartItemRepository.SaveChangesAsync();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Xóa sản phẩm khỏi giỏ hàng thành công"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<CommonResponse<string>> ClearCartAsync(int userId)
        {
            try
            {
                var cart = await _cartRepository.AsQueryable()
                    .Include(c => c.CartItems)
                    .FirstOrDefaultAsync(c => c.UserID == userId);

                if (cart == null || !cart.CartItems.Any())
                {
                    return new CommonResponse<string>
                    {
                        Success = true,
                        Message = "Giỏ hàng đã trống"
                    };
                }

                await _cartItemRepository.RemoveRangeAsync(cart.CartItems);
                await _cartItemRepository.SaveChangesAsync();

                return new CommonResponse<string>
                {
                    Success = true,
                    Message = "Xóa toàn bộ giỏ hàng thành công"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }
    }
}