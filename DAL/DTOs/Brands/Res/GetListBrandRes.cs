namespace DAL.DTOs.Brands.Res
{
    public class GetALLBrandRes
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProductCount { get; set; }
    }
}
