using BUS.Services;
using BUS.Services.Interfaces;
using DAL.DTOs.Users.Res;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetListUser")]
        public async Task<CommonPagination<GetListUserRes>> GetUsers(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? keyword = null,
            [FromQuery] int? status = null,
            [FromQuery] string? email = null,
            [FromQuery] string? phone = null)
        {
            var users = await _userService.GetUsersAsync(pageIndex, pageSize, keyword, status, email, phone);
            return users;
        }

        [HttpPut("change-status")]
        public async Task<CommonResponse<bool>> ChangeStatus([FromQuery] int userId, [FromQuery] int newStatus)
        {
           return await _userService.ChangeUserStatusAsync(userId, newStatus);
        }
    }
}
