using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenderRepository
    {
        private readonly AppDbContext _context;
        public GenderRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Gender>> GetAllAsync()
        {
            return await _context.Genders.ToListAsync();
        }
        public async Task<Gender?> GetByIdAsync(int id)
        {
            return await _context.Genders.FindAsync(id);
        }
    }
}
