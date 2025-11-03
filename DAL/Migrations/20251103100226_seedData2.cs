using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Colors_ColorID",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductID",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ColorID",
                table: "ProductImages",
                newName: "IX_ProductImages_ColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "ImageID");

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageID", "ColorID", "CreatedAt", "Description", "DisplayOrder", "ImageType", "ImageUrl", "IsActive", "IsDefault", "ProductID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6052), null, 1, "Main", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, true, 1 },
                    { 2, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6055), null, 2, "Side", "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", true, false, 1 },
                    { 3, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6057), null, 3, "Detail", "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", true, false, 1 },
                    { 4, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6058), null, 1, "Main", "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", true, false, 1 },
                    { 5, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6060), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 1 },
                    { 6, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6061), null, 3, "Detail", "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop", true, false, 1 },
                    { 7, 3, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6062), null, 1, "Main", "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop", true, false, 1 },
                    { 8, 3, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6063), null, 2, "Side", "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", true, false, 1 },
                    { 9, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6069), null, 1, "Main", "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", true, true, 2 },
                    { 10, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6070), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 2 },
                    { 11, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6072), null, 3, "Detail", "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500&h=500&fit=crop", true, false, 2 },
                    { 12, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6073), null, 4, "Back", "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", true, false, 2 },
                    { 13, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6074), null, 1, "Main", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 2 },
                    { 14, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6122), null, 2, "Side", "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", true, false, 2 },
                    { 15, 10, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6123), null, 1, "Main", "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=500&h=500&fit=crop", true, false, 2 },
                    { 16, 10, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6125), null, 2, "Side", "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", true, false, 2 },
                    { 17, 4, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6128), null, 1, "Main", "https://images.unsplash.com/photo-1607522370275-f14206abe5d3?w=500&h=500&fit=crop", true, true, 3 },
                    { 18, 4, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6130), null, 2, "Side", "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", true, false, 3 },
                    { 19, 4, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6131), null, 3, "Detail", "https://images.unsplash.com/photo-1520256862855-398228c41684?w=500&h=500&fit=crop", true, false, 3 },
                    { 20, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6132), null, 1, "Main", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 3 },
                    { 21, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6133), null, 2, "Side", "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", true, false, 3 },
                    { 22, 5, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6135), null, 1, "Main", "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop", true, false, 3 },
                    { 23, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6137), null, 1, "Main", "https://images.unsplash.com/photo-1551107696-a4b0c5a0d9a2?w=500&h=500&fit=crop", true, true, 4 },
                    { 24, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6138), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 4 },
                    { 25, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6140), null, 1, "Main", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 4 },
                    { 26, 4, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6141), null, 1, "Main", "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", true, false, 4 },
                    { 27, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6143), null, 1, "Main", "https://images.unsplash.com/photo-1586525198428-225f6f12cff5?w=500&h=500&fit=crop", true, true, 5 },
                    { 28, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6144), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 5 },
                    { 29, 5, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6145), null, 1, "Main", "https://images.unsplash.com/photo-1608231387042-66d1773070a5?w=500&h=500&fit=crop", true, false, 5 },
                    { 30, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6146), null, 1, "Main", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 5 },
                    { 31, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6148), null, 1, "Main", "https://images.unsplash.com/photo-1597045566677-8cf032ed6634?w=500&h=500&fit=crop", true, true, 7 },
                    { 32, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6149), null, 2, "Side", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 7 },
                    { 33, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6150), null, 1, "Main", "https://images.unsplash.com/photo-1603808033192-082d6919d3e1?w=500&h=500&fit=crop", true, false, 7 },
                    { 34, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6151), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 7 },
                    { 35, 3, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6152), null, 1, "Main", "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", true, false, 7 },
                    { 36, 4, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6153), null, 1, "Main", "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=500&h=500&fit=crop", true, false, 7 },
                    { 37, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6156), null, 1, "Main", "https://images.unsplash.com/photo-1556906781-9a412961c28c?w=500&h=500&fit=crop", true, true, 17 },
                    { 38, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6157), null, 2, "Side", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 17 },
                    { 39, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6158), null, 1, "Main", "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", true, false, 17 },
                    { 40, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6160), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 17 },
                    { 41, 3, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6161), null, 1, "Main", "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=500&h=500&fit=crop", true, false, 17 },
                    { 42, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6162), null, 1, "Main", "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500&h=500&fit=crop", true, true, 20 },
                    { 43, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6164), null, 2, "Side", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=500&fit=crop", true, false, 20 },
                    { 44, 1, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6165), null, 3, "Detail", "https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&h=500&fit=crop", true, false, 20 },
                    { 45, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6166), null, 1, "Main", "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?w=500&h=500&fit=crop", true, false, 20 },
                    { 46, 2, new DateTime(2025, 11, 3, 10, 2, 25, 198, DateTimeKind.Utc).AddTicks(6167), null, 2, "Side", "https://images.unsplash.com/photo-1460353581641-37baddab0fa2?w=500&h=500&fit=crop", true, false, 20 }
                });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 1,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 36,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 110,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 132,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 137,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 142,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 149,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 154,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 181,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 195,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 199,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 222,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 266,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 297,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 359,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 383,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 399,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 404,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 422,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 423,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 453,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 16, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 19, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 5, 2, 25, 198, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 11, 2, 25, 198, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 14, 2, 25, 198, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 16, 2, 25, 198, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 16, 32, 25, 198, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 16, 47, 25, 198, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 3, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4598), "MM2U-omThp8T2VzMUMtUrlHPmOau3bKmsB8vMbe1h2g" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 3, 17, 2, 25, 198, DateTimeKind.Local).AddTicks(4651), "nxyeUbTFGSKne30794DtCKn63-VoDdJC4PPdO7kLWrQ" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Colors_ColorID",
                table: "ProductImages",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Colors_ColorID",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 46);

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ColorID",
                table: "ProductImage",
                newName: "IX_ProductImage_ColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ImageID");

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 1,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 36,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 110,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 132,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 137,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 142,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 149,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 154,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 181,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 195,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 199,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 222,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 266,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 297,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 359,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 383,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 399,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 404,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 422,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 423,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 453,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 16, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 19, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 3, 16, 42, 804, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 9, 16, 42, 804, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 12, 16, 42, 804, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 14, 16, 42, 804, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 14, 46, 42, 804, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 15, 1, 42, 804, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 3, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(3685), "vfvIdrUT7GLnaqpdcNXQNv_Qjmg0PriJ-2jtRfo8vyo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 3, 15, 16, 42, 804, DateTimeKind.Local).AddTicks(3764), "01dehGHqFS7OMSdOGA47rmq4ETuekCO0uErIURt8QRM" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Colors_ColorID",
                table: "ProductImage",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductID",
                table: "ProductImage",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
