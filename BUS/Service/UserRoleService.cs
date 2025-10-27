using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class UserRoleService
    {
        private readonly UserRoleRepository _userRoleRepo;
        private readonly RoleRepository _roleRepo;
        public UserRoleService(UserRoleRepository userRoleRepo, RoleRepository roleRepo)
        {
            _userRoleRepo = userRoleRepo;
            _roleRepo = roleRepo;
        }
        public async Task AssignRoleAsync(int userID, int roleID)
        {
            var role = await _roleRepo.GetByIdAsync(roleID);

            if (role.Name == "Admin")
                throw new InvalidOperationException("Không thể gán quyền Admin.");
            var existing = await _userRoleRepo.GetByUserAndRoleAsync(userID, roleID);
            if (existing != null)
                throw new InvalidOperationException("Người dùng đã có quyền này.");
            await _userRoleRepo.AddAsync(new UserRole { UserID = userID, RoleID = roleID });
        }
        public async Task RemoveRoleAsync(int userId, int roleId)
        {
            var existing = await _userRoleRepo.GetByUserAndRoleAsync(userId, roleId);
            if (existing == null)
                throw new KeyNotFoundException("User không có role này.");
            await _userRoleRepo.DeleteAsync(existing);

        }
    }
}
