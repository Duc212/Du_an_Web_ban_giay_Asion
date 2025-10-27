using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BrandRepository
    {
        private readonly AppDbContext _context;
        public BrandRepository(AppDbContext _context) 
        {
            this._context = _context;
        }
        public async Task<List<Brand>> GetAllAsync()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return brands;
        }
        public async Task<Brand?> GetByIdAsync(int id)
        {
            Brand? brand = await _context.Brands.FindAsync(id);
            return brand;
        }
        public async Task AddAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}
