using API.Extensions;
using BUS.Services;
using DAL.DTOs.Vouchers.Req;
using DAL.DTOs.Vouchers.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        /// <summary>
        /// Lấy danh sách tất cả voucher
        /// </summary>
        [HttpGet("GetAllVouchers")]
        [BAuthorize]
        public async Task<CommonResponse<List<GetVoucherRes>>> GetAllVouchers()
        {
            return await _voucherService.GetAllVouchers();
        }

        /// <summary>
        /// Lấy thông tin chi tiết voucher theo ID
        /// </summary>
        [HttpGet("GetVoucherById/{id}")]
        [BAuthorize]
        public async Task<CommonResponse<GetVoucherRes>> GetVoucherById(int id)
        {
            return await _voucherService.GetVoucherById(id);
        }

        /// <summary>
        /// Tạo voucher mới
        /// </summary>
        [HttpPost("CreateVoucher")]
        [BAuthorize]
        public async Task<CommonResponse<string>> CreateVoucher([FromBody] CreateVoucherReq request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = string.Join(", ", errors),
                    Data = null
                };
            }

            return await _voucherService.CreateVoucher(request);
        }

        /// <summary>
        /// Cập nhật thông tin voucher
        /// </summary>
        [HttpPut("UpdateVoucher")]
        [BAuthorize]
        public async Task<CommonResponse<string>> UpdateVoucher([FromBody] UpdateVoucherReq request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return new CommonResponse<string>
                {
                    Success = false,
                    Message = string.Join(", ", errors),
                    Data = null
                };
            }

            return await _voucherService.UpdateVoucher(request);
        }

        /// <summary>
        /// Xóa voucher theo ID
        /// </summary>
        [HttpDelete("DeleteVoucher/{id}")]
        [BAuthorize]
        public async Task<CommonResponse<string>> DeleteVoucher(int id)
        {
            return await _voucherService.DeleteVoucher(id);
        }

        /// <summary>
        /// Xác thực và tính toán giảm giá của voucher (Public - không cần đăng nhập)
        /// </summary>
        [HttpPost("ValidateVoucher")]
        public async Task<CommonResponse<ValidateVoucherRes>> ValidateVoucher([FromBody] ValidateVoucherReq request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return new CommonResponse<ValidateVoucherRes>
                {
                    Success = false,
                    Message = string.Join(", ", errors),
                    Data = new ValidateVoucherRes { IsValid = false, Message = "Dữ liệu không hợp lệ" }
                };
            }

            return await _voucherService.ValidateVoucher(request);
        }
    }
}
