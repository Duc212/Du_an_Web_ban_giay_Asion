using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Just Do It - Thương hiệu thể thao hàng đầu thế giới", "Nike" },
                    { 2, "Impossible is Nothing - Thương hiệu thể thao Đức", "Adidas" },
                    { 3, "Thương hiệu giày thể thao cổ điển Mỹ", "Converse" },
                    { 4, "Thương hiệu giày chạy bộ chất lượng cao", "New Balance" },
                    { 5, "Thương hiệu giày skateboard và streetwear", "Vans" },
                    { 6, "Thương hiệu giày thể thao Nhật Bản", "Asics" },
                    { 7, "Thương hiệu thể thao Đức với logo báo", "Puma" },
                    { 8, "Thương hiệu giày bóng rổ cao cấp của Nike", "Jordan" },
                    { 9, "Thương hiệu thể thao và fitness", "Reebok" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Giày dành cho chạy bộ và tập luyện cardio", "Chạy bộ" },
                    { 2, "Giày thể thao thời trang hàng ngày", "Thời trang" },
                    { 3, "Giày chuyên dụng cho bóng rổ", "Bóng rổ" },
                    { 4, "Giày chuyên dụng cho tennis", "Tennis" },
                    { 5, "Giày dành cho skateboarding", "Skateboard" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "Name" },
                values: new object[,]
                {
                    { 1, "Đen" },
                    { 2, "Trắng" },
                    { 3, "Đỏ" },
                    { 4, "Xanh dương" },
                    { 5, "Xanh lá" },
                    { 6, "Xám" },
                    { 7, "Vàng" },
                    { 8, "Hồng" },
                    { 9, "Cam" },
                    { 10, "Tím" },
                    { 11, "Nâu" },
                    { 12, "Bạc" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "Name" },
                values: new object[,]
                {
                    { 1, "Nam" },
                    { 2, "Nữ" },
                    { 3, "Unisex" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Value" },
                values: new object[,]
                {
                    { 1, "36" },
                    { 2, "37" },
                    { 3, "38" },
                    { 4, "39" },
                    { 5, "40" },
                    { 6, "41" },
                    { 7, "42" },
                    { 8, "43" },
                    { 9, "44" },
                    { 10, "45" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 31, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(389), "ODli93Qgtf77g449EANuiuWecZUvZvubpCm61flWh18" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 31, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(449), "J7kaHO_B3CFFsY3Cv7yCi2P5yX9LHlLL4y4l1Qcf3ZQ" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandId", "CategoryId", "CreatedAt", "Description", "GenderId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 10, 1, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(668), "Giày thể thao Nike Air Max 270 với công nghệ đệm khí Max Air lớn nhất từ trước đến nay. Thiết kế hiện đại, phù hợp cho cả tập luyện và phong cách hàng ngày.", 3, "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", "Nike Air Max 270" },
                    { 2, 1, 2, new DateTime(2025, 10, 6, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(677), "Giày thể thao Nike Air Force 1 '07 - biểu tượng thời trang streetwear với thiết kế vượt thời gian và chất lượng bền bỉ.", 3, "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", "Nike Air Force 1 '07" },
                    { 3, 1, 1, new DateTime(2025, 10, 11, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(679), "Giày chạy bộ Nike React Infinity Run được thiết kế để giảm chấn thương. Công nghệ React foam mang lại độ đàn hồi tuyệt vời.", 3, "https://images.unsplash.com/photo-1607522370275-f14206abe5d3?w=500&h=500&fit=crop", "Nike React Infinity Run" },
                    { 4, 2, 1, new DateTime(2025, 10, 13, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(681), "Giày chạy bộ Adidas Ultraboost 22 với công nghệ Boost mang lại năng lượng trở lại mỗi bước chạy. Thiết kế Primeknit+ ôm chân tự nhiên.", 3, "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop", "Adidas Ultraboost 22" },
                    { 5, 2, 4, new DateTime(2025, 10, 16, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(683), "Giày tennis Adidas Stan Smith - thiết kế tối giản, thanh lịch với màu trắng cổ điển. Phù hợp cho mọi phong cách thời trang.", 3, "https://images.unsplash.com/photo-1586525198428-225f6f12cff5?w=500&h=500&fit=crop", "Adidas Stan Smith" },
                    { 6, 2, 2, new DateTime(2025, 10, 19, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(685), "Giày thể thao Adidas NMD R1 với thiết kế futuristic. Kết hợp công nghệ Boost với phong cách streetwear hiện đại.", 3, "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop", "Adidas NMD R1" },
                    { 7, 3, 2, new DateTime(2025, 10, 21, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(686), "Giày thể thao classic Converse Chuck Taylor All Star. Thiết kế vượt thời gian, phù hợp với mọi phong cách và độ tuổi.", 3, "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop", "Converse Chuck Taylor All Star" },
                    { 8, 3, 2, new DateTime(2025, 10, 23, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(688), "Giày Converse Run Star Hike với đế platform độc đáo. Kết hợp phong cách Chuck Taylor cổ điển với xu hướng chunky hiện đại.", 2, "https://images.unsplash.com/photo-1603808033192-082d6919d3e1?w=500&h=500&fit=crop", "Converse Run Star Hike" },
                    { 9, 4, 1, new DateTime(2025, 10, 25, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(690), "Giày chạy bộ New Balance 1080v12 với công nghệ Fresh Foam X mang lại cảm giác êm ái và đàn hồi tuyệt vời cho những chuyến chạy dài.", 3, "https://images.unsplash.com/photo-1539185441755-769473a23570?w=500&h=500&fit=crop", "New Balance Fresh Foam X 1080v12" },
                    { 10, 4, 2, new DateTime(2025, 10, 27, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(691), "Giày New Balance 327 lấy cảm hứng từ thiết kế vintage 70s với twist hiện đại. Phong cách retro-modern độc đáo.", 3, "https://images.unsplash.com/photo-1605348532760-6753d2c43329?w=500&h=500&fit=crop", "New Balance 327" },
                    { 11, 5, 5, new DateTime(2025, 10, 28, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(693), "Giày Vans Old Skool với thiết kế side stripe đặc trưng. Phù hợp cho skateboarding và phong cách casual hàng ngày.", 3, "https://images.unsplash.com/photo-1525966222134-fcfa99b8ae77?w=500&h=500&fit=crop", "Vans Old Skool" },
                    { 12, 5, 5, new DateTime(2025, 10, 29, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(695), "Giày Vans Sk8-Hi cổ cao với thiết kế ankle support. Phù hợp cho skateboarding và phong cách streetwear năng động.", 3, "https://images.unsplash.com/photo-1544966503-7cc5ac882d5f?w=500&h=500&fit=crop", "Vans Sk8-Hi" },
                    { 13, 6, 1, new DateTime(2025, 10, 30, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(696), "Giày chạy bộ Asics Gel-Kayano 29 dành cho những vận động viên cần độ ổn định cao. Công nghệ FlyteFoam và Gel giảm chấn tối ưu.", 3, "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop", "Asics Gel-Kayano 29" },
                    { 14, 6, 1, new DateTime(2025, 10, 31, 16, 24, 15, 592, DateTimeKind.Local).AddTicks(698), "Giày chạy bộ Asics Gel-Nimbus 25 với công nghệ đệm tiên tiến nhất. Mang lại trải nghiệm chạy êm ái và thoải mái tối đa.", 3, "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop", "Asics Gel-Nimbus 25" },
                    { 15, 7, 2, new DateTime(2025, 10, 31, 4, 24, 15, 592, DateTimeKind.Local).AddTicks(705), "Giày thể thao Puma RS-X với thiết kế chunky sneaker xu hướng. Kết hợp phong cách retro và công nghệ hiện đại.", 3, "https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?w=500&h=500&fit=crop", "Puma RS-X Reinvention" },
                    { 16, 7, 2, new DateTime(2025, 10, 31, 10, 24, 15, 592, DateTimeKind.Local).AddTicks(709), "Giày Puma Suede Classic - biểu tượng thời trang từ những năm 1960s. Chất liệu da lộn cao cấp với thiết kế vượt thời gian.", 3, "https://images.unsplash.com/photo-1552346154-21d32810aba3?w=500&h=500&fit=crop", "Puma Suede Classic" },
                    { 17, 8, 3, new DateTime(2025, 10, 31, 13, 24, 15, 592, DateTimeKind.Local).AddTicks(712), "Giày bóng rổ Jordan Air 1 Mid - huyền thoại basketball với thiết kế iconic. Chất lượng premium cho cả sân bóng và đường phố.", 3, "https://images.unsplash.com/photo-1556906781-9a412961c28c?w=500&h=500&fit=crop", "Jordan Air 1 Mid" },
                    { 18, 8, 3, new DateTime(2025, 10, 31, 15, 24, 15, 592, DateTimeKind.Local).AddTicks(714), "Giày bóng rổ Jordan Air 4 Retro - một trong những mẫu Jordan iconic nhất mọi thời đại với thiết kế wing và mesh panels đặc trưng.", 3, "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", "Jordan Air 4 Retro" },
                    { 19, 9, 4, new DateTime(2025, 10, 31, 15, 54, 15, 592, DateTimeKind.Local).AddTicks(716), "Giày tennis cổ điển Reebok Club C 85 với thiết kế tối giản, thanh lịch. Phù hợp cho nhiều hoạt động thể thao và thời trang.", 3, "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", "Reebok Club C 85" },
                    { 20, 1, 2, new DateTime(2025, 10, 31, 16, 9, 15, 592, DateTimeKind.Local).AddTicks(717), "Giày Nike Dunk Low Retro với colorway Panda cổ điển. Thiết kế basketball vintage trở thành biểu tượng streetwear.", 3, "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", "Nike Dunk Low Retro" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "VariantID", "ColorID", "ImportPrice", "ProductID", "SellingPrice", "SizeID", "Status", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 2023000.0m, 1, 2890000m, 4, "Active", 37 },
                    { 2, 2, 2023000.0m, 1, 2890000m, 4, "Active", 83 },
                    { 3, 3, 2023000.0m, 1, 2890000m, 4, "Active", 29 },
                    { 4, 1, 2023000.0m, 1, 2890000m, 5, "Active", 65 },
                    { 5, 2, 2023000.0m, 1, 2890000m, 5, "Active", 22 },
                    { 6, 3, 2023000.0m, 1, 2890000m, 5, "Active", 77 },
                    { 7, 1, 2023000.0m, 1, 2890000m, 6, "Active", 50 },
                    { 8, 2, 2023000.0m, 1, 2890000m, 6, "Active", 70 },
                    { 9, 3, 2023000.0m, 1, 2890000m, 6, "Active", 46 },
                    { 10, 1, 2023000.0m, 1, 2890000m, 7, "Active", 21 },
                    { 11, 2, 2023000.0m, 1, 2890000m, 7, "Active", 75 },
                    { 12, 3, 2023000.0m, 1, 2890000m, 7, "Active", 35 },
                    { 13, 1, 2023000.0m, 1, 2890000m, 8, "Active", 46 },
                    { 14, 2, 2023000.0m, 1, 2890000m, 8, "Active", 16 },
                    { 15, 3, 2023000.0m, 1, 2890000m, 8, "Active", 47 },
                    { 16, 1, 2023000.0m, 1, 2890000m, 9, "Active", 54 },
                    { 17, 2, 2023000.0m, 1, 2890000m, 9, "Active", 58 },
                    { 18, 3, 2023000.0m, 1, 2890000m, 9, "Active", 37 },
                    { 19, 1, 2023000.0m, 1, 2890000m, 10, "Active", 98 },
                    { 20, 2, 2023000.0m, 1, 2890000m, 10, "Active", 64 },
                    { 21, 3, 2023000.0m, 1, 2890000m, 10, "Active", 53 },
                    { 22, 2, 1743000.0m, 2, 2490000m, 1, "Active", 41 },
                    { 23, 1, 1743000.0m, 2, 2490000m, 1, "Active", 36 },
                    { 24, 10, 1743000.0m, 2, 2490000m, 1, "Active", 62 },
                    { 25, 2, 1743000.0m, 2, 2490000m, 2, "Active", 76 },
                    { 26, 1, 1743000.0m, 2, 2490000m, 2, "Active", 72 },
                    { 27, 10, 1743000.0m, 2, 2490000m, 2, "Active", 62 },
                    { 28, 2, 1743000.0m, 2, 2490000m, 3, "Active", 86 },
                    { 29, 1, 1743000.0m, 2, 2490000m, 3, "Active", 31 },
                    { 30, 10, 1743000.0m, 2, 2490000m, 3, "Active", 27 },
                    { 31, 2, 1743000.0m, 2, 2490000m, 4, "Active", 98 },
                    { 32, 1, 1743000.0m, 2, 2490000m, 4, "Active", 60 },
                    { 33, 10, 1743000.0m, 2, 2490000m, 4, "Active", 72 },
                    { 34, 2, 1743000.0m, 2, 2490000m, 5, "Active", 61 },
                    { 35, 1, 1743000.0m, 2, 2490000m, 5, "Active", 11 },
                    { 36, 10, 1743000.0m, 2, 2490000m, 5, "Active", 75 },
                    { 37, 2, 1743000.0m, 2, 2490000m, 6, "Active", 43 },
                    { 38, 1, 1743000.0m, 2, 2490000m, 6, "Active", 71 },
                    { 39, 10, 1743000.0m, 2, 2490000m, 6, "Active", 61 },
                    { 40, 2, 1743000.0m, 2, 2490000m, 7, "Active", 22 },
                    { 41, 1, 1743000.0m, 2, 2490000m, 7, "Active", 61 },
                    { 42, 10, 1743000.0m, 2, 2490000m, 7, "Active", 58 },
                    { 43, 2, 1743000.0m, 2, 2490000m, 8, "Active", 29 },
                    { 44, 1, 1743000.0m, 2, 2490000m, 8, "Active", 80 },
                    { 45, 10, 1743000.0m, 2, 2490000m, 8, "Active", 81 },
                    { 46, 2, 1743000.0m, 2, 2490000m, 9, "Active", 97 },
                    { 47, 1, 1743000.0m, 2, 2490000m, 9, "Active", 17 },
                    { 48, 10, 1743000.0m, 2, 2490000m, 9, "Active", 13 },
                    { 49, 4, 2583000.0m, 3, 3690000m, 4, "Active", 30 },
                    { 50, 1, 2583000.0m, 3, 3690000m, 4, "Active", 66 },
                    { 51, 5, 2583000.0m, 3, 3690000m, 4, "Active", 21 },
                    { 52, 4, 2583000.0m, 3, 3690000m, 5, "Active", 65 },
                    { 53, 1, 2583000.0m, 3, 3690000m, 5, "Active", 48 },
                    { 54, 5, 2583000.0m, 3, 3690000m, 5, "Active", 54 },
                    { 55, 4, 2583000.0m, 3, 3690000m, 6, "Active", 35 },
                    { 56, 1, 2583000.0m, 3, 3690000m, 6, "Active", 94 },
                    { 57, 5, 2583000.0m, 3, 3690000m, 6, "Active", 87 },
                    { 58, 4, 2583000.0m, 3, 3690000m, 7, "Active", 42 },
                    { 59, 1, 2583000.0m, 3, 3690000m, 7, "Active", 37 },
                    { 60, 5, 2583000.0m, 3, 3690000m, 7, "Active", 55 },
                    { 61, 4, 2583000.0m, 3, 3690000m, 8, "Active", 54 },
                    { 62, 1, 2583000.0m, 3, 3690000m, 8, "Active", 17 },
                    { 63, 5, 2583000.0m, 3, 3690000m, 8, "Active", 97 },
                    { 64, 4, 2583000.0m, 3, 3690000m, 9, "Active", 43 },
                    { 65, 1, 2583000.0m, 3, 3690000m, 9, "Active", 38 },
                    { 66, 5, 2583000.0m, 3, 3690000m, 9, "Active", 36 },
                    { 67, 4, 2583000.0m, 3, 3690000m, 10, "Active", 65 },
                    { 68, 1, 2583000.0m, 3, 3690000m, 10, "Active", 61 },
                    { 69, 5, 2583000.0m, 3, 3690000m, 10, "Active", 70 },
                    { 70, 2, 2415000.0m, 4, 3450000m, 4, "Active", 57 },
                    { 71, 1, 2415000.0m, 4, 3450000m, 4, "Active", 54 },
                    { 72, 4, 2415000.0m, 4, 3450000m, 4, "Active", 93 },
                    { 73, 2, 2415000.0m, 4, 3450000m, 5, "Active", 84 },
                    { 74, 1, 2415000.0m, 4, 3450000m, 5, "Active", 86 },
                    { 75, 4, 2415000.0m, 4, 3450000m, 5, "Active", 31 },
                    { 76, 2, 2415000.0m, 4, 3450000m, 6, "Active", 41 },
                    { 77, 1, 2415000.0m, 4, 3450000m, 6, "Active", 25 },
                    { 78, 4, 2415000.0m, 4, 3450000m, 6, "Active", 87 },
                    { 79, 2, 2415000.0m, 4, 3450000m, 7, "Active", 57 },
                    { 80, 1, 2415000.0m, 4, 3450000m, 7, "Active", 84 },
                    { 81, 4, 2415000.0m, 4, 3450000m, 7, "Active", 60 },
                    { 82, 2, 2415000.0m, 4, 3450000m, 8, "Active", 14 },
                    { 83, 1, 2415000.0m, 4, 3450000m, 8, "Active", 15 },
                    { 84, 4, 2415000.0m, 4, 3450000m, 8, "Active", 56 },
                    { 85, 2, 2415000.0m, 4, 3450000m, 9, "Active", 47 },
                    { 86, 1, 2415000.0m, 4, 3450000m, 9, "Active", 22 },
                    { 87, 4, 2415000.0m, 4, 3450000m, 9, "Active", 64 },
                    { 88, 2, 2415000.0m, 4, 3450000m, 10, "Active", 19 },
                    { 89, 1, 2415000.0m, 4, 3450000m, 10, "Active", 96 },
                    { 90, 4, 2415000.0m, 4, 3450000m, 10, "Active", 78 },
                    { 91, 2, 1533000.0m, 5, 2190000m, 1, "Active", 47 },
                    { 92, 5, 1533000.0m, 5, 2190000m, 1, "Active", 69 },
                    { 93, 1, 1533000.0m, 5, 2190000m, 1, "Active", 96 },
                    { 94, 2, 1533000.0m, 5, 2190000m, 2, "Active", 32 },
                    { 95, 5, 1533000.0m, 5, 2190000m, 2, "Active", 69 },
                    { 96, 1, 1533000.0m, 5, 2190000m, 2, "Active", 69 },
                    { 97, 2, 1533000.0m, 5, 2190000m, 3, "Active", 53 },
                    { 98, 5, 1533000.0m, 5, 2190000m, 3, "Active", 92 },
                    { 99, 1, 1533000.0m, 5, 2190000m, 3, "Active", 67 },
                    { 100, 2, 1533000.0m, 5, 2190000m, 4, "Active", 68 },
                    { 101, 5, 1533000.0m, 5, 2190000m, 4, "Active", 72 },
                    { 102, 1, 1533000.0m, 5, 2190000m, 4, "Active", 95 },
                    { 103, 2, 1533000.0m, 5, 2190000m, 5, "Active", 47 },
                    { 104, 5, 1533000.0m, 5, 2190000m, 5, "Active", 89 },
                    { 105, 1, 1533000.0m, 5, 2190000m, 5, "Active", 19 },
                    { 106, 2, 1533000.0m, 5, 2190000m, 6, "Active", 69 },
                    { 107, 5, 1533000.0m, 5, 2190000m, 6, "Active", 40 },
                    { 108, 1, 1533000.0m, 5, 2190000m, 6, "Active", 45 },
                    { 109, 2, 1533000.0m, 5, 2190000m, 7, "Active", 51 },
                    { 110, 5, 1533000.0m, 5, 2190000m, 7, "Active", 53 },
                    { 111, 1, 1533000.0m, 5, 2190000m, 7, "Active", 41 },
                    { 112, 2, 1533000.0m, 5, 2190000m, 8, "Active", 46 },
                    { 113, 5, 1533000.0m, 5, 2190000m, 8, "Active", 62 },
                    { 114, 1, 1533000.0m, 5, 2190000m, 8, "Active", 45 },
                    { 115, 2, 1533000.0m, 5, 2190000m, 9, "Active", 32 },
                    { 116, 5, 1533000.0m, 5, 2190000m, 9, "Active", 50 },
                    { 117, 1, 1533000.0m, 5, 2190000m, 9, "Active", 68 },
                    { 118, 1, 2233000.0m, 6, 3190000m, 1, "Active", 72 },
                    { 119, 2, 2233000.0m, 6, 3190000m, 1, "Active", 12 },
                    { 120, 8, 2233000.0m, 6, 3190000m, 1, "Active", 88 },
                    { 121, 1, 2233000.0m, 6, 3190000m, 2, "Active", 43 },
                    { 122, 2, 2233000.0m, 6, 3190000m, 2, "Active", 34 },
                    { 123, 8, 2233000.0m, 6, 3190000m, 2, "Active", 12 },
                    { 124, 1, 2233000.0m, 6, 3190000m, 3, "Active", 80 },
                    { 125, 2, 2233000.0m, 6, 3190000m, 3, "Active", 93 },
                    { 126, 8, 2233000.0m, 6, 3190000m, 3, "Active", 92 },
                    { 127, 1, 2233000.0m, 6, 3190000m, 4, "Active", 79 },
                    { 128, 2, 2233000.0m, 6, 3190000m, 4, "Active", 28 },
                    { 129, 8, 2233000.0m, 6, 3190000m, 4, "Active", 17 },
                    { 130, 1, 2233000.0m, 6, 3190000m, 5, "Active", 22 },
                    { 131, 2, 2233000.0m, 6, 3190000m, 5, "Active", 97 },
                    { 132, 8, 2233000.0m, 6, 3190000m, 5, "Active", 88 },
                    { 133, 1, 2233000.0m, 6, 3190000m, 6, "Active", 72 },
                    { 134, 2, 2233000.0m, 6, 3190000m, 6, "Active", 40 },
                    { 135, 8, 2233000.0m, 6, 3190000m, 6, "Active", 81 },
                    { 136, 1, 2233000.0m, 6, 3190000m, 7, "Active", 42 },
                    { 137, 2, 2233000.0m, 6, 3190000m, 7, "Active", 45 },
                    { 138, 8, 2233000.0m, 6, 3190000m, 7, "Active", 43 },
                    { 139, 1, 2233000.0m, 6, 3190000m, 8, "Active", 66 },
                    { 140, 2, 2233000.0m, 6, 3190000m, 8, "Active", 99 },
                    { 141, 8, 2233000.0m, 6, 3190000m, 8, "Active", 36 },
                    { 142, 1, 2233000.0m, 6, 3190000m, 9, "Active", 77 },
                    { 143, 2, 2233000.0m, 6, 3190000m, 9, "Active", 74 },
                    { 144, 8, 2233000.0m, 6, 3190000m, 9, "Active", 78 },
                    { 145, 1, 1113000.0m, 7, 1590000m, 1, "Active", 13 },
                    { 146, 2, 1113000.0m, 7, 1590000m, 1, "Active", 47 },
                    { 147, 3, 1113000.0m, 7, 1590000m, 1, "Active", 50 },
                    { 148, 4, 1113000.0m, 7, 1590000m, 1, "Active", 93 },
                    { 149, 1, 1113000.0m, 7, 1590000m, 2, "Active", 98 },
                    { 150, 2, 1113000.0m, 7, 1590000m, 2, "Active", 10 },
                    { 151, 3, 1113000.0m, 7, 1590000m, 2, "Active", 37 },
                    { 152, 4, 1113000.0m, 7, 1590000m, 2, "Active", 64 },
                    { 153, 1, 1113000.0m, 7, 1590000m, 3, "Active", 89 },
                    { 154, 2, 1113000.0m, 7, 1590000m, 3, "Active", 94 },
                    { 155, 3, 1113000.0m, 7, 1590000m, 3, "Active", 41 },
                    { 156, 4, 1113000.0m, 7, 1590000m, 3, "Active", 90 },
                    { 157, 1, 1113000.0m, 7, 1590000m, 4, "Active", 27 },
                    { 158, 2, 1113000.0m, 7, 1590000m, 4, "Active", 79 },
                    { 159, 3, 1113000.0m, 7, 1590000m, 4, "Active", 32 },
                    { 160, 4, 1113000.0m, 7, 1590000m, 4, "Active", 93 },
                    { 161, 1, 1113000.0m, 7, 1590000m, 5, "Active", 13 },
                    { 162, 2, 1113000.0m, 7, 1590000m, 5, "Active", 91 },
                    { 163, 3, 1113000.0m, 7, 1590000m, 5, "Active", 82 },
                    { 164, 4, 1113000.0m, 7, 1590000m, 5, "Active", 11 },
                    { 165, 1, 1113000.0m, 7, 1590000m, 6, "Active", 70 },
                    { 166, 2, 1113000.0m, 7, 1590000m, 6, "Active", 68 },
                    { 167, 3, 1113000.0m, 7, 1590000m, 6, "Active", 99 },
                    { 168, 4, 1113000.0m, 7, 1590000m, 6, "Active", 49 },
                    { 169, 1, 1113000.0m, 7, 1590000m, 7, "Active", 81 },
                    { 170, 2, 1113000.0m, 7, 1590000m, 7, "Active", 43 },
                    { 171, 3, 1113000.0m, 7, 1590000m, 7, "Active", 26 },
                    { 172, 4, 1113000.0m, 7, 1590000m, 7, "Active", 61 },
                    { 173, 1, 1113000.0m, 7, 1590000m, 8, "Active", 76 },
                    { 174, 2, 1113000.0m, 7, 1590000m, 8, "Active", 71 },
                    { 175, 3, 1113000.0m, 7, 1590000m, 8, "Active", 23 },
                    { 176, 4, 1113000.0m, 7, 1590000m, 8, "Active", 48 },
                    { 177, 1, 1113000.0m, 7, 1590000m, 9, "Active", 97 },
                    { 178, 2, 1113000.0m, 7, 1590000m, 9, "Active", 20 },
                    { 179, 3, 1113000.0m, 7, 1590000m, 9, "Active", 16 },
                    { 180, 4, 1113000.0m, 7, 1590000m, 9, "Active", 67 },
                    { 181, 1, 2023000.0m, 8, 2890000m, 1, "Active", 43 },
                    { 182, 2, 2023000.0m, 8, 2890000m, 1, "Active", 12 },
                    { 183, 8, 2023000.0m, 8, 2890000m, 1, "Active", 26 },
                    { 184, 1, 2023000.0m, 8, 2890000m, 2, "Active", 16 },
                    { 185, 2, 2023000.0m, 8, 2890000m, 2, "Active", 68 },
                    { 186, 8, 2023000.0m, 8, 2890000m, 2, "Active", 29 },
                    { 187, 1, 2023000.0m, 8, 2890000m, 3, "Active", 35 },
                    { 188, 2, 2023000.0m, 8, 2890000m, 3, "Active", 93 },
                    { 189, 8, 2023000.0m, 8, 2890000m, 3, "Active", 18 },
                    { 190, 1, 2023000.0m, 8, 2890000m, 4, "Active", 95 },
                    { 191, 2, 2023000.0m, 8, 2890000m, 4, "Active", 83 },
                    { 192, 8, 2023000.0m, 8, 2890000m, 4, "Active", 13 },
                    { 193, 1, 2023000.0m, 8, 2890000m, 5, "Active", 27 },
                    { 194, 2, 2023000.0m, 8, 2890000m, 5, "Active", 67 },
                    { 195, 8, 2023000.0m, 8, 2890000m, 5, "Active", 85 },
                    { 196, 1, 2023000.0m, 8, 2890000m, 6, "Active", 56 },
                    { 197, 2, 2023000.0m, 8, 2890000m, 6, "Active", 80 },
                    { 198, 8, 2023000.0m, 8, 2890000m, 6, "Active", 65 },
                    { 199, 1, 2023000.0m, 8, 2890000m, 7, "Active", 34 },
                    { 200, 2, 2023000.0m, 8, 2890000m, 7, "Active", 10 },
                    { 201, 8, 2023000.0m, 8, 2890000m, 7, "Active", 74 },
                    { 202, 4, 2093000.0m, 9, 2990000m, 4, "Active", 38 },
                    { 203, 6, 2093000.0m, 9, 2990000m, 4, "Active", 14 },
                    { 204, 1, 2093000.0m, 9, 2990000m, 4, "Active", 84 },
                    { 205, 4, 2093000.0m, 9, 2990000m, 5, "Active", 98 },
                    { 206, 6, 2093000.0m, 9, 2990000m, 5, "Active", 41 },
                    { 207, 1, 2093000.0m, 9, 2990000m, 5, "Active", 39 },
                    { 208, 4, 2093000.0m, 9, 2990000m, 6, "Active", 34 },
                    { 209, 6, 2093000.0m, 9, 2990000m, 6, "Active", 80 },
                    { 210, 1, 2093000.0m, 9, 2990000m, 6, "Active", 71 },
                    { 211, 4, 2093000.0m, 9, 2990000m, 7, "Active", 63 },
                    { 212, 6, 2093000.0m, 9, 2990000m, 7, "Active", 56 },
                    { 213, 1, 2093000.0m, 9, 2990000m, 7, "Active", 48 },
                    { 214, 4, 2093000.0m, 9, 2990000m, 8, "Active", 52 },
                    { 215, 6, 2093000.0m, 9, 2990000m, 8, "Active", 51 },
                    { 216, 1, 2093000.0m, 9, 2990000m, 8, "Active", 32 },
                    { 217, 4, 2093000.0m, 9, 2990000m, 9, "Active", 20 },
                    { 218, 6, 2093000.0m, 9, 2990000m, 9, "Active", 65 },
                    { 219, 1, 2093000.0m, 9, 2990000m, 9, "Active", 17 },
                    { 220, 4, 2093000.0m, 9, 2990000m, 10, "Active", 26 },
                    { 221, 6, 2093000.0m, 9, 2990000m, 10, "Active", 48 },
                    { 222, 1, 2093000.0m, 9, 2990000m, 10, "Active", 17 },
                    { 223, 7, 1603000.0m, 10, 2290000m, 1, "Active", 85 },
                    { 224, 4, 1603000.0m, 10, 2290000m, 1, "Active", 92 },
                    { 225, 2, 1603000.0m, 10, 2290000m, 1, "Active", 82 },
                    { 226, 7, 1603000.0m, 10, 2290000m, 2, "Active", 83 },
                    { 227, 4, 1603000.0m, 10, 2290000m, 2, "Active", 70 },
                    { 228, 2, 1603000.0m, 10, 2290000m, 2, "Active", 78 },
                    { 229, 7, 1603000.0m, 10, 2290000m, 3, "Active", 68 },
                    { 230, 4, 1603000.0m, 10, 2290000m, 3, "Active", 27 },
                    { 231, 2, 1603000.0m, 10, 2290000m, 3, "Active", 95 },
                    { 232, 7, 1603000.0m, 10, 2290000m, 4, "Active", 31 },
                    { 233, 4, 1603000.0m, 10, 2290000m, 4, "Active", 62 },
                    { 234, 2, 1603000.0m, 10, 2290000m, 4, "Active", 24 },
                    { 235, 7, 1603000.0m, 10, 2290000m, 5, "Active", 73 },
                    { 236, 4, 1603000.0m, 10, 2290000m, 5, "Active", 53 },
                    { 237, 2, 1603000.0m, 10, 2290000m, 5, "Active", 41 },
                    { 238, 7, 1603000.0m, 10, 2290000m, 6, "Active", 97 },
                    { 239, 4, 1603000.0m, 10, 2290000m, 6, "Active", 24 },
                    { 240, 2, 1603000.0m, 10, 2290000m, 6, "Active", 22 },
                    { 241, 7, 1603000.0m, 10, 2290000m, 7, "Active", 61 },
                    { 242, 4, 1603000.0m, 10, 2290000m, 7, "Active", 87 },
                    { 243, 2, 1603000.0m, 10, 2290000m, 7, "Active", 70 },
                    { 244, 7, 1603000.0m, 10, 2290000m, 8, "Active", 35 },
                    { 245, 4, 1603000.0m, 10, 2290000m, 8, "Active", 89 },
                    { 246, 2, 1603000.0m, 10, 2290000m, 8, "Active", 54 },
                    { 247, 7, 1603000.0m, 10, 2290000m, 9, "Active", 22 },
                    { 248, 4, 1603000.0m, 10, 2290000m, 9, "Active", 37 },
                    { 249, 2, 1603000.0m, 10, 2290000m, 9, "Active", 48 },
                    { 250, 1, 1183000.0m, 11, 1690000m, 1, "Active", 72 },
                    { 251, 2, 1183000.0m, 11, 1690000m, 1, "Active", 79 },
                    { 252, 11, 1183000.0m, 11, 1690000m, 1, "Active", 34 },
                    { 253, 1, 1183000.0m, 11, 1690000m, 2, "Active", 34 },
                    { 254, 2, 1183000.0m, 11, 1690000m, 2, "Active", 57 },
                    { 255, 11, 1183000.0m, 11, 1690000m, 2, "Active", 19 },
                    { 256, 1, 1183000.0m, 11, 1690000m, 3, "Active", 15 },
                    { 257, 2, 1183000.0m, 11, 1690000m, 3, "Active", 72 },
                    { 258, 11, 1183000.0m, 11, 1690000m, 3, "Active", 85 },
                    { 259, 1, 1183000.0m, 11, 1690000m, 4, "Active", 39 },
                    { 260, 2, 1183000.0m, 11, 1690000m, 4, "Active", 38 },
                    { 261, 11, 1183000.0m, 11, 1690000m, 4, "Active", 12 },
                    { 262, 1, 1183000.0m, 11, 1690000m, 5, "Active", 75 },
                    { 263, 2, 1183000.0m, 11, 1690000m, 5, "Active", 73 },
                    { 264, 11, 1183000.0m, 11, 1690000m, 5, "Active", 54 },
                    { 265, 1, 1183000.0m, 11, 1690000m, 6, "Active", 60 },
                    { 266, 2, 1183000.0m, 11, 1690000m, 6, "Active", 22 },
                    { 267, 11, 1183000.0m, 11, 1690000m, 6, "Active", 83 },
                    { 268, 1, 1183000.0m, 11, 1690000m, 7, "Active", 29 },
                    { 269, 2, 1183000.0m, 11, 1690000m, 7, "Active", 34 },
                    { 270, 11, 1183000.0m, 11, 1690000m, 7, "Active", 13 },
                    { 271, 1, 1183000.0m, 11, 1690000m, 8, "Active", 20 },
                    { 272, 2, 1183000.0m, 11, 1690000m, 8, "Active", 55 },
                    { 273, 11, 1183000.0m, 11, 1690000m, 8, "Active", 35 },
                    { 274, 1, 1183000.0m, 11, 1690000m, 9, "Active", 48 },
                    { 275, 2, 1183000.0m, 11, 1690000m, 9, "Active", 83 },
                    { 276, 11, 1183000.0m, 11, 1690000m, 9, "Active", 14 },
                    { 277, 1, 1393000.0m, 12, 1990000m, 1, "Active", 61 },
                    { 278, 2, 1393000.0m, 12, 1990000m, 1, "Active", 77 },
                    { 279, 9, 1393000.0m, 12, 1990000m, 1, "Active", 20 },
                    { 280, 1, 1393000.0m, 12, 1990000m, 2, "Active", 13 },
                    { 281, 2, 1393000.0m, 12, 1990000m, 2, "Active", 24 },
                    { 282, 9, 1393000.0m, 12, 1990000m, 2, "Active", 18 },
                    { 283, 1, 1393000.0m, 12, 1990000m, 3, "Active", 86 },
                    { 284, 2, 1393000.0m, 12, 1990000m, 3, "Active", 57 },
                    { 285, 9, 1393000.0m, 12, 1990000m, 3, "Active", 82 },
                    { 286, 1, 1393000.0m, 12, 1990000m, 4, "Active", 93 },
                    { 287, 2, 1393000.0m, 12, 1990000m, 4, "Active", 76 },
                    { 288, 9, 1393000.0m, 12, 1990000m, 4, "Active", 76 },
                    { 289, 1, 1393000.0m, 12, 1990000m, 5, "Active", 43 },
                    { 290, 2, 1393000.0m, 12, 1990000m, 5, "Active", 63 },
                    { 291, 9, 1393000.0m, 12, 1990000m, 5, "Active", 77 },
                    { 292, 1, 1393000.0m, 12, 1990000m, 6, "Active", 60 },
                    { 293, 2, 1393000.0m, 12, 1990000m, 6, "Active", 43 },
                    { 294, 9, 1393000.0m, 12, 1990000m, 6, "Active", 15 },
                    { 295, 1, 1393000.0m, 12, 1990000m, 7, "Active", 49 },
                    { 296, 2, 1393000.0m, 12, 1990000m, 7, "Active", 33 },
                    { 297, 9, 1393000.0m, 12, 1990000m, 7, "Active", 95 },
                    { 298, 1, 1393000.0m, 12, 1990000m, 8, "Active", 68 },
                    { 299, 2, 1393000.0m, 12, 1990000m, 8, "Active", 61 },
                    { 300, 9, 1393000.0m, 12, 1990000m, 8, "Active", 33 },
                    { 301, 1, 1393000.0m, 12, 1990000m, 9, "Active", 51 },
                    { 302, 2, 1393000.0m, 12, 1990000m, 9, "Active", 69 },
                    { 303, 9, 1393000.0m, 12, 1990000m, 9, "Active", 31 },
                    { 304, 4, 2723000.0m, 13, 3890000m, 4, "Active", 23 },
                    { 305, 1, 2723000.0m, 13, 3890000m, 4, "Active", 67 },
                    { 306, 5, 2723000.0m, 13, 3890000m, 4, "Active", 52 },
                    { 307, 4, 2723000.0m, 13, 3890000m, 5, "Active", 86 },
                    { 308, 1, 2723000.0m, 13, 3890000m, 5, "Active", 21 },
                    { 309, 5, 2723000.0m, 13, 3890000m, 5, "Active", 58 },
                    { 310, 4, 2723000.0m, 13, 3890000m, 6, "Active", 31 },
                    { 311, 1, 2723000.0m, 13, 3890000m, 6, "Active", 41 },
                    { 312, 5, 2723000.0m, 13, 3890000m, 6, "Active", 83 },
                    { 313, 4, 2723000.0m, 13, 3890000m, 7, "Active", 71 },
                    { 314, 1, 2723000.0m, 13, 3890000m, 7, "Active", 65 },
                    { 315, 5, 2723000.0m, 13, 3890000m, 7, "Active", 65 },
                    { 316, 4, 2723000.0m, 13, 3890000m, 8, "Active", 79 },
                    { 317, 1, 2723000.0m, 13, 3890000m, 8, "Active", 50 },
                    { 318, 5, 2723000.0m, 13, 3890000m, 8, "Active", 54 },
                    { 319, 4, 2723000.0m, 13, 3890000m, 9, "Active", 91 },
                    { 320, 1, 2723000.0m, 13, 3890000m, 9, "Active", 56 },
                    { 321, 5, 2723000.0m, 13, 3890000m, 9, "Active", 12 },
                    { 322, 4, 2723000.0m, 13, 3890000m, 10, "Active", 93 },
                    { 323, 1, 2723000.0m, 13, 3890000m, 10, "Active", 50 },
                    { 324, 5, 2723000.0m, 13, 3890000m, 10, "Active", 54 },
                    { 325, 4, 2933000.0m, 14, 4190000m, 4, "Active", 27 },
                    { 326, 8, 2933000.0m, 14, 4190000m, 4, "Active", 85 },
                    { 327, 1, 2933000.0m, 14, 4190000m, 4, "Active", 17 },
                    { 328, 4, 2933000.0m, 14, 4190000m, 5, "Active", 74 },
                    { 329, 8, 2933000.0m, 14, 4190000m, 5, "Active", 26 },
                    { 330, 1, 2933000.0m, 14, 4190000m, 5, "Active", 32 },
                    { 331, 4, 2933000.0m, 14, 4190000m, 6, "Active", 10 },
                    { 332, 8, 2933000.0m, 14, 4190000m, 6, "Active", 21 },
                    { 333, 1, 2933000.0m, 14, 4190000m, 6, "Active", 92 },
                    { 334, 4, 2933000.0m, 14, 4190000m, 7, "Active", 10 },
                    { 335, 8, 2933000.0m, 14, 4190000m, 7, "Active", 39 },
                    { 336, 1, 2933000.0m, 14, 4190000m, 7, "Active", 21 },
                    { 337, 4, 2933000.0m, 14, 4190000m, 8, "Active", 12 },
                    { 338, 8, 2933000.0m, 14, 4190000m, 8, "Active", 10 },
                    { 339, 1, 2933000.0m, 14, 4190000m, 8, "Active", 18 },
                    { 340, 4, 2933000.0m, 14, 4190000m, 9, "Active", 10 },
                    { 341, 8, 2933000.0m, 14, 4190000m, 9, "Active", 63 },
                    { 342, 1, 2933000.0m, 14, 4190000m, 9, "Active", 85 },
                    { 343, 4, 2933000.0m, 14, 4190000m, 10, "Active", 22 },
                    { 344, 8, 2933000.0m, 14, 4190000m, 10, "Active", 43 },
                    { 345, 1, 2933000.0m, 14, 4190000m, 10, "Active", 63 },
                    { 346, 2, 1813000.0m, 15, 2590000m, 1, "Active", 45 },
                    { 347, 8, 1813000.0m, 15, 2590000m, 1, "Active", 22 },
                    { 348, 7, 1813000.0m, 15, 2590000m, 1, "Active", 33 },
                    { 349, 2, 1813000.0m, 15, 2590000m, 2, "Active", 94 },
                    { 350, 8, 1813000.0m, 15, 2590000m, 2, "Active", 26 },
                    { 351, 7, 1813000.0m, 15, 2590000m, 2, "Active", 54 },
                    { 352, 2, 1813000.0m, 15, 2590000m, 3, "Active", 97 },
                    { 353, 8, 1813000.0m, 15, 2590000m, 3, "Active", 28 },
                    { 354, 7, 1813000.0m, 15, 2590000m, 3, "Active", 36 },
                    { 355, 2, 1813000.0m, 15, 2590000m, 4, "Active", 31 },
                    { 356, 8, 1813000.0m, 15, 2590000m, 4, "Active", 46 },
                    { 357, 7, 1813000.0m, 15, 2590000m, 4, "Active", 67 },
                    { 358, 2, 1813000.0m, 15, 2590000m, 5, "Active", 51 },
                    { 359, 8, 1813000.0m, 15, 2590000m, 5, "Active", 33 },
                    { 360, 7, 1813000.0m, 15, 2590000m, 5, "Active", 97 },
                    { 361, 2, 1813000.0m, 15, 2590000m, 6, "Active", 75 },
                    { 362, 8, 1813000.0m, 15, 2590000m, 6, "Active", 87 },
                    { 363, 7, 1813000.0m, 15, 2590000m, 6, "Active", 37 },
                    { 364, 2, 1813000.0m, 15, 2590000m, 7, "Active", 40 },
                    { 365, 8, 1813000.0m, 15, 2590000m, 7, "Active", 18 },
                    { 366, 7, 1813000.0m, 15, 2590000m, 7, "Active", 52 },
                    { 367, 2, 1813000.0m, 15, 2590000m, 8, "Active", 78 },
                    { 368, 8, 1813000.0m, 15, 2590000m, 8, "Active", 68 },
                    { 369, 7, 1813000.0m, 15, 2590000m, 8, "Active", 89 },
                    { 370, 2, 1813000.0m, 15, 2590000m, 9, "Active", 45 },
                    { 371, 8, 1813000.0m, 15, 2590000m, 9, "Active", 60 },
                    { 372, 7, 1813000.0m, 15, 2590000m, 9, "Active", 14 },
                    { 373, 4, 1253000.0m, 16, 1790000m, 1, "Active", 26 },
                    { 374, 3, 1253000.0m, 16, 1790000m, 1, "Active", 75 },
                    { 375, 1, 1253000.0m, 16, 1790000m, 1, "Active", 73 },
                    { 376, 4, 1253000.0m, 16, 1790000m, 2, "Active", 35 },
                    { 377, 3, 1253000.0m, 16, 1790000m, 2, "Active", 97 },
                    { 378, 1, 1253000.0m, 16, 1790000m, 2, "Active", 52 },
                    { 379, 4, 1253000.0m, 16, 1790000m, 3, "Active", 43 },
                    { 380, 3, 1253000.0m, 16, 1790000m, 3, "Active", 28 },
                    { 381, 1, 1253000.0m, 16, 1790000m, 3, "Active", 74 },
                    { 382, 4, 1253000.0m, 16, 1790000m, 4, "Active", 42 },
                    { 383, 3, 1253000.0m, 16, 1790000m, 4, "Active", 44 },
                    { 384, 1, 1253000.0m, 16, 1790000m, 4, "Active", 50 },
                    { 385, 4, 1253000.0m, 16, 1790000m, 5, "Active", 42 },
                    { 386, 3, 1253000.0m, 16, 1790000m, 5, "Active", 48 },
                    { 387, 1, 1253000.0m, 16, 1790000m, 5, "Active", 80 },
                    { 388, 4, 1253000.0m, 16, 1790000m, 6, "Active", 12 },
                    { 389, 3, 1253000.0m, 16, 1790000m, 6, "Active", 79 },
                    { 390, 1, 1253000.0m, 16, 1790000m, 6, "Active", 32 },
                    { 391, 4, 1253000.0m, 16, 1790000m, 7, "Active", 13 },
                    { 392, 3, 1253000.0m, 16, 1790000m, 7, "Active", 98 },
                    { 393, 1, 1253000.0m, 16, 1790000m, 7, "Active", 11 },
                    { 394, 4, 1253000.0m, 16, 1790000m, 8, "Active", 71 },
                    { 395, 3, 1253000.0m, 16, 1790000m, 8, "Active", 58 },
                    { 396, 1, 1253000.0m, 16, 1790000m, 8, "Active", 24 },
                    { 397, 4, 1253000.0m, 16, 1790000m, 9, "Active", 96 },
                    { 398, 3, 1253000.0m, 16, 1790000m, 9, "Active", 86 },
                    { 399, 1, 1253000.0m, 16, 1790000m, 9, "Active", 59 },
                    { 400, 1, 2303000.0m, 17, 3290000m, 4, "Active", 73 },
                    { 401, 2, 2303000.0m, 17, 3290000m, 4, "Active", 35 },
                    { 402, 3, 2303000.0m, 17, 3290000m, 4, "Active", 32 },
                    { 403, 1, 2303000.0m, 17, 3290000m, 5, "Active", 75 },
                    { 404, 2, 2303000.0m, 17, 3290000m, 5, "Active", 38 },
                    { 405, 3, 2303000.0m, 17, 3290000m, 5, "Active", 41 },
                    { 406, 1, 2303000.0m, 17, 3290000m, 6, "Active", 40 },
                    { 407, 2, 2303000.0m, 17, 3290000m, 6, "Active", 61 },
                    { 408, 3, 2303000.0m, 17, 3290000m, 6, "Active", 83 },
                    { 409, 1, 2303000.0m, 17, 3290000m, 7, "Active", 42 },
                    { 410, 2, 2303000.0m, 17, 3290000m, 7, "Active", 54 },
                    { 411, 3, 2303000.0m, 17, 3290000m, 7, "Active", 37 },
                    { 412, 1, 2303000.0m, 17, 3290000m, 8, "Active", 16 },
                    { 413, 2, 2303000.0m, 17, 3290000m, 8, "Active", 97 },
                    { 414, 3, 2303000.0m, 17, 3290000m, 8, "Active", 88 },
                    { 415, 1, 2303000.0m, 17, 3290000m, 9, "Active", 81 },
                    { 416, 2, 2303000.0m, 17, 3290000m, 9, "Active", 69 },
                    { 417, 3, 2303000.0m, 17, 3290000m, 9, "Active", 30 },
                    { 418, 1, 2303000.0m, 17, 3290000m, 10, "Active", 34 },
                    { 419, 2, 2303000.0m, 17, 3290000m, 10, "Active", 87 },
                    { 420, 3, 2303000.0m, 17, 3290000m, 10, "Active", 99 },
                    { 421, 2, 3423000.0m, 18, 4890000m, 4, "Active", 90 },
                    { 422, 1, 3423000.0m, 18, 4890000m, 4, "Active", 95 },
                    { 423, 3, 3423000.0m, 18, 4890000m, 4, "Active", 58 },
                    { 424, 2, 3423000.0m, 18, 4890000m, 5, "Active", 76 },
                    { 425, 1, 3423000.0m, 18, 4890000m, 5, "Active", 60 },
                    { 426, 3, 3423000.0m, 18, 4890000m, 5, "Active", 68 },
                    { 427, 2, 3423000.0m, 18, 4890000m, 6, "Active", 49 },
                    { 428, 1, 3423000.0m, 18, 4890000m, 6, "Active", 28 },
                    { 429, 3, 3423000.0m, 18, 4890000m, 6, "Active", 88 },
                    { 430, 2, 3423000.0m, 18, 4890000m, 7, "Active", 82 },
                    { 431, 1, 3423000.0m, 18, 4890000m, 7, "Active", 73 },
                    { 432, 3, 3423000.0m, 18, 4890000m, 7, "Active", 26 },
                    { 433, 2, 3423000.0m, 18, 4890000m, 8, "Active", 29 },
                    { 434, 1, 3423000.0m, 18, 4890000m, 8, "Active", 72 },
                    { 435, 3, 3423000.0m, 18, 4890000m, 8, "Active", 36 },
                    { 436, 2, 3423000.0m, 18, 4890000m, 9, "Active", 44 },
                    { 437, 1, 3423000.0m, 18, 4890000m, 9, "Active", 15 },
                    { 438, 3, 3423000.0m, 18, 4890000m, 9, "Active", 51 },
                    { 439, 2, 3423000.0m, 18, 4890000m, 10, "Active", 80 },
                    { 440, 1, 3423000.0m, 18, 4890000m, 10, "Active", 15 },
                    { 441, 3, 3423000.0m, 18, 4890000m, 10, "Active", 28 },
                    { 442, 2, 1393000.0m, 19, 1990000m, 1, "Active", 51 },
                    { 443, 1, 1393000.0m, 19, 1990000m, 1, "Active", 59 },
                    { 444, 5, 1393000.0m, 19, 1990000m, 1, "Active", 60 },
                    { 445, 2, 1393000.0m, 19, 1990000m, 2, "Active", 12 },
                    { 446, 1, 1393000.0m, 19, 1990000m, 2, "Active", 61 },
                    { 447, 5, 1393000.0m, 19, 1990000m, 2, "Active", 38 },
                    { 448, 2, 1393000.0m, 19, 1990000m, 3, "Active", 34 },
                    { 449, 1, 1393000.0m, 19, 1990000m, 3, "Active", 49 },
                    { 450, 5, 1393000.0m, 19, 1990000m, 3, "Active", 42 },
                    { 451, 2, 1393000.0m, 19, 1990000m, 4, "Active", 78 },
                    { 452, 1, 1393000.0m, 19, 1990000m, 4, "Active", 93 },
                    { 453, 5, 1393000.0m, 19, 1990000m, 4, "Active", 46 },
                    { 454, 2, 1393000.0m, 19, 1990000m, 5, "Active", 62 },
                    { 455, 1, 1393000.0m, 19, 1990000m, 5, "Active", 40 },
                    { 456, 5, 1393000.0m, 19, 1990000m, 5, "Active", 62 },
                    { 457, 2, 1393000.0m, 19, 1990000m, 6, "Active", 64 },
                    { 458, 1, 1393000.0m, 19, 1990000m, 6, "Active", 32 },
                    { 459, 5, 1393000.0m, 19, 1990000m, 6, "Active", 33 },
                    { 460, 2, 1393000.0m, 19, 1990000m, 7, "Active", 14 },
                    { 461, 1, 1393000.0m, 19, 1990000m, 7, "Active", 79 },
                    { 462, 5, 1393000.0m, 19, 1990000m, 7, "Active", 54 },
                    { 463, 2, 1393000.0m, 19, 1990000m, 8, "Active", 50 },
                    { 464, 1, 1393000.0m, 19, 1990000m, 8, "Active", 20 },
                    { 465, 5, 1393000.0m, 19, 1990000m, 8, "Active", 68 },
                    { 466, 2, 1393000.0m, 19, 1990000m, 9, "Active", 30 },
                    { 467, 1, 1393000.0m, 19, 1990000m, 9, "Active", 64 },
                    { 468, 5, 1393000.0m, 19, 1990000m, 9, "Active", 77 },
                    { 469, 1, 1673000.0m, 20, 2390000m, 1, "Active", 75 },
                    { 470, 2, 1673000.0m, 20, 2390000m, 1, "Active", 54 },
                    { 471, 1, 1673000.0m, 20, 2390000m, 2, "Active", 45 },
                    { 472, 2, 1673000.0m, 20, 2390000m, 2, "Active", 12 },
                    { 473, 1, 1673000.0m, 20, 2390000m, 3, "Active", 76 },
                    { 474, 2, 1673000.0m, 20, 2390000m, 3, "Active", 71 },
                    { 475, 1, 1673000.0m, 20, 2390000m, 4, "Active", 97 },
                    { 476, 2, 1673000.0m, 20, 2390000m, 4, "Active", 17 },
                    { 477, 1, 1673000.0m, 20, 2390000m, 5, "Active", 55 },
                    { 478, 2, 1673000.0m, 20, 2390000m, 5, "Active", 78 },
                    { 479, 1, 1673000.0m, 20, 2390000m, 6, "Active", 53 },
                    { 480, 2, 1673000.0m, 20, 2390000m, 6, "Active", 67 },
                    { 481, 1, 1673000.0m, 20, 2390000m, 7, "Active", 40 },
                    { 482, 2, 1673000.0m, 20, 2390000m, 7, "Active", 84 },
                    { 483, 1, 1673000.0m, 20, 2390000m, 8, "Active", 35 },
                    { 484, 2, 1673000.0m, 20, 2390000m, 8, "Active", 58 },
                    { 485, 1, 1673000.0m, 20, 2390000m, 9, "Active", 21 },
                    { 486, 2, 1673000.0m, 20, 2390000m, 9, "Active", 87 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 31, 11, 37, 13, 43, DateTimeKind.Local).AddTicks(2738), "cFUde_iwTxlhE807QVi6D96AeXbrHn0DwClgecJs7HA" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 31, 11, 37, 13, 43, DateTimeKind.Local).AddTicks(2805), "p_01T6zOpZ8duVVrbojSEl-E6xZtVBO09kXqLH5usnk" });
        }
    }
}
