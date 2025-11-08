using BUS.Services.Interfaces;
using DAL.DTOs.Products.Res;
using DAL.Entities;
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
        public async Task<CommonPagination<GetProductRes>> GetListProduct(int categoryId = -1, int currentPage = 1, int recordPerPage = 12)
        {
            var result = await _productService.GetProductLanding(categoryId, currentPage, recordPerPage);
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
    }
}
