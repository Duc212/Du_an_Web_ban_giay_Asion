using DAL.Enums;
using DAL.Models;
using DAL.Entities;
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
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Revenue> Revenues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Data
            // Seed Role
            modelBuilder.Entity<Role>().HasData(
                      new Role { RoleID = 1, Name = "Admin" },
             new Role { RoleID = 2, Name = "User" },
             new Role { RoleID = 3, Name = "Employee" }
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

            // Seed Gender
            modelBuilder.Entity<Gender>().HasData(
                   new Gender { GenderID = 1, Name = "Nam" },
                   new Gender { GenderID = 2, Name = "Nữ" },
         new Gender { GenderID = 3, Name = "Unisex" }
                    );

            // Seed Brand
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 1, Name = "Nike", Description = "Just Do It - Thương hiệu thể thao hàng đầu thế giới" },
         new Brand { BrandID = 2, Name = "Adidas", Description = "Impossible is Nothing - Thương hiệu thể thao Đức" },
               new Brand { BrandID = 3, Name = "Converse", Description = "Thương hiệu giày thể thao cổ điển Mỹ" },
           new Brand { BrandID = 4, Name = "New Balance", Description = "Thương hiệu giày chạy bộ chất lượng cao" },
                        new Brand { BrandID = 5, Name = "Vans", Description = "Thương hiệu giày skateboard và streetwear" },
        new Brand { BrandID = 6, Name = "Asics", Description = "Thương hiệu giày thể thao Nhật Bản" },
                new Brand { BrandID = 7, Name = "Puma", Description = "Thương hiệu thể thao Đức với logo báo" },
                    new Brand { BrandID = 8, Name = "Jordan", Description = "Thương hiệu giày bóng rổ cao cấp của Nike" },
                  new Brand { BrandID = 9, Name = "Reebok", Description = "Thương hiệu thể thao và fitness" }
                );

            // Seed Category
            modelBuilder.Entity<Category>().HasData(
                  new Category { CategoryID = 1, Name = "Chạy bộ", Description = "Giày dành cho chạy bộ và tập luyện cardio",Icon = "fas fa-running" },
                   new Category { CategoryID = 2, Name = "Giày Bóng Rổ", Description = "Giày thể thao thời trang hàng ngày", Icon = "fas fa-basketball-ball" },
                    new Category { CategoryID = 3, Name = "Giày Lifestyle", Description = "Giày chuyên dụng cho bóng rổ", Icon = "fas fa-shoe-prints" },
                new Category { CategoryID = 4, Name = "Giày Bóng Đá", Description = "Giày chuyên dụng cho tennis", Icon = "fas fa-futbol" },
               new Category { CategoryID = 5, Name = "Giày Gym", Description = "Giày dành cho skateboarding", Icon = "fas fa-dumbbell" },
               new Category { CategoryID = 6, Name = "Giày Trẻ Em", Description = "Giày dành cho skateboarding", Icon = "fas fa-fas fa-child" }
               );

            // Seed Color
            modelBuilder.Entity<Color>().HasData(
         new Color { ColorID = 1, Name = "Đen", HexCode = "#000000" },
         new Color { ColorID = 2, Name = "Trắng", HexCode = "#FFFFFF" },
         new Color { ColorID = 3, Name = "Đỏ", HexCode = "#FF0000" },
         new Color { ColorID = 4, Name = "Xanh dương", HexCode = "#007BFF" },
         new Color { ColorID = 5, Name = "Xanh lá", HexCode = "#28A745" },
         new Color { ColorID = 6, Name = "Xám", HexCode = "#6C757D" },
         new Color { ColorID = 7, Name = "Vàng", HexCode = "#FFC107" },
         new Color { ColorID = 8, Name = "Hồng", HexCode = "#E83E8C" },
         new Color { ColorID = 9, Name = "Cam", HexCode = "#FD7E14" },
         new Color { ColorID = 10, Name = "Tím", HexCode = "#6F42C1" },
         new Color { ColorID = 11, Name = "Nâu", HexCode = "#8B4513" },
         new Color { ColorID = 12, Name = "Bạc", HexCode = "#C0C0C0" }
     );

            // Seed Size
            modelBuilder.Entity<Size>().HasData(
                new Size { SizeID = 1, Value = "36" },
            new Size { SizeID = 2, Value = "37" },
                new Size { SizeID = 3, Value = "38" },
              new Size { SizeID = 4, Value = "39" },
                new Size { SizeID = 5, Value = "40" },
                          new Size { SizeID = 6, Value = "41" },
               new Size { SizeID = 7, Value = "42" },
             new Size { SizeID = 8, Value = "43" },
                   new Size { SizeID = 9, Value = "44" },
                new Size { SizeID = 10, Value = "45" }
                 );

            // Seed Payment methods
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentID = 1, PaymentMethod = "COD", PaymentStatus = "Active", PaymentDate = DateTime.UtcNow },
                new Payment { PaymentID = 2, PaymentMethod = "VNPAY", PaymentStatus = "Active", PaymentDate = DateTime.UtcNow },
                new Payment { PaymentID = 3, PaymentMethod = "GPAY", PaymentStatus = "Active", PaymentDate = DateTime.UtcNow },
                new Payment { PaymentID = 4, PaymentMethod = "PAYPAL", PaymentStatus = "Active", PaymentDate = DateTime.UtcNow }
            );

            // Seed Products với ảnh thật
            modelBuilder.Entity<Product>().HasData(
               // Nike Products
               new Product
               {
                   ProductID = 1,
                   Name = "Nike Air Max 270",
                   Description = "Giày thể thao Nike Air Max 270 với công nghệ đệm khí Max Air lớn nhất từ trước đến nay. Thiết kế hiện đại, phù hợp cho cả tập luyện và phong cách hàng ngày.",
                   ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop",
                   CreatedAt = DateTime.Now.AddDays(-30),
                   BrandId = 1,
                   CategoryId = 1,
                   GenderId = 3
               },
                      new Product
                      {
                          ProductID = 2,
                          Name = "Nike Air Force 1 '07",
                          Description = "Giày thể thao Nike Air Force 1 '07 - biểu tượng thời trang streetwear với thiết kế vượt thời gian và chất lượng bền bỉ.",
                          ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop",
                          CreatedAt = DateTime.Now.AddDays(-25),
                          BrandId = 1,
                          CategoryId = 2,
                          GenderId = 3
                      },
                 new Product
                 {
                     ProductID = 3,
                     Name = "Nike React Infinity Run",
                     Description = "Giày chạy bộ Nike React Infinity Run được thiết kế để giảm chấn thương. Công nghệ React foam mang lại độ đàn hồi tuyệt vời.",
                     ImageUrl = "https://images.unsplash.com/photo-1607522370275-f14206abe5d3?w=500&h=500&fit=crop",
                     CreatedAt = DateTime.Now.AddDays(-20),
                     BrandId = 1,
                     CategoryId = 1,
                     GenderId = 3
                 },

                // Adidas Products
                new Product
                {
                    ProductID = 4,
                    Name = "Adidas Ultraboost 22",
                    Description = "Giày chạy bộ Adidas Ultraboost 22 với công nghệ Boost mang lại năng lượng trở lại mỗi bước chạy. Thiết kế Primeknit+ ôm chân tự nhiên.",
                    ImageUrl = "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop",
                    CreatedAt = DateTime.Now.AddDays(-18),
                    BrandId = 2,
                    CategoryId = 1,
                    GenderId = 3
                },
             new Product
             {
                 ProductID = 5,
                 Name = "Adidas Stan Smith",
                 Description = "Giày tennis Adidas Stan Smith - thiết kế tối giản, thanh lịch với màu trắng cổ điển. Phù hợp cho mọi phong cách thời trang.",
                 ImageUrl = "https://images.unsplash.com/photo-1586525198428-225f6f12cff5?w=500&h=500&fit=crop",
                 CreatedAt = DateTime.Now.AddDays(-15),
                 BrandId = 2,
                 CategoryId = 4,
                 GenderId = 3
             },
              new Product
              {
                  ProductID = 6,
                  Name = "Adidas NMD R1",
                  Description = "Giày thể thao Adidas NMD R1 với thiết kế futuristic. Kết hợp công nghệ Boost với phong cách streetwear hiện đại.",
                  ImageUrl = "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop",
                  CreatedAt = DateTime.Now.AddDays(-12),
                  BrandId = 2,
                  CategoryId = 2,
                  GenderId = 3
              },

                     // Converse Products
                     new Product
                     {
                         ProductID = 7,
                         Name = "Converse Chuck Taylor All Star",
                         Description = "Giày thể thao classic Converse Chuck Taylor All Star. Thiết kế vượt thời gian, phù hợp với mọi phong cách và độ tuổi.",
                         ImageUrl = "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop",
                         CreatedAt = DateTime.Now.AddDays(-10),
                         BrandId = 3,
                         CategoryId = 2,
                         GenderId = 3
                     },
                  new Product
                  {
                      ProductID = 8,
                      Name = "Converse Run Star Hike",
                      Description = "Giày Converse Run Star Hike với đế platform độc đáo. Kết hợp phong cách Chuck Taylor cổ điển với xu hướng chunky hiện đại.",
                      ImageUrl = "https://images.unsplash.com/photo-1603808033192-082d6919d3e1?w=500&h=500&fit=crop",
                      CreatedAt = DateTime.Now.AddDays(-8),
                      BrandId = 3,
                      CategoryId = 2,
                      GenderId = 2
                  },

                  // New Balance Products
                  new Product
                  {
                      ProductID = 9,
                      Name = "New Balance Fresh Foam X 1080v12",
                      Description = "Giày chạy bộ New Balance 1080v12 với công nghệ Fresh Foam X mang lại cảm giác êm ái và đàn hồi tuyệt vời cho những chuyến chạy dài.",
                      ImageUrl = "https://images.unsplash.com/photo-1539185441755-769473a23570?w=500&h=500&fit=crop",
                      CreatedAt = DateTime.Now.AddDays(-6),
                      BrandId = 4,
                      CategoryId = 1,
                      GenderId = 3
                  },
                     new Product
                     {
                         ProductID = 10,
                         Name = "New Balance 327",
                         Description = "Giày New Balance 327 lấy cảm hứng từ thiết kế vintage 70s với twist hiện đại. Phong cách retro-modern độc đáo.",
                         ImageUrl = "https://images.unsplash.com/photo-1605348532760-6753d2c43329?w=500&h=500&fit=crop",
                         CreatedAt = DateTime.Now.AddDays(-4),
                         BrandId = 4,
                         CategoryId = 2,
                         GenderId = 3
                     },

                    // Vans Products
                    new Product
                    {
                        ProductID = 11,
                        Name = "Vans Old Skool",
                        Description = "Giày Vans Old Skool với thiết kế side stripe đặc trưng. Phù hợp cho skateboarding và phong cách casual hàng ngày.",
                        ImageUrl = "https://images.unsplash.com/photo-1525966222134-fcfa99b8ae77?w=500&h=500&fit=crop",
                        CreatedAt = DateTime.Now.AddDays(-3),
                        BrandId = 5,
                        CategoryId = 5,
                        GenderId = 3
                    },
                   new Product
                   {
                       ProductID = 12,
                       Name = "Vans Sk8-Hi",
                       Description = "Giày Vans Sk8-Hi cổ cao với thiết kế ankle support. Phù hợp cho skateboarding và phong cách streetwear năng động.",
                       ImageUrl = "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop",
                       CreatedAt = DateTime.Now.AddDays(-2),
                       BrandId = 5,
                       CategoryId = 5,
                       GenderId = 3
                   },

              // Asics Products
              new Product
              {
                  ProductID = 13,
                  Name = "Asics Gel-Kayano 29",
                  Description = "Giày chạy bộ Asics Gel-Kayano 29 dành cho những vận động viên cần độ ổn định cao. Công nghệ FlyteFoam và Gel giảm chấn tối ưu.",
                  ImageUrl = "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop",
                  CreatedAt = DateTime.Now.AddDays(-1),
                  BrandId = 6,
                  CategoryId = 1,
                  GenderId = 3
              },
                new Product
                {
                    ProductID = 14,
                    Name = "Asics Gel-Nimbus 25",
                    Description = "Giày chạy bộ Asics Gel-Nimbus 25 với công nghệ đệm tiên tiến nhất. Mang lại trải nghiệm chạy êm ái và thoải mái tối đa.",
                    ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop",
                    CreatedAt = DateTime.Now,
                    BrandId = 6,
                    CategoryId = 1,
                    GenderId = 3
                },

                            // Puma Products
                            new Product
                            {
                                ProductID = 15,
                                Name = "Puma RS-X Reinvention",
                                Description = "Giày thể thao Puma RS-X với thiết kế chunky sneaker xu hướng. Kết hợp phong cách retro và công nghệ hiện đại.",
                                ImageUrl = "https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?w=500&h=500&fit=crop",
                                CreatedAt = DateTime.Now.AddHours(-12),
                                BrandId = 7,
                                CategoryId = 2,
                                GenderId = 3
                            },
                      new Product
                      {
                          ProductID = 16,
                          Name = "Puma Suede Classic",
                          Description = "Giày Puma Suede Classic - biểu tượng thời trang từ những năm 1960s. Chất liệu da lộn cao cấp với thiết kế vượt thời gian.",
                          ImageUrl = "https://images.unsplash.com/photo-1552346154-21d32810aba3?w=500&h=500&fit=crop",
                          CreatedAt = DateTime.Now.AddHours(-6),
                          BrandId = 7,
                          CategoryId = 2,
                          GenderId = 3
                      },

                    // Jordan Products - High-end
                    new Product
                    {
                        ProductID = 17,
                        Name = "Jordan Air 1 Mid",
                        Description = "Giày bóng rổ Jordan Air 1 Mid - huyền thoại basketball với thiết kế iconic. Chất lượng premium cho cả sân bóng và đường phố.",
                        ImageUrl = "https://images.unsplash.com/photo-1556906781-9a412961c28c?w=500&h=500&fit=crop",
                        CreatedAt = DateTime.Now.AddHours(-3),
                        BrandId = 8,
                        CategoryId = 3,
                        GenderId = 3
                    },
                     new Product
                     {
                         ProductID = 18,
                         Name = "Jordan Air 4 Retro",
                         Description = "Giày bóng rổ Jordan Air 4 Retro - một trong những mẫu Jordan iconic nhất mọi thời đại với thiết kế wing và mesh panels đặc trưng.",
                         ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop",
                         CreatedAt = DateTime.Now.AddHours(-1),
                         BrandId = 8,
                         CategoryId = 3,
                         GenderId = 3
                     },

                   // Reebok Products
                   new Product
                   {
                       ProductID = 19,
                       Name = "Reebok Club C 85",
                       Description = "Giày tennis cổ điển Reebok Club C 85 với thiết kế tối giản, thanh lịch. Phù hợp cho nhiều hoạt động thể thao và thời trang.",
                       ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop",
                       CreatedAt = DateTime.Now.AddMinutes(-30),
                       BrandId = 9,
                       CategoryId = 4,
                       GenderId = 3
                   },

                 // Special Nike Dunk - Popular model
                 new Product
                 {
                     ProductID = 20,
                     Name = "Nike Dunk Low Retro",
                     Description = "Giày Nike Dunk Low Retro với colorway Panda cổ điển. Thiết kế basketball vintage trở thành biểu tượng streetwear.",
                     ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop",
                     CreatedAt = DateTime.Now.AddMinutes(-15),
                     BrandId = 1,
                     CategoryId = 2,
                     GenderId = 3
                 }
               );

            // Seed ProductVariants với giá thật
            var productVariants = new List<ProductVariant>();
            var variantId = 1;

            // Tạo variants cho từng sản phẩm với nhiều size và màu
            for (int productId = 1; productId <= 20; productId++)
            {
                var basePrice = GetBasePrice(productId);
                var availableSizes = GetAvailableSizes(productId);
                var availableColors = GetAvailableColors(productId);

                foreach (var sizeId in availableSizes)
                {
                    foreach (var colorId in availableColors)
                    {
                        var variant = new ProductVariant
                        {
                            VariantID = variantId++,
                            ProductID = productId,
                            SizeID = sizeId,
                            ColorID = colorId,
                            ImportPrice = basePrice * 0.7m, // Giá nhập = 70% giá bán
                            SellingPrice = basePrice,
                            StockQuantity = Random.Shared.Next(10, 100),
                            Status = "Active"
                        };
                        productVariants.Add(variant);
                    }
                }
            }

            modelBuilder.Entity<ProductVariant>().HasData(productVariants.ToArray());

            // Seed ProductImages với ảnh chất lượng cao cho từng màu sắc
            var productImages = CreateProductImages();
            modelBuilder.Entity<ProductImage>().HasData(productImages.ToArray());
        }

        private static List<ProductImage> CreateProductImages()
        {
            var images = new List<ProductImage>();
            var imageId = 1;

            // Nike Air Max 270 (Product 1) - Black, White, Red
            images.AddRange(new[]
            {
       // Black colorway
       new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
              new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", DisplayOrder = 3, ImageType = "Detail", IsDefault = false, IsActive = true },
              
    // White colorway
     new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
    new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop", DisplayOrder = 3, ImageType = "Detail", IsDefault = false, IsActive = true },
        
         // Red colorway
   new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 3, ImageUrl = "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
     new ProductImage { ImageID = imageId++, ProductID = 1, ColorID = 3, ImageUrl = "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true }
 });

            // Nike Air Force 1 (Product 2) - White, Black, Purple
            images.AddRange(new[]
      {
          // White colorway
   new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
       new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
   new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop", DisplayOrder = 3, ImageType = "Detail", IsDefault = false, IsActive = true },
         new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", DisplayOrder = 4, ImageType = "Back", IsDefault = false, IsActive = true },
          
         // Black colorway  
    new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
                new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      
                // Purple colorway
   new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 10, ImageUrl = "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
      new ProductImage { ImageID = imageId++, ProductID = 2, ColorID = 10, ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true }
  });

            // Nike React Infinity Run (Product 3) - Blue, Black, Green
            images.AddRange(new[]
     {
      // Blue colorway
      new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 4, ImageUrl = "https://images.unsplash.com/photo-1607522370275-f14206abe5d3?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
                new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 4, ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
   new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 4, ImageUrl = "https://images.unsplash.com/photo-1520256862855-398228c41684?w=500&h=500&fit=crop", DisplayOrder = 3, ImageType = "Detail", IsDefault = false, IsActive = true },
        
    // Black colorway
     new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
       new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      
      // Green colorway
        new ProductImage { ImageID = imageId++, ProductID = 3, ColorID = 5, ImageUrl = "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true }
    });

            // Adidas Ultraboost 22 (Product 4) - White, Black, Blue
            images.AddRange(new[]
            {
// White colorway
             new ProductImage { ImageID = imageId++, ProductID = 4, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
          new ProductImage { ImageID = imageId++, ProductID = 4, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
        
 // Black colorway
     new ProductImage { ImageID = imageId++, ProductID = 4, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
           
    // Blue colorway
     new ProductImage { ImageID = imageId++, ProductID = 4, ColorID = 4, ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true }
       });

            // Adidas Stan Smith (Product 5) - White, Green, Black
            images.AddRange(new[]
          {
 // White colorway
         new ProductImage { ImageID = imageId++, ProductID = 5, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1586525198428-225f6f12cff5?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
           new ProductImage { ImageID = imageId++, ProductID = 5, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
       
     // Green colorway
         new ProductImage { ImageID = imageId++, ProductID = 5, ColorID = 5, ImageUrl = "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
         
          // Black colorway
   new ProductImage { ImageID = imageId++, ProductID = 5, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true }
            });

            // Continue for other products with similar pattern...
            // For brevity, I'll add a few more key products

            // Converse Chuck Taylor (Product 7) - Black, White, Red, Blue
            images.AddRange(new[]
             {
         // Black colorway
new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
            new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      
  // White colorway
  new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1603808033192-082d6919d3e1?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
                new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
   
         // Red colorway
      new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 3, ImageUrl = "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
  
 // Blue colorway
         new ProductImage { ImageID = imageId++, ProductID = 7, ColorID = 4, ImageUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true }
            });

            // Jordan Air 1 Mid (Product 17) - Black, White, Red
            images.AddRange(new[]
            {
             // Black colorway
         new ProductImage { ImageID = imageId++, ProductID = 17, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1556906781-9a412961c28c?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
 new ProductImage { ImageID = imageId++, ProductID = 17, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      
                // White colorway
     new ProductImage { ImageID = imageId++, ProductID = 17, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
             new ProductImage { ImageID = imageId++, ProductID = 17, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
     
         // Red colorway
    new ProductImage { ImageID = imageId++, ProductID = 17, ColorID = 3, ImageUrl = "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true }
   });

            // Nike Dunk Low (Product 20) - Black, White (Panda colorway)
            images.AddRange(new[]
        {
// Black colorway
  new ProductImage { ImageID = imageId++, ProductID = 20, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = true, IsActive = true },
           new ProductImage { ImageID = imageId++, ProductID = 20, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true },
      new ProductImage { ImageID = imageId++, ProductID = 20, ColorID = 1, ImageUrl = "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", DisplayOrder = 3, ImageType = "Detail", IsDefault = false, IsActive = true },
         
           // White colorway
     new ProductImage { ImageID = imageId++, ProductID = 20, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", DisplayOrder = 1, ImageType = "Main", IsDefault = false, IsActive = true },
         new ProductImage { ImageID = imageId++, ProductID = 20, ColorID = 2, ImageUrl = "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", DisplayOrder = 2, ImageType = "Side", IsDefault = false, IsActive = true }
     });

            return images;
        }

        private static decimal GetBasePrice(int productId)
        {
            return productId switch
            {
                1 => 2890000m, // Nike Air Max 270
                2 => 2490000m, // Nike Air Force 1
                3 => 3690000m, // Nike React Infinity Run
                4 => 3450000m, // Adidas Ultraboost 22
                5 => 2190000m, // Adidas Stan Smith
                6 => 3190000m, // Adidas NMD R1
                7 => 1590000m, // Converse Chuck Taylor
                8 => 2890000m, // Converse Run Star Hike
                9 => 2990000m, // New Balance 1080v12
                10 => 2290000m, // New Balance 327
                11 => 1690000m, // Vans Old Skool
                12 => 1990000m, // Vans Sk8-Hi
                13 => 3890000m, // Asics Gel-Kayano 29
                14 => 4190000m, // Asics Gel-Nimbus 25
                15 => 2590000m, // Puma RS-X
                16 => 1790000m, // Puma Suede Classic
                17 => 3290000m, // Jordan Air 1 Mid
                18 => 4890000m, // Jordan Air 4 Retro
                19 => 1990000m, // Reebok Club C 85
                20 => 2390000m, // Nike Dunk Low
                _ => 2000000m
            };
        }

        private static List<int> GetAvailableSizes(int productId)
        {
            // Most products have sizes 36-44, some extend to 45
            return productId switch
            {
                // Running shoes typically have more sizes
                1 or 3 or 4 or 9 or 13 or 14 => new List<int> { 4, 5, 6, 7, 8, 9, 10 }, // 39-45
                                                                                        // Basketball shoes typically larger sizes
                17 or 18 => new List<int> { 4, 5, 6, 7, 8, 9, 10 }, // 39-45
                                                                    // Women's shoes (Run Star Hike)
                8 => new List<int> { 1, 2, 3, 4, 5, 6, 7 }, // 36-42
                                                            // Standard sneakers
                _ => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 } // 36-44
            };
        }

        private static List<int> GetAvailableColors(int productId)
        {
            return productId switch
            {
                // Nike Air Max 270 - Black, White, Red
                1 => new List<int> { 1, 2, 3 },
                // Nike Air Force 1 - White, Black, Purple
                2 => new List<int> { 2, 1, 10 },
                // Nike React Infinity Run - Blue, Black, Green
                3 => new List<int> { 4, 1, 5 },
                // Adidas Ultraboost 22 - White, Black, Blue
                4 => new List<int> { 2, 1, 4 },
                // Adidas Stan Smith - White, Green, Black
                5 => new List<int> { 2, 5, 1 },
                // Adidas NMD R1 - Black, White, Pink
                6 => new List<int> { 1, 2, 8 },
                // Converse Chuck Taylor - Black, White, Red, Blue
                7 => new List<int> { 1, 2, 3, 4 },
                // Converse Run Star Hike - Black, White, Pink
                8 => new List<int> { 1, 2, 8 },
                // New Balance 1080v12 - Blue, Grey, Black
                9 => new List<int> { 4, 6, 1 },
                // New Balance 327 - Yellow, Blue, White
                10 => new List<int> { 7, 4, 2 },
                // Vans Old Skool - Black, White, Brown
                11 => new List<int> { 1, 2, 11 },
                // Vans Sk8-Hi - Black, White, Orange
                12 => new List<int> { 1, 2, 9 },
                // Asics Gel-Kayano 29 - Blue, Black, Green
                13 => new List<int> { 4, 1, 5 },
                // Asics Gel-Nimbus 25 - Blue, Pink, Black
                14 => new List<int> { 4, 8, 1 },
                // Puma RS-X - White, Pink, Yellow
                15 => new List<int> { 2, 8, 7 },
                // Puma Suede Classic - Blue, Red, Black
                16 => new List<int> { 4, 3, 1 },
                // Jordan Air 1 Mid - Black, White, Red
                17 => new List<int> { 1, 2, 3 },
                // Jordan Air 4 Retro - White, Black, Red
                18 => new List<int> { 2, 1, 3 },
                // Reebok Club C 85 - White, Black, Green
                19 => new List<int> { 2, 1, 5 },
                // Nike Dunk Low - Black, White
                20 => new List<int> { 1, 2 },
                _ => new List<int> { 1, 2 } // Default: Black, White
            };
        }
    }
}
