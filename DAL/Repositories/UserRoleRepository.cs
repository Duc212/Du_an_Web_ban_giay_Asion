using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRoleRepository
    {
        private readonly AppDbContext _context;
        public UserRoleRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public async Task<List<UserRole>> GetAllAsync()
        {
            List<UserRole> userRoles = await _context.UserRoles.ToListAsync();
            return userRoles;
        }
        public async Task<UserRole?> GetByIdAsync(int id)
        {
            UserRole? userRole = await _context.UserRoles.FindAsync(id);
            return userRole;
        }
        public async Task<UserRole?> GetByUserAndRoleAsync(int userId, int roleId)
        {
            return await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserID == userId && ur.RoleID == roleId);
        }
        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(UserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
