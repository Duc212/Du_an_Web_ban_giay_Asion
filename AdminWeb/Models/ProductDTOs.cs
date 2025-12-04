namespace AdminWeb.Models
{
    // ============ RESPONSE MODELS ============

    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int GenderId { get; set; }
        public string GenderName { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int VariantCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class GetAllProductsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ProductDTO> Data { get; set; } = new();
        public int TotalRecords { get; set; }
    }

    public class ProductDetailDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int GenderId { get; set; }
        public string GenderName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<VariantDTO> Variants { get; set; } = new();
        public List<ProductImageDTO> Images { get; set; } = new();
    }

    public class GetProductDetailResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ProductDetailDTO? Data { get; set; }
    }

    public class VariantDTO
    {
        public int VariantID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ColorHex { get; set; } = string.Empty;
        public int SizeID { get; set; }
        public string SizeValue { get; set; } = string.Empty;
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class GetVariantsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<VariantDTO> Data { get; set; } = new();
    }

    public class ProductImageDTO
    {
        public int ImageID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }

    // ============ REQUEST MODELS ============

    public class AddProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        public List<AddVariantRequest> Variants { get; set; } = new();
        public List<AddImageRequest> Images { get; set; } = new();
    }

    public class AddVariantRequest
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class AddImageRequest
    {
        public int ColorID { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
    }

    public class UpdateProductRequest
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
    }

    public class AddSingleVariantRequest
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
    }

    public class UpdateVariantRequest
    {
        public int VariantID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class UpdateStockRequest
    {
        public List<StockUpdateItem> Items { get; set; } = new();
    }

    public class StockUpdateItem
    {
        public int VariantID { get; set; }
        public int NewStock { get; set; }
    }

    // ============ DROPDOWN MODELS ============

    public class ColorDTO
    {
        public int ColorID { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("ColorName")]
        public string ColorName { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonPropertyName("HexColor")]
        public string HexColor { get; set; } = string.Empty;
    }

    public class CreateColorDTO
    {
        [System.Text.Json.Serialization.JsonPropertyName("Name")]
        public string ColorName { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonPropertyName("HexCode")]
        public string HexColor { get; set; } = string.Empty;
    }

    public class UpdateColorDTO
    {
        [System.Text.Json.Serialization.JsonPropertyName("Name")]
        public string ColorName { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonPropertyName("HexCode")]
        public string HexColor { get; set; } = string.Empty;
    }

    public class GetColorsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ColorDTO> Data { get; set; } = new();
    }

    public class SizeDTO
    {
        public int SizeID { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class CreateSizeDTO
    {
        public string Value { get; set; } = string.Empty;
    }

    public class UpdateSizeDTO
    {
        public string Value { get; set; } = string.Empty;
    }

    public class GetSizesResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<SizeDTO> Data { get; set; } = new();
    }

    public class GenderDTO
    {
        public int GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class GetGendersResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GenderDTO> Data { get; set; } = new();
    }

    // ============ STATISTICS MODELS ============

    public class ProductStatistics
    {
        public int TotalProducts { get; set; }
        public int ActiveProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public int LowStockProducts { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public List<CategoryStats> CategoryStats { get; set; } = new();
        public List<BrandStats> BrandStats { get; set; } = new();
    }

    public class CategoryStats
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
    }

    public class BrandStats
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
    }

    public class GetStatisticsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ProductStatistics? Data { get; set; }
    }

    // ============ GENERIC RESPONSE ============

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Data { get; set; }
    }

    // Adding missing DTOs to resolve compilation errors

    public class CategoryDto {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class BrandDto {
        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
    }

    public class ProductStatisticsDTO {
        public int TotalProducts { get; set; }
        public int ActiveProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public int LowStockProducts { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public List<CategoryStatistics> CategoryStats { get; set; } = new();
        public List<BrandStatistics> BrandStats { get; set; } = new();

        public class CategoryStatistics {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; } = string.Empty;
            public int ProductCount { get; set; }
            public int TotalStock { get; set; }
        }

        public class BrandStatistics {
            public int BrandID { get; set; }
            public string BrandName { get; set; } = string.Empty;
            public int ProductCount { get; set; }
            public int TotalStock { get; set; }
        }
    }

    public class UploadImageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class AddProductImageRequest
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public string ImageType { get; set; } = "Main";
        public bool IsDefault { get; set; }
    }
}
