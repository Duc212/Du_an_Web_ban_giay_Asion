namespace DAL.DTOs.Brands.Req
{
    public class AddBrandReq
    {
        public string BrandName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Logo { get; set; }
    }

    public class UpdateBrandReq
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Logo { get; set; }
    }

    public class RemoveBrandReq
    {
        public int BrandId { get; set; }
    }
}

namespace DAL.DTOs.Brands.Res
{
    public class GetListBrandRes
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProductCount { get; set; }
    }
}

namespace DAL.Entities
{
    public class CommonResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }

    public class CommonPagination<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int RecordPerPage { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
