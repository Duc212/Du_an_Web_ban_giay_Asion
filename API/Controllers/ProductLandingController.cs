using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Products.Req;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Enums;
using Helper.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLandingController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductLandingController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetListProduct")]
        public async Task<CommonPagination<GetProductRes>> GetListProduct(ProductLandingFilterType? filterType = null, int categoryId = -1, int currentPage = 1, int recordPerPage = 12)
        {
            var result = await _productService.GetProductLanding(categoryId, currentPage, recordPerPage, filterType);
            return result;
        }
        [HttpGet]
        [Route("GetCategory")]
        public async Task<CommonResponse<List<GetListCategoryRes>>> GetListCategory()
        {
            var result = await _productService.GetListCategory();
            return result;
        }
        [HttpGet]
        [HttpGet("GetProductShop")]
        public async Task<CommonPagination<GetProductRes>> GetProductLangding(int? CategoryId, string? Keyword, int? SortType, int? SortPrice, int CurrentPage, int RecordPerPage)
        {
            var result = await _productService.GetProductShop(CategoryId, Keyword, SortType, SortPrice, CurrentPage, RecordPerPage);
            return result;
        }
        [HttpGet]
        [Route("GetLisBrand")]
        public async Task<CommonResponse<List<GetListBrandRes>>> GetListBrand()
        {
            return await _productService.GetListBrand();
        }

        [HttpPost("AddFavoriteProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddFavoriteProduct([FromBody] AddFavoriteProductReq req)
        {
            var userId = HttpContextHelper.GetUserId();
            var result = await _productService.AddFavoriteProduct(userId, req.ProductId);
            return result;
        }

        [HttpPost("RemoveFavoriteProduct")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> RemoveFavoriteProduct([FromBody] RemoveFavoriteProductReq req)
        {
            var userId = HttpContextHelper.GetUserId();
            var result = await _productService.RemoveFavoriteProduct(userId, req.ProductId);
            return result;
        }

        [HttpGet("GetFavoriteProducts")]
        [BAuthorize]
        public async Task<CommonResponse<List<GetProductRes>>> GetFavoriteProducts()
        {
            var userId = HttpContextHelper.GetUserId();
            var result = await _productService.GetFavoriteProducts(userId);
            return result;
        }

        [HttpGet("GetProductById")]
        public async Task<CommonResponse<GetProductRes>> GetProductById(int productId)
        {
            var result = await _productService.GetProductById(productId);
            return result;
        }
    }
}
