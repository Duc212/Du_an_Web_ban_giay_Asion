using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductVariantRepository
    {
        private readonly AppDbContext _context;

        public ProductVariantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductVariant>> GetAllAsync()
        {
            return await _context.ProductVariants
                .Include(v => v.Color)
                .Include(v => v.Size)
                .Include(v => v.Product)
                .ToListAsync();
        }

        public async Task<ProductVariant?> GetByIdAsync(int id)
        {
            return await _context.ProductVariants
                .Include(v => v.Color)
                .Include(v => v.Size)
                .Include(v => v.Product)
                .FirstOrDefaultAsync(v => v.VariantID == id);
        }

        public async Task AddAsync(ProductVariant variant)
        {
            await _context.ProductVariants.AddAsync(variant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductVariant variant)
        {
            _context.ProductVariants.Update(variant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductVariant variant)
        {
            _context.ProductVariants.Remove(variant);
            await _context.SaveChangesAsync();
        }
    }
}
