namespace DAL.DTOs.Carts.Res
{
    public class CartItemRes
    {
        public int CartItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ColorHex { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public string ImageUrl { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new(); 
        public int StockQuantity { get; set; }
        public int VariantID { get; set; }
        public string PriceFormatted => $"{Price:N0}đ";
        public string TotalPriceFormatted => $"{TotalPrice:N0}đ";
    }

    public class CartSummaryRes
    {
        public int CartID { get; set; }
        public List<CartItemRes> Items { get; set; } = new();
        public int TotalItems => Items.Sum(x => x.Quantity);
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);
        public string TotalAmountFormatted => $"{TotalAmount:N0}đ";
        public int UniqueProductCount => Items.Count;
    }
}