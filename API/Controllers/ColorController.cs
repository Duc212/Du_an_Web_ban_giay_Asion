using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Colors.Req;
using DAL.DTOs.Colors.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        /// <summary>
        /// Lấy danh sách màu sắc phân trang
        /// </summary>
        [HttpGet("GetColorsPaged")]
        public async Task<CommonPagination<GetColorRes>> GetColorsPaged(int pageIndex = 1, int pageSize = 10, string? keyword = null)
        {
            return await _colorService.GetColorsPaged(pageIndex, pageSize, keyword);
        }

        /// <summary>
        /// Lấy thông tin màu sắc theo ID
        /// </summary>
        [HttpGet("GetColorById/{colorId}")]
        public async Task<CommonResponse<GetColorRes>> GetColorById(int colorId)
        {
            return await _colorService.GetColorById(colorId);
        }

        /// <summary>
        /// Thêm màu sắc mới
        /// </summary>
        [HttpPost("AddColor")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddColor([FromBody] AddColorReq req)
        {
            return await _colorService.AddColor(req);
        }

        /// <summary>
        /// Cập nhật thông tin màu sắc
        /// </summary>
        [HttpPut("UpdateColor")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateColor([FromBody] UpdateColorReq req)
        {
            return await _colorService.UpdateColor(req);
        }

        /// <summary>
        /// Xóa màu sắc
        /// </summary>
        [HttpDelete("DeleteColor/{colorId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteColor(int colorId)
        {
            return await _colorService.DeleteColor(colorId);
        }
    }
}
