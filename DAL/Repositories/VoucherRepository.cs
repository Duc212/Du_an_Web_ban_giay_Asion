using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class VoucherRepository
    {
        private readonly AppDbContext _context;

        public VoucherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCodeExistsAsync(string code, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Vouchers
                    .AnyAsync(v => v.VoucherCode == code && v.VoucherID != excludeId.Value);
            }
            return await _context.Vouchers.AnyAsync(v => v.VoucherCode == code);
        }

        public async Task<int> GetUsedCountAsync(int voucherId)
        {
            return await _context.Orders
                .CountAsync(o => o.VoucherID == voucherId);
        }
    }
}
