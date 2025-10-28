using DAL.Models;
using BUS.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly BUS.Service.ProductVariantService _variantService;

        public ProductVariantsController(BUS.Service.ProductVariantService variantService)
        {
            _variantService = variantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var variants = await _variantService.GetAllAsync();
            return Ok(variants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var variant = await _variantService.GetByIdAsync(id);
                return Ok(variant);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DAL.Models.ProductVariantService variant)
        {
            try
            {
                await _variantService.AddAsync(variant);
                return CreatedAtAction(nameof(GetById), new { id = variant.VariantID }, variant);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DAL.Models.ProductVariantService updateVariant)
        {
            if (id != updateVariant.VariantID)
                return BadRequest(new { message = "ID không trùng khớp." });

            try
            {
                await _variantService.UpdateAsync(updateVariant);
                return Ok(new { message = "Cập nhật biến thể sản phẩm thành công!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
