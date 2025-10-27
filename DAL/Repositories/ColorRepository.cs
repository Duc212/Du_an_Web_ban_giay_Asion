using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = DAL.Models.Color;

namespace DAL.Repositories
{
    public class ColorRepository
    {
        private readonly AppDbContext _context;
        public ColorRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Color>> GetAllAsync()
        {
            return await _context.Colors.ToListAsync();
        }
        public async Task<Color?> GetByIdAsync(int id)
        {
            return await _context.Colors.FindAsync(id);
        }
        public async Task AddAsync(Color color)
        {
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Color color)
        {
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Color color)
        {
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
        }
    }
}
