namespace DAL.DTOs.Categories.Req
{
    public class UpdateCategoryReq
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Icon { get; set; }
    }
}
