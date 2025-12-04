using BUS.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BUS.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly AppDbContext _context;

        public RevenueService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RecordRevenueAsync(int orderId, decimal amount)
        {
            try
            {
                // Kiểm tra xem đã record chưa (tránh duplicate)
                var existingRevenue = await _context.Revenues
                    .FirstOrDefaultAsync(r => r.OrderID == orderId);

                if (existingRevenue != null)
                {
                    // Đã có revenue record rồi, skip
                    return true;
                }

                // Tạo revenue record mới
                var revenue = new Revenue
                {
                    OrderID = orderId,
                    Amount = amount,
                    RecordedDate = DateTime.Now,
                    Note = "Auto-recorded from GHN delivery success"
                };

                _context.Revenues.Add(revenue);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
