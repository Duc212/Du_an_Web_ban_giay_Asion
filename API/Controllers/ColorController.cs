using API.Extensions;
using BUS.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorServices _colorServices;

        public ColorController(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColors()
        {
            var result = await _colorServices.GetAllColorsAsync();
            if (result.Success)
            {
                return Ok(result);
        }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById(int id)
        {
            var result = await _colorServices.GetColorByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor([FromBody] Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _colorServices.CreateColorAsync(color);
            if (result.Success)
        {
                return CreatedAtAction(nameof(GetColorById), new { id = result.Data?.ColorID }, result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromBody] Color color)
        {
            if (!ModelState.IsValid)
        {
                return BadRequest(ModelState);
        }

            var result = await _colorServices.UpdateColorAsync(id, color);
            if (result.Success)
        {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var result = await _colorServices.DeleteColorAsync(id);
            if (result.Success)
        {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
