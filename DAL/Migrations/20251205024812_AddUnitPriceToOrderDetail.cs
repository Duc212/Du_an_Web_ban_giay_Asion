using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceToOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 3,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 4,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 2, 48, 11, 650, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 1,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 21,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 26);

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
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 46,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61,
                column: "StockQuantity",
                value: 12);

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
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 110,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 128,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 132,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 137,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 69);

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
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 149,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 181,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 195,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 199,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 225,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 86);

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
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 285,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 76);

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
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 355,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 361,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 378,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 383,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 404,
                column: "StockQuantity",
                value: 62);

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
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 30);

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
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 67);

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
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 425,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 5, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 17, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 23, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 27, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 1, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 2, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 3, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 48, 11, 650, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 3, 48, 11, 650, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 6, 48, 11, 650, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 8, 48, 11, 650, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 9, 18, 11, 650, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 9, 33, 11, 650, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 12, 5, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(927), "rw5g2P-KRDFYUWPVT0VgvaVL4msRjANYsHs78jb7Jck" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 12, 5, 9, 48, 11, 650, DateTimeKind.Local).AddTicks(996), "oucrdt1r0mSOVqt6FQ64taP_zyP2E3_eDzRZWcPmeJw" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 3,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 4,
                column: "PaymentDate",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 2, 30, 47, 142, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 1,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 30);

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
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 21,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 46,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 33);

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
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 98);

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
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 110,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 128,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 132,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 137,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 142,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 149,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 80);

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
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 181,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 16);

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
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 195,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 199,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 82);

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
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 47);

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
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 225,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 285,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 355,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 361,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 378,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382,
                column: "StockQuantity",
                value: 23);

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
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 404,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 422,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 423,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 425,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 4, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 14, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 28, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 1, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 2, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 3, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 3, 21, 30, 47, 142, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 3, 30, 47, 142, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 6, 30, 47, 142, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 8, 30, 47, 142, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 0, 47, 142, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 15, 47, 142, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3332), "82Bnh-osOnwbMkdAC1_DSMmoOOw2yhOPBfAGf_fn7xQ" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 30, 47, 142, DateTimeKind.Local).AddTicks(3447), "97iLY8-h4I-1sNSJxrWKP8OqHKTBUbMmA5Z7y49ZS0A" });
        }
    }
}
