namespace DAL.DTOs.Products.Req
{
    public class AddProductReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        public List<AddVariantDto> Variants { get; set; } = new List<AddVariantDto>();
        public List<AddProductImageDto> Images { get; set; } = new List<AddProductImageDto>();
    }

    public class AddVariantDto
    {
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
    }

    public class AddProductImageDto
    {
        public int ColorID { get; set; }
        public string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; } = "Main";
        public bool IsDefault { get; set; }
    }
}
