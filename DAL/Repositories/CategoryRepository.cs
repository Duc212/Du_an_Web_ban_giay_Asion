using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            return category;
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}