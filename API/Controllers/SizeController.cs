using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Sizes.Req;
using DAL.DTOs.Sizes.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        /// <summary>
        /// Lấy danh sách size phân trang
        /// </summary>
        [HttpGet("GetSizesPaged")]
        public async Task<CommonPagination<GetSizeRes>> GetSizesPaged(int pageIndex = 1, int pageSize = 10, string? keyword = null)
        {
            return await _sizeService.GetSizesPaged(pageIndex, pageSize, keyword);
        }

        /// <summary>
        /// Lấy thông tin size theo ID
        /// </summary>
        [HttpGet("GetSizeById/{sizeId}")]
        public async Task<CommonResponse<GetSizeRes>> GetSizeById(int sizeId)
        {
            return await _sizeService.GetSizeById(sizeId);
        }

        /// <summary>
        /// Thêm size mới
        /// </summary>
        [HttpPost("AddSize")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> AddSize([FromBody] AddSizeReq req)
        {
            return await _sizeService.AddSize(req);
        }

        /// <summary>
        /// Cập nhật thông tin size
        /// </summary>
        [HttpPut("UpdateSize")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> UpdateSize([FromBody] UpdateSizeReq req)
        {
            return await _sizeService.UpdateSize(req);
        }

        /// <summary>
        /// Xóa size
        /// </summary>
        [HttpDelete("DeleteSize/{sizeId}")]
        [BAuthorize]
        public async Task<CommonResponse<bool>> DeleteSize(int sizeId)
        {
            return await _sizeService.DeleteSize(sizeId);
        }
    }
}
