namespace DAL.DTOs.Categories.Res
{
    public class GetAllCategoryRes
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int TotalProduct { get; set; } // Số lượng sản phẩm thuộc danh mục
    }
}
