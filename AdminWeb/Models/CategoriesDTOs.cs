namespace DAL.DTOs.Categories.Req
{
    public class AddCategoryReq
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Icon { get; set; } = string.Empty;
    }

    public class UpdateCategoryReq
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Icon { get; set; } = string.Empty;
    }

    public class RemoveCategoryReq
    {
        public int CategoryID { get; set; }
    }
}

namespace DAL.DTOs.Categories.Res
{
      public class GetAllCategoryRes
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
