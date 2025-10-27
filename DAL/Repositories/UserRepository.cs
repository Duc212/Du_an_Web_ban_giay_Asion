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
            try
            {
                List<User> users = await _context.Users.ToListAsync();
                return users;

            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi khi lấy danh sách danh mục.", ex);
            }
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                User? user = await _context.Users.FindAsync(id);
                return user;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi khi tìm danh mục theo ID.", ex);
            }

        }
        public async Task AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {

                throw new Exception("Lỗi khi thêm danh mục vào cơ sở dữ liệu.", ex);
            }
        }
        public async Task UpdateAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new Exception("Cập nhật thất bại. Có thể danh mục đã bị thay đổi hoặc xóa.", ex);
            }
        }
        public async Task DeleteAsync(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {

                throw new Exception("Lỗi khi xóa danh mục khỏi cơ sở dữ liệu.", ex);
            }
        }
    }
}
