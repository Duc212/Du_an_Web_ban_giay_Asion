using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public  class AddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Address>> GetAllAsync()
        {
            List<Address> addresses = await _context.Addresses.ToListAsync();
            return addresses;
        }
        public async Task<Address?> GetByIdAsync(int id)
        {
            Address? address = await _context.Addresses.FindAsync(id);
            return address;
        }
        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Address address)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
