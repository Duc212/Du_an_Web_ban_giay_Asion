using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;
using WebUI.Models;
using WebUI.Models.Cart;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    public class CartItem
    {
        public Product Product { get; set; } = new();
        public int VariantID { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public decimal VariantPrice { get; set; } = 0; // Giá của variant cụ thể (màu + size)
        public decimal TotalPrice => VariantPrice * Quantity;
    }

    public class CartService
    {
        private readonly List<CartItem> _items = new();
        private readonly HttpClient _httpClient;
        private readonly ConfigurationService _configService;
        private readonly IAuthService? _authService;
        private readonly IJSRuntime _jsRuntime;

        // Selected items for checkout (API cart item IDs)
        public HashSet<int> SelectedApiCartItemIds { get; set; } = new();

        // Selected items for checkout (local cart product IDs)
        public HashSet<int> SelectedLocalProductIds { get; set; } = new();

        // Checkout information
        public CheckoutInfo? CheckoutInfo { get; set; }

        public event Action? OnCartChanged;

        public CartService(HttpClient httpClient, ConfigurationService configService, IAuthService authService, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _configService = configService;
            _authService = authService;
            _jsRuntime = jsRuntime;

            // Subscribe to auth state changes to migrate guest cart
            _authService.AuthStateChanged += async (s, isAuth) =>
            {
                if (isAuth)
                {
                    try
                    {
                        await MigrateGuestCartToUserAsync();
                        await RefreshApiCartToLocalAsync();
                        OnCartChanged?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CartService] Migrate error: {ex.Message}");
                    }
                }
                else
                {
                    // When logging out keep current local items (already in _items)
                    OnCartChanged?.Invoke();
                }
            };
        }

        public List<CartItem> GetItems() => _items.ToList();

        public int GetTotalItems() => _items.Sum(item => item.Quantity);

        public decimal GetTotalPrice() => _items.Sum(item => item.TotalPrice);

        public void AddItem(Product product, int quantity = 1, string? size = null, string? color = null, int variantId = 0)
        {
            // Calculate variant-specific price
            decimal variantPrice = product.Price; // Default to product price
            
            if (!string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(size) && product.Colors != null)
            {
                var colorInfo = product.Colors.FirstOrDefault(c => c.HexColor != null && c.HexColor.Equals(color, StringComparison.OrdinalIgnoreCase));
                if (colorInfo?.SizePrice != null && colorInfo.SizePrice.TryGetValue(size, out decimal specificPrice))
                {
                    variantPrice = specificPrice;
                    Console.WriteLine($"[CartService.AddItem] Found variant price: {variantPrice} for Color={color}, Size={size}");
                }
                else
                {
                    Console.WriteLine($"[CartService.AddItem] Warning: Could not find variant price for Color={color}, Size={size}, using default Product.Price={product.Price}");
                }
            }
            
            var existingItem = _items.FirstOrDefault(item =>
                item.Product.Id == product.Id &&
                item.SelectedSize == size &&
                item.SelectedColor == color);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                Console.WriteLine($"[CartService.AddItem] Updated existing item: ProductID={product.Id}, Qty={existingItem.Quantity}, VariantPrice={existingItem.VariantPrice}");
            }
            else
            {
                _items.Add(new CartItem
                {
                    Product = product,
                    VariantID = variantId,
                    Quantity = quantity,
                    SelectedSize = size,
                    SelectedColor = color,
                    VariantPrice = variantPrice
                });
                Console.WriteLine($"[CartService.AddItem] Added new item: ProductID={product.Id}, Qty={quantity}, VariantPrice={variantPrice}");
            }

            OnCartChanged?.Invoke();
        }

        public void RemoveItem(int productId, string? size = null, string? color = null)
        {
            var itemToRemove = _items.FirstOrDefault(item =>
                item.Product.Id == productId &&
                item.SelectedSize == size &&
                item.SelectedColor == color);

            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                OnCartChanged?.Invoke();
            }
        }

        public void RemoveItem(int productId, int quantity, string? size = null, string? color = null)
        {
            var item = _items.FirstOrDefault(item =>
                item.Product.Id == productId &&
                item.SelectedSize == size &&
                item.SelectedColor == color);

            if (item != null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                {
                    _items.Remove(item);
                }
                OnCartChanged?.Invoke();
            }
        }

        public void UpdateQuantity(int productId, int newQuantity, string? size = null, string? color = null)
        {
            var item = _items.FirstOrDefault(item =>
                item.Product.Id == productId &&
                item.SelectedSize == size &&
                item.SelectedColor == color);

            if (item != null)
            {
                if (newQuantity <= 0)
                {
                    RemoveItem(productId, size, color);
                }
                else
                {
                    item.Quantity = newQuantity;
                    OnCartChanged?.Invoke();
                }
            }
        }

        public void ClearCart()
        {
            _items.Clear();
            OnCartChanged?.Invoke();
        }

        public bool HasItem(int productId, string? size = null, string? color = null)
        {
            return _items.Any(item =>
                item.Product.Id == productId &&
                item.SelectedSize == size &&
                item.SelectedColor == color);
        }

        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng - Hybrid approach
        /// - Nếu đã login: Call API
        /// - Nếu chưa login (guest): Dùng local storage
        /// </summary>
        public async Task<AddToCartResponse> AddToCartAsync(Product product, int quantity = 1, string? size = null, string? color = null, int variantId = 0)
        {
            try
            {
                Console.WriteLine($"[Frontend CartService.AddToCartAsync] ProductID={product.Id}, Name={product.Name}, Size={size}, Color={color}, Qty={quantity}");
                bool isLoggedIn = _authService != null && _authService.IsAuthenticated;

                if (isLoggedIn)
                {
                    return await AddToCartViaApiAsync(product, quantity, size, color, variantId);
                }
                else
                {
                    AddItemLocally(product, quantity, size, color, variantId);
                    return new AddToCartResponse
                    {
                        Success = true,
                        Message = "Đã thêm sản phẩm vào giỏ hàng (local)",
                        CartSummary = new CartSummary
                        {
                            TotalItems = _items.Count,
                            TotalQuantity = GetTotalItems(),
                            TotalAmount = GetTotalPrice(),
                            Discount = 0,
                            FinalAmount = GetTotalPrice()
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CartService] Error in AddToCartAsync: {ex.Message}");
                AddItemLocally(product, quantity, size, color, variantId);
                return new AddToCartResponse
                {
                    Success = true,
                    Message = "Đã thêm sản phẩm vào giỏ hàng (local fallback)",
                    CartSummary = new CartSummary
                    {
                        TotalItems = _items.Count,
                        TotalQuantity = GetTotalItems(),
                        TotalAmount = GetTotalPrice(),
                        Discount = 0,
                        FinalAmount = GetTotalPrice()
                    }
                };
            }
        }

        /// <summary>
        /// Call API để thêm vào giỏ hàng (cho user đã login)
        /// </summary>
        private async Task<AddToCartResponse> AddToCartViaApiAsync(Product product, int quantity, string? size, string? color, int variantId = 0, bool updateLocal = true)
        {
            try
            {
                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var sessionId = GetOrCreateSessionId();

                var request = new AddToCartRequest
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    SelectedSize = size ?? "",
                    SelectedColor = color ?? "",
                    SessionId = sessionId,
                    UserId = _authService?.CurrentUser?.Id,
                    // Cache fields (không gửi lên API nhưng có thể dùng sau)
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl
                };
                
                Console.WriteLine($"[Frontend CartService] Sending to API: ProductID={request.ProductId}, Size={request.SelectedSize}, Color={request.SelectedColor}, Qty={request.Quantity}");

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Cart/AddToCart")
                {
                    Content = JsonContent.Create(request)
                };

                if (_authService != null && !string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    // Backend returns CommonResponse<CartSummaryRes>
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<CartSummaryResponse>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                    if (apiResponse != null && apiResponse.Success)
                    {
                        if (updateLocal)
                        {
                            // Mirror locally for UI consistency
                            AddItemLocally(product, quantity, size, color, variantId);
                        }
                        OnCartChanged?.Invoke();
                        return new AddToCartResponse
                        {
                            Success = true,
                            Message = apiResponse.Message ?? "Đã thêm sản phẩm vào giỏ hàng",
                            CartSummary = apiResponse.Data != null ? new CartSummary
                            {
                                TotalItems = apiResponse.Data.UniqueProductCount,
                                TotalQuantity = apiResponse.Data.TotalItems,
                                TotalAmount = apiResponse.Data.TotalAmount,
                                Discount = 0,
                                FinalAmount = apiResponse.Data.TotalAmount
                            } : null
                        };
                    };
                }
                AddItemLocally(product, quantity, size, color, variantId);
                return new AddToCartResponse
                {
                    Success = true,
                    Message = "Đã thêm sản phẩm vào giỏ hàng (API failed, using local)",
                    CartSummary = new CartSummary
                    {
                        TotalItems = _items.Count,
                        TotalQuantity = GetTotalItems(),
                        TotalAmount = GetTotalPrice(),
                        Discount = 0,
                        FinalAmount = GetTotalPrice()
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CartService] Exception in AddToCartViaApiAsync: {ex.Message}");
                AddItemLocally(product, quantity, size, color, variantId);
                return new AddToCartResponse
                {
                    Success = true,
                    Message = "Đã thêm sản phẩm vào giỏ hàng (API error, using local)",
                    CartSummary = new CartSummary
                    {
                        TotalItems = _items.Count,
                        TotalQuantity = GetTotalItems(),
                        TotalAmount = GetTotalPrice(),
                        Discount = 0,
                        FinalAmount = GetTotalPrice()
                    }
                };
            }
        }

        /// <summary>
        /// Thêm item vào local cart (logic cũ)
        /// </summary>
        private void AddItemLocally(Product product, int quantity, string? size, string? color, int variantId = 0)
        {
            AddItem(product, quantity, size, color, variantId);
        }

        /// <summary>
        /// Get hoặc tạo session ID cho guest user
        /// </summary>
        private string GetOrCreateSessionId()
        {
            try
            {
                // Attempt to get existing sessionId from localStorage
                var existing = _jsRuntime.InvokeAsync<string>("localStorage.getItem", "asion_sessionId").GetAwaiter().GetResult();
                if (!string.IsNullOrWhiteSpace(existing))
                {
                    return existing;
                }
            }
            catch { }

            var newId = Guid.NewGuid().ToString();
            try
            {
                _jsRuntime.InvokeVoidAsync("localStorage.setItem", "asion_sessionId", newId);
            }
            catch { }
            return newId;
        }

        /// <summary>
        /// Push all guest local items to API cart after login.
        /// </summary>
        private async Task MigrateGuestCartToUserAsync()
        {
            if (_authService == null || !_authService.IsAuthenticated) return;
            var itemsSnapshot = _items.ToList();
            foreach (var item in itemsSnapshot)
            {
                // Send to API without duplicating local list
                await AddToCartViaApiAsync(item.Product, item.Quantity, item.SelectedSize, item.SelectedColor, item.VariantID, false);
            }
        }

        /// <summary>
        /// Optionally refresh local cart from API (only summary amounts reflected; item details require API data mapping).
        /// </summary>
        private async Task RefreshApiCartToLocalAsync()
        {
            var apiCart = await GetCartFromApiAsync();
            if (apiCart == null) return;
            // Strategy: keep local list as-is (already mirrored). Could extend to reconcile quantities.
        }

        /// <summary>
        /// Lấy giỏ hàng từ API (cho user đã login)
        /// GET /api/Cart/GetCart - Returns CommonResponse<CartSummaryRes>
        /// </summary>
        public async Task<CartSummaryResponse?> GetCartFromApiAsync()
        {
            try
            {
                if (_authService == null || !_authService.IsAuthenticated)
                {
                    return null;
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{apiBaseUrl}/api/Cart/GetCart");

                if (!string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<CartSummaryResponse>>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    return apiResponse?.Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CartService] Error getting cart from API: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xóa item khỏi giỏ hàng qua API
        /// POST /api/Cart/RemoveCartItem?cartItemId={id}
        /// </summary>
        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            try
            {
                if (_authService == null || !_authService.IsAuthenticated)
                {
                    return false;
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(
                    HttpMethod.Post,
                    $"{apiBaseUrl}/api/Cart/RemoveCartItem?cartItemId={cartItemId}"
                );

                if (!string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    OnCartChanged?.Invoke();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CartService] Error removing cart item: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa toàn bộ giỏ hàng qua API
        /// POST /api/Cart/ClearCart
        /// </summary>
        public async Task<bool> ClearCartAsync()
        {
            try
            {
                if (_authService == null || !_authService.IsAuthenticated)
                {
                    ClearCart();
                    return true;
                }

                var apiBaseUrl = await _configService.GetApiBaseUrlAsync();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{apiBaseUrl}/api/Cart/ClearCart");

                if (!string.IsNullOrEmpty(_authService.CurrentToken))
                {
                    httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        _authService.CurrentToken
                    );
                }

                var response = await _httpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    OnCartChanged?.Invoke();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CartService] Error clearing cart: {ex.Message}");
                return false;
            }
        }
    }

    /// <summary>
    /// Thông tin checkout để truyền từ Checkout sang Payment
    /// </summary>
    public class CheckoutInfo
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string ShippingMethod { get; set; } = "standard";
        public decimal ShippingFee { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public List<Models.Cart.CartItemResponse>? SelectedApiItems { get; set; }
        public List<CartItem>? SelectedLocalItems { get; set; }
        public int? VoucherID { get; set; }
        public string? VoucherCode { get; set; }
        public decimal Discount { get; set; }
        
        // GHN Address Fields
        public int GhnProvinceId { get; set; }
        public int GhnDistrictId { get; set; }
        public string? GhnWardCode { get; set; }
        public string? GhnFullAddress { get; set; }
    }
}