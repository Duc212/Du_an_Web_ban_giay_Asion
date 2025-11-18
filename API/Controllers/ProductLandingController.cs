using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Brands.Req;
using DAL.DTOs.Brands.Res;
using DAL.DTOs.Categories.Req;
using DAL.DTOs.Categories.Res;
using DAL.DTOs.Products.Req;
using DAL.DTOs.Products.Res;
using DAL.Entities;
using DAL.Enums;
using Helper.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost("AddBrand")]
        public async Task<CommonResponse<bool>> Create([FromBody] AddBrandReq req)
        {
            return await _productService.CreateBrand(req);
        }

        [HttpPost("UpdateBrand")]
        public async Task<CommonResponse<bool>> Update([FromBody] UpdateBrandReq req)
        {
            return await _productService.UpdateBrand(req);
        }

        [HttpPost("RemoveBrand")]
        public async Task<CommonResponse<bool>> Remove([FromBody] RemoveBrandReq req)
        {
            return await _productService.RemoveBrand(req);
        }

        [HttpGet("GetBrandAll")]
        public async Task<CommonPagination<GetALLBrandRes>> GetAll(int currentPage = 1, int recordPerPage = 10)
        {
            return await _productService.GetBrandsPaged(currentPage, recordPerPage);

        }

        [HttpPost("AddCategory")]
        public async Task<CommonResponse<bool>> CreateCategory([FromBody] AddCategoryReq req)
        {
            return await _productService.CreateCategory(req);
        }

        [HttpPost("UpdateCategory")]
        public async Task<CommonResponse<bool>> UpdateCategory([FromBody] UpdateCategoryReq req)
        {
            return await _productService.UpdateCategory(req);
        }

        [HttpPost("RemoveCategory")]
        public async Task<CommonResponse<bool>> RemoveCategory([FromBody] RemoveCategoryReq req)
        {
            return await _productService.RemoveCategoryReq(req);
        }

        [HttpGet("GetAllCategory")]
        public async Task<CommonPagination<GetAllCategoryRes>> GetAllCategory(int currentPage = 1, int recordPerPage = 10)
        {
            return await _productService.GetAllCategory(currentPage, recordPerPage);
        }
        [HttpGet("GetGender")]
        public async Task<CommonResponse<GetGenderRes>> GetGender()
        {
            return await _productService.GetGender();
        }
    }
}
