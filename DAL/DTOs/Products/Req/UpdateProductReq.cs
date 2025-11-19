namespace DAL.DTOs.Products.Req
{
    public class UpdateProductReq
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
    }
}
