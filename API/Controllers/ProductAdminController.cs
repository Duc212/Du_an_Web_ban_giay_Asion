using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Products.Req;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductAdminServices _productAdminServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductAdminController(IProductAdminServices productAdminServices, IHttpContextAccessor httpContextAccessor)
        {
            _productAdminServices = productAdminServices;
            _httpContextAccessor = httpContextAccessor;
        }

        #region CRUD Product

        /// <summary>
        /// L?y danh s�ch t?t c? s?n ph?m v?i ph�n trang v� filter
        /// </summary>
        [HttpGet("GetAllProducts")]
        [BAuthorize]
        public async Task<CommonPagination<GetProductAdminRes>> GetAllProducts(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? keyword = null,
            [FromQuery] int? categoryId = null,
            [FromQuery] int? brandId = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null)
        {
            return await _productAdminServices.GetAllProducts(pageIndex, pageSize, keyword, categoryId, brandId, sortBy, sortOrder);
        }

        /// <summary>
        /// L?y chi ti?t s?n ph?m bao g?m variants v� images
        /// </summary>
        [HttpGet("GetProductDetail/{productId}")]
        [BAuthorize]
        public async Task<CommonResponse<GetProductDetailAdminRes>> GetProductDetail(int productId)
        {
            return await _productAdminServices.GetProductDetail(productId);
        }

        /// <summary>
        /// Th�m s?n ph?m m?i v?i variants v� images
        /// </summary>
        [HttpPost("AddProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddProduct([FromBody] AddProductReq req)
        {
            return await _productAdminServices.AddProduct(req);
        }

        /// <summary>
        /// C?p nh?t th�ng tin s?n ph?m
        /// </summary>
        [HttpPut("UpdateProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateProduct([FromBody] UpdateProductReq req)
        {
            return await _productAdminServices.UpdateProduct(req);
        }

        /// <summary>
        /// X�a s?n ph?m
        /// </summary>
        [HttpDelete("DeleteProduct/{productId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteProduct(int productId)
        {
            return await _productAdminServices.DeleteProduct(productId);
        }

        #endregion

        #region Variant Management

        /// <summary>
        /// L?y t?t c? variants c?a m?t s?n ph?m
        /// </summary>
        [HttpGet("GetProductVariants/{productId}")]
        [BAuthorize]
        public async Task<CommonResponse<List<GetVariantRes>>> GetProductVariants(int productId)
        {
            return await _productAdminServices.GetProductVariants(productId);
        }

        /// <summary>
        /// Th�m variant m?i cho s?n ph?m
        /// </summary>
        [HttpPost("AddVariant")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddVariant([FromBody] AddVariantReq req)
        {
            return await _productAdminServices.AddVariant(req);
        }

        /// <summary>
        /// C?p nh?t variant (gi�, stock)
        /// </summary>
        [HttpPut("UpdateVariant")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateVariant([FromBody] UpdateVariantReq req)
        {
            return await _productAdminServices.UpdateVariant(req);
        }

        /// <summary>
        /// X�a variant
        /// </summary>
        [HttpDelete("DeleteVariant/{variantId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteVariant(int variantId)
        {
            return await _productAdminServices.DeleteVariant(variantId);
        }

        /// <summary>
        /// C?p nh?t s? l??ng t?n kho h�ng lo?t
        /// </summary>
        [HttpPut("UpdateStock")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateStock([FromBody] UpdateStockReq req)
        {
            return await _productAdminServices.UpdateStock(req);
        }

        #endregion

        #region Support APIs

        /// <summary>
        /// L?y danh s�ch m�u s?c (for dropdown)
        /// </summary>
        [HttpGet("GetColors")]
        public async Task<CommonResponse<List<GetColorRes>>> GetColors()
        {
            return await _productAdminServices.GetColors();
        }

        /// <summary>
        /// L?y danh s�ch size (for dropdown)
        /// </summary>
        [HttpGet("GetSizes")]
        public async Task<CommonResponse<List<GetSizeRes>>> GetSizes()
        {
            return await _productAdminServices.GetSizes();
        }

        /// <summary>
        /// L?y danh s�ch gi?i t�nh (for dropdown)
        /// </summary>
        [HttpGet("GetGenders")]
        public async Task<CommonResponse<List<GetGenderRes>>> GetGenders()
        {
            return await _productAdminServices.GetGenders();
        }

        /// <summary>
        /// L?y th?ng k� s?n ph?m
        /// </summary>
        [HttpGet("GetProductStatistics")]
        [BAuthorize]
        public async Task<CommonResponse<GetProductStatisticsRes>> GetProductStatistics()
        {
            return await _productAdminServices.GetProductStatistics();
        }

        /// <summary>
        /// L?y danh s�ch s?n ph?m s?p h?t h�ng
        /// </summary>
        [HttpGet("GetLowStockProducts")]
        [BAuthorize]
        public async Task<CommonPagination<GetProductAdminRes>> GetLowStockProducts(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] int threshold = 10)
        {
            return await _productAdminServices.GetLowStockProducts(pageIndex, pageSize, threshold);
        }

        /// <summary>
        /// Thêm ảnh mới cho sản phẩm
        /// </summary>
        [HttpPost("AddProductImage")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddProductImage([FromBody] AddProductImageReq req)
        {
            return await _productAdminServices.AddProductImage(req);
        }

        /// <summary>
        /// Upload ảnh sản phẩm
        /// </summary>
        [HttpPost("UploadImage")]
        [BAuthorize]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { success = false, message = "Không có file được chọn" });
                }

                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest(new { success = false, message = "Chỉ chấp nhận file ảnh (jpg, jpeg, png, gif, webp)" });
                }

                // Validate file size (max 5MB)
                if (file.Length > 5 * 1024 * 1024)
                {
                    return BadRequest(new { success = false, message = "Kích thước file không được vượt quá 5MB" });
                }

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                
                // Create upload directory if not exists
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Save file
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return full URL with protocol, host and port
                var request = _httpContextAccessor.HttpContext?.Request;
                var baseUrl = $"{request?.Scheme}://{request?.Host}";
                var fileUrl = $"{baseUrl}/uploads/products/{fileName}";
                return Ok(new { success = true, url = fileUrl, message = "Upload ảnh thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Lỗi khi upload: {ex.Message}" });
            }
        }

        #endregion
    }
}
