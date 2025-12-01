namespace DAL.DTOs.Colors.Res
{
    public class GetColorRes
    {
        public int ColorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;
        public int ProductCount { get; set; } // Số lượng sản phẩm sử dụng màu này
    }
}
