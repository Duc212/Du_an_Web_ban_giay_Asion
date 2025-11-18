using BUS.Services.Interfaces;
using DAL.DTOs.Users.Res;
using DAL.Entities;
using DAL.Models;
using DAL.RepositoryAsyns;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryAsync<User> _userRepository;

        public UserServices(IRepositoryAsync<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommonPagination<GetListUserRes>> GetUsersAsync(int pageIndex, int pageSize, string? keyword = null, int? status = null, string? email = null, string? phone = null)
        {
            var query = _userRepository.AsNoTrackingQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(u => u.Username.Contains(keyword) || u.Email.Contains(keyword));
            }
            if (status.HasValue)
            {
                query = query.Where(u => u.Status == status.Value);
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(u => u.Email.Contains(email));
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(u => u.Phone.Contains(phone));
            }

            var totalRecords = await query.CountAsync();

            var users = await query
                .Include(u => u.Addresses)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .OrderByDescending(u => u.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userList = users.Select(u => new GetListUserRes
            {
                Id = u.UserID,
                UserName = u.Username,
                Email = u.Email,
                PhoneNumber = u.Phone,
                RoleName = u.UserRoles.Select(r => r.Role != null ? r.Role.Name : null).FirstOrDefault() ?? string.Empty,
                Address = u.Addresses.Select(a => new GetAddressUserRes
                {
                    AddressDetail = a.AddressDetail,
                    City = a.City,
                    District = a.District,
                    Ward = a.Ward,
                    Street = a.Street
                }).ToList(),
                DateOfBirth = u.DateOfBirth,
                Picture = u.Picture,
                Status = u.Status,
                CreatedAt = u.CreatedAt
            }).ToList();

            return new CommonPagination<GetListUserRes>
            {
                Data = userList,
                Message = "Success",
                TotalRecords = totalRecords,
                Success = true
            };
        }

        public async Task<CommonResponse<bool>> ChangeUserStatusAsync(int userId, int newStatus)
        {
            var user = await _userRepository.AsQueryable().FirstOrDefaultAsync(u => u.UserID == userId);
            if (user == null)
            {
                return new CommonResponse<bool>
                {
                    Success = false,
                    Message = "User not found",
                    Data = false
                };
            }

            user.Status = newStatus;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return new CommonResponse<bool>
            {
                Success = true,
                Message = "User status updated successfully",
                Data = true
            };
        }
    }
}
