namespace DAL.DTOs.Products.Req
{
    public class AddProductImageReq
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; } = "Main";
        public bool IsDefault { get; set; }
    }
}
