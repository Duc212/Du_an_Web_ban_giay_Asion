using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Role>> GetAllAsync()
        {
            List<Role> roles = await _context.Roles.ToListAsync();
            return roles;
        }
        public async Task<Role?> GetByIdAsync(int id)
        {
            Role? role = await _context.Roles.FindAsync(id);
            return role;
        }
        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
