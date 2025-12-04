namespace DAL.DTOs.Products.Res
{
    public class GetColorRes
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string HexColor { get; set; }
        public int AvailableStock { get; set; } // Tổng số lượng còn của tất cả size với màu này
        public Dictionary<string, int> SizeStock { get; set; } = new(); // Stock theo từng size: {"39": 10, "40": 5, ...}
        public Dictionary<string, decimal> SizePrice { get; set; } = new(); // Price theo từng size: {"39": 500000, "40": 520000, ...}
    }
}
