using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SizeRepository
    {
        private readonly AppDbContext _context;
        public SizeRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Size>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }
        public async Task<Size?> GetByIdAsync(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }
        public async Task AddAsync(Size size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Size size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Size size)
        {
            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }
    }
}
