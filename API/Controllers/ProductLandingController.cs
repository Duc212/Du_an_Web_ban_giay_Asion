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
        public async Task<CommonPagination<GetProductRes>> GetListProduct(int currentPage = 1, int recordPerPage = 12)
        {
            var result = await _productService.GetProductLangding(currentPage, recordPerPage);
            return result;
        }
    }
}
