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

        public ProductAdminController(IProductAdminServices productAdminServices)
        {
            _productAdminServices = productAdminServices;
        }

        #region CRUD Product

        /// <summary>
        /// L?y danh sách t?t c? s?n ph?m v?i phân trang và filter
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
        /// L?y chi ti?t s?n ph?m bao g?m variants và images
        /// </summary>
        [HttpGet("GetProductDetail/{productId}")]
        [BAuthorize]
        public async Task<CommonResponse<GetProductDetailAdminRes>> GetProductDetail(int productId)
        {
            return await _productAdminServices.GetProductDetail(productId);
        }

        /// <summary>
        /// Thêm s?n ph?m m?i v?i variants và images
        /// </summary>
        [HttpPost("AddProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddProduct([FromBody] AddProductReq req)
        {
            return await _productAdminServices.AddProduct(req);
        }

        /// <summary>
        /// C?p nh?t thông tin s?n ph?m
        /// </summary>
        [HttpPut("UpdateProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateProduct([FromBody] UpdateProductReq req)
        {
            return await _productAdminServices.UpdateProduct(req);
        }

        /// <summary>
        /// Xóa s?n ph?m
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
        /// Thêm variant m?i cho s?n ph?m
        /// </summary>
        [HttpPost("AddVariant")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddVariant([FromBody] AddVariantReq req)
        {
            return await _productAdminServices.AddVariant(req);
        }

        /// <summary>
        /// C?p nh?t variant (giá, stock)
        /// </summary>
        [HttpPut("UpdateVariant")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateVariant([FromBody] UpdateVariantReq req)
        {
            return await _productAdminServices.UpdateVariant(req);
        }

        /// <summary>
        /// Xóa variant
        /// </summary>
        [HttpDelete("DeleteVariant/{variantId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteVariant(int variantId)
        {
            return await _productAdminServices.DeleteVariant(variantId);
        }

        /// <summary>
        /// C?p nh?t s? l??ng t?n kho hàng lo?t
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
        /// L?y danh sách màu s?c (for dropdown)
        /// </summary>
        [HttpGet("GetColors")]
        public async Task<CommonResponse<List<GetColorRes>>> GetColors()
        {
            return await _productAdminServices.GetColors();
        }

        /// <summary>
        /// L?y danh sách size (for dropdown)
        /// </summary>
        [HttpGet("GetSizes")]
        public async Task<CommonResponse<List<GetSizeRes>>> GetSizes()
        {
            return await _productAdminServices.GetSizes();
        }

        /// <summary>
        /// L?y danh sách gi?i tính (for dropdown)
        /// </summary>
        [HttpGet("GetGenders")]
        public async Task<CommonResponse<List<GetGenderRes>>> GetGenders()
        {
            return await _productAdminServices.GetGenders();
        }

        /// <summary>
        /// L?y th?ng kê s?n ph?m
        /// </summary>
        [HttpGet("GetProductStatistics")]
        [BAuthorize]
        public async Task<CommonResponse<GetProductStatisticsRes>> GetProductStatistics()
        {
            return await _productAdminServices.GetProductStatistics();
        }

        /// <summary>
        /// L?y danh sách s?n ph?m s?p h?t hàng
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

        #endregion
    }
}
