using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext _context)
        {
                        this._context = _context;
        }
        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = await  _context.Users.ToListAsync();
            return users;
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
