using API.Extensions;
using BUS.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeServices _sizeServices;

        public SizeController(ISizeServices sizeServices)
        {
            _sizeServices = sizeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSizes()
        {
            var result = await _sizeServices.GetAllSizesAsync();
            if (result.Success)
            {
                return Ok(result);
        }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeById(int id)
        {
            var result = await _sizeServices.GetSizeByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSize([FromBody] Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _sizeServices.CreateSizeAsync(size);
            if (result.Success)
        {
                return CreatedAtAction(nameof(GetSizeById), new { id = result.Data?.SizeID }, result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(int id, [FromBody] Size size)
        {
            if (!ModelState.IsValid)
        {
                return BadRequest(ModelState);
        }

            var result = await _sizeServices.UpdateSizeAsync(id, size);
            if (result.Success)
        {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            var result = await _sizeServices.DeleteSizeAsync(id);
            if (result.Success)
        {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
