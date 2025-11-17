using System.Text.Json;
using Microsoft.JSInterop;
using WebUI.Models;

namespace WebUI.Services
{
    public class RecentlyViewedService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string StorageKey = "recently_viewed_products";
        private const int MaxRecentItems = 10;

        public RecentlyViewedService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                var recentProducts = await GetRecentlyViewedAsync();
                
                // Remove if already exists to avoid duplicates
                recentProducts.RemoveAll(p => p.Id == product.Id);
                
                // Add to the beginning
                recentProducts.Insert(0, product);
                
                // Keep only the last MaxRecentItems
                if (recentProducts.Count > MaxRecentItems)
                {
                    recentProducts = recentProducts.Take(MaxRecentItems).ToList();
                }
                
                // Save to localStorage
                var json = JsonSerializer.Serialize(recentProducts);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product to recently viewed: {ex.Message}");
            }
        }

        public async Task<List<Product>> GetRecentlyViewedAsync()
        {
            try
            {
                var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
                
                if (string.IsNullOrEmpty(json))
                {
                    return new List<Product>();
                }
                
                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting recently viewed products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task ClearRecentlyViewedAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", StorageKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing recently viewed: {ex.Message}");
            }
        }

        public async Task<int> GetRecentlyViewedCountAsync()
        {
            var products = await GetRecentlyViewedAsync();
            return products.Count;
        }
    }
}
