using WebUI.Models;

namespace WebUI.Services
{
    public class CartItem
    {
        public Product Product { get; set; } = new();
        public int Quantity { get; set; } = 1;
        public string? SelectedSize { get; set; }
        public string? SelectedColor { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }

    public class CartService
    {
        private readonly List<CartItem> _items = new();
        
        public event Action? OnCartChanged;

        public List<CartItem> GetItems() => _items.ToList();
        
        public int GetTotalItems() => _items.Sum(item => item.Quantity);
        
        public decimal GetTotalPrice() => _items.Sum(item => item.TotalPrice);

        public void AddItem(Product product, int quantity = 1, string? size = null, string? color = null)
        {
            var existingItem = _items.FirstOrDefault(item => 
                item.Product.Id == product.Id && 
                item.SelectedSize == size && 
                item.SelectedColor == color);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity,
                    SelectedSize = size,
                    SelectedColor = color
                });
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
    }
}