namespace DAL.DTOs.Products.Res
{
    public class GetProductDetailAdminRes
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<GetVariantRes> Variants { get; set; } = new List<GetVariantRes>();
        public List<GetProductImageRes> Images { get; set; } = new List<GetProductImageRes>();
    }

    public class GetVariantRes
    {
        public int VariantID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public int SizeID { get; set; }
        public string SizeValue { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
    }

    public class GetProductImageRes
    {
        public int ImageID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
