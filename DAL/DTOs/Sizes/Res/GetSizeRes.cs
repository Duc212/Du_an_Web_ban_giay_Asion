namespace DAL.DTOs.Sizes.Res
{
    public class GetSizeRes
    {
        public int SizeID { get; set; }
        public string Value { get; set; } = string.Empty;
        public int ProductCount { get; set; } // Số lượng sản phẩm sử dụng size này
    }
}
