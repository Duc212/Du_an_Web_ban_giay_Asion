using DAL.Enums;
using DAL.Models;
using Helper.Utils;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Data
            // Seed Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, Name = "Admin" },
                new Role { RoleID = 2, Name = "User" }
            );
            // Seed User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FullName = "Admin",
                    Username = "Admin123",
                    Password = CryptoHelperUtil.Encrypt("123"),
                    Email = "admin@gmail.com",
                    Phone = "0123456789",
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    UserID = 2,
                    FullName = "Staff01",
                    Username = "user1",
                    Password = CryptoHelperUtil.Encrypt("123"),
                    Email = "user1@gmail.com",
                    Phone = "0987654321",
                    Status = (int)UserStatusEnums.Active,
                    CreatedAt = DateTime.Now
                }
            );
            // Seed UserRole
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleID = 1, UserID = 1, RoleID = 1 }, // Admin
                new UserRole { UserRoleID = 2, UserID = 2, RoleID = 2 }  // Normal User
            );
            // Seed Address
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressID = 1, UserID = 1, AddressDetail = "123 Admin Street", City = "Hanoi", Ward = "Ward 1", Street = "Admin Street" },
                new Address { AddressID = 2, UserID = 2, AddressDetail = "456 User Street", City = "Hanoi", Ward = "Ward 2", Street = "User Street" }
            );
        }
    }
}
