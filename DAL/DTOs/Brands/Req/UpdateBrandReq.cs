namespace DAL.DTOs.Brands.Req
{
    public class UpdateBrandReq
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
