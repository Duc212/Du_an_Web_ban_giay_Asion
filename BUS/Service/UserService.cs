using DAL.Enums;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        public UserService(UserRepository userRepo)
        {
            this._userRepo = userRepo;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Sai định dạng ID.");


            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException("Không tìm thấy người dùng.");

            return user;
        }
        public async Task AddAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Không để trống Username và Password.");

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.");

            var allUsers = await _userRepo.GetAllAsync();

            if (allUsers.Any(u => u.Username == user.Username))
                throw new ArgumentException("Username đã tồn tại.");

            if (allUsers.Any(u => u.Email == user.Email))
                throw new ArgumentException("Email đã được sử dụng.");

            user.Status = (int)UserStatusEnums.Active;
            user.CreatedAt = DateTime.Now;
            await _userRepo.AddAsync(user);
        }
        public async Task UpdateAsync(User user)
        {
            if (user == null || user.UserID <= 0)
                throw new ArgumentException("Dữ liệu không hợp lệ.");

            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Không để trống Username và Password.");
            var existing = await _userRepo.GetByIdAsync(user.UserID);

            if (existing == null)
                throw new KeyNotFoundException("Không tìm thấy người dùng.");

            var allUsers = await _userRepo.GetAllAsync();

            if (allUsers.Any(u => u.Email == user.Email && u.UserID != user.UserID))
                throw new InvalidOperationException("Email đã tồn tại.");

            // Cập nhật dữ liệu
            existing.FullName = user.FullName;
            existing.Email = user.Email;
            existing.Phone = user.Phone;
            existing.DateOfBirth = user.DateOfBirth;
            existing.Status = user.Status;

            await _userRepo.UpdateAsync(existing);

        }
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Sai định dạng ID.");

            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("Không tìm thấy người dùng.");
            await _userRepo.DeleteAsync(user);

        }
        public async Task<User> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Tên đăng nhập hoặc mật khẩu không được để trống.");

            var users = await _userRepo.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
                throw new KeyNotFoundException("Tên đăng nhập hoặc mật khẩu không đúng.");

            return user; 
        }

    }
}