using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseNoteColumnLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Orders",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 3,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 4,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 43, 32, 527, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 71);

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
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 21,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 26,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 27,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 36,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 46,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 75);

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
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 31);

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
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 99);

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
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 94);

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
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 73);

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
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 109,
                column: "StockQuantity",
                value: 52);

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
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 92);

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
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 121,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 122,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 128,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141,
                column: "StockQuantity",
                value: 81);

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
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 152,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 153,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 154,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 167,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 168,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 174,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 175,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 186,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 187,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 83);

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
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205,
                column: "StockQuantity",
                value: 22);

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
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 222,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 225,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 245,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 246,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 247,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 248,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 249,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 250,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 256,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 257,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 266,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 285,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 98);

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
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 295,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 296,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 297,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 16);

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
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 53);

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
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 77);

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
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 325,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 326,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 333,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 334,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 342,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 343,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 93);

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
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 355,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 359,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 361,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 376,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 377,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 378,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 76);

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
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 399,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 407,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 408,
                column: "StockQuantity",
                value: 40);

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
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 85);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 422,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 423,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 425,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 453,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 472,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 473,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 17, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 4, 43, 32, 527, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 10, 43, 32, 527, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 13, 43, 32, 527, DateTimeKind.Local).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 15, 43, 32, 527, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 13, 32, 527, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 28, 32, 527, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1614), "tlLY3QVEEanPGzZzju_HMW8wCrGGM3kv-nd5n_wU82c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 43, 32, 527, DateTimeKind.Local).AddTicks(1680), "vaPTc5MZXwYZq90rj7ynRWVJcCLJ0JgjB1-tyt8dBRM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 3,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 4,
                column: "PaymentDate",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ImageID",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 2, 46, 41, 491, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 2,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 3,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 4,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 5,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 6,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 7,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 8,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 9,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 10,
                column: "StockQuantity",
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 11,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 12,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 13,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 14,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 15,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 16,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 17,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 18,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 19,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 20,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 21,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 22,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 23,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 24,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 25,
                column: "StockQuantity",
                value: 12);

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
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 28,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 29,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 30,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 31,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 32,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 33,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 34,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 35,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 36,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 37,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 38,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 39,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 40,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 41,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 42,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 43,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 44,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 45,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 46,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 47,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 48,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 49,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 50,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 51,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 52,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 53,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 54,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 55,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 56,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 57,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 58,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 59,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 60,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 61,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 62,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 63,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 64,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 65,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 66,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 67,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 68,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 69,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 70,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 71,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 72,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 73,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 74,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 75,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 76,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 77,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 78,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 79,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 80,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 81,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 82,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 83,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 84,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 85,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 86,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 87,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 88,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 89,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 90,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 91,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 92,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 93,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 94,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 95,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 96,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 97,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 98,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 99,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 100,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 101,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 102,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 103,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 104,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 105,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 106,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 107,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 108,
                column: "StockQuantity",
                value: 88);

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
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 111,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 112,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 113,
                column: "StockQuantity",
                value: 29);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 114,
                column: "StockQuantity",
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 115,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 116,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 117,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 118,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 119,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 120,
                column: "StockQuantity",
                value: 90);

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
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 123,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 124,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 125,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 126,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 127,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 128,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 129,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 130,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 131,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 133,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 134,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 135,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 136,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 138,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 139,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 140,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 141,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 142,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 143,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 144,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 145,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 146,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 147,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 148,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 150,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 151,
                column: "StockQuantity",
                value: 37);

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
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 154,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 155,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 156,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 157,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 158,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 159,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 160,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 161,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 162,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 163,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 164,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 165,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 166,
                column: "StockQuantity",
                value: 39);

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
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 169,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 170,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 171,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 172,
                column: "StockQuantity",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 173,
                column: "StockQuantity",
                value: 56);

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
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 176,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 177,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 178,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 179,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 180,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 182,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 183,
                column: "StockQuantity",
                value: 86);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 184,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 185,
                column: "StockQuantity",
                value: 38);

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
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 188,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 189,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 190,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 191,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 192,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 193,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 194,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 196,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 197,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 198,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 200,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 201,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 202,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 203,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 204,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 205,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 206,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 207,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 208,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 209,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 210,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 211,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 212,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 213,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 214,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 215,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 216,
                column: "StockQuantity",
                value: 96);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 217,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 218,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 219,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 220,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 221,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 222,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 223,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 224,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 225,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 226,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 227,
                column: "StockQuantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 228,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 229,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 230,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 231,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 232,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 233,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 234,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 235,
                column: "StockQuantity",
                value: 72);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 236,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 237,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 238,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 239,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 240,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 241,
                column: "StockQuantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 242,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 243,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 244,
                column: "StockQuantity",
                value: 81);

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
                value: 75);

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
                value: 65);

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
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 251,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 252,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 253,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 254,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 255,
                column: "StockQuantity",
                value: 24);

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
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 258,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 259,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 260,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 261,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 262,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 263,
                column: "StockQuantity",
                value: 47);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 264,
                column: "StockQuantity",
                value: 41);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 265,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 266,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 267,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 268,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 269,
                column: "StockQuantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 270,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 271,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 272,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 273,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 274,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 275,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 276,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 277,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 278,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 279,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 280,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 281,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 282,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 283,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 284,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 285,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 286,
                column: "StockQuantity",
                value: 53);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 287,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 288,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 289,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 290,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 291,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 292,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 293,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 294,
                column: "StockQuantity",
                value: 27);

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
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 297,
                column: "StockQuantity",
                value: 44);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 298,
                column: "StockQuantity",
                value: 67);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 299,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 300,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 301,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 302,
                column: "StockQuantity",
                value: 83);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 303,
                column: "StockQuantity",
                value: 31);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 304,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 305,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 306,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 307,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 308,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 309,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 310,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 311,
                column: "StockQuantity",
                value: 79);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 312,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 313,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 314,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 315,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 316,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 317,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 318,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 319,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 320,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 321,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 322,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 323,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 324,
                column: "StockQuantity",
                value: 46);

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
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 327,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 328,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 329,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 330,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 331,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 332,
                column: "StockQuantity",
                value: 48);

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
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 335,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 336,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 337,
                column: "StockQuantity",
                value: 55);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 338,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 339,
                column: "StockQuantity",
                value: 38);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 340,
                column: "StockQuantity",
                value: 74);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 341,
                column: "StockQuantity",
                value: 26);

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
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 344,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 345,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 346,
                column: "StockQuantity",
                value: 70);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 347,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 348,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 349,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 350,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 351,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 352,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 353,
                column: "StockQuantity",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 354,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 355,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 356,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 357,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 358,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 359,
                column: "StockQuantity",
                value: 82);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 360,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 361,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 362,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 363,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 364,
                column: "StockQuantity",
                value: 43);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 365,
                column: "StockQuantity",
                value: 69);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 366,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 367,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 368,
                column: "StockQuantity",
                value: 64);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 369,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 370,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 371,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 372,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 373,
                column: "StockQuantity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 374,
                column: "StockQuantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 375,
                column: "StockQuantity",
                value: 63);

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
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 378,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 379,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 380,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 381,
                column: "StockQuantity",
                value: 57);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 382,
                column: "StockQuantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 383,
                column: "StockQuantity",
                value: 27);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 384,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 385,
                column: "StockQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 386,
                column: "StockQuantity",
                value: 61);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 387,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 388,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 389,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 390,
                column: "StockQuantity",
                value: 49);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 391,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 392,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 393,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 394,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 395,
                column: "StockQuantity",
                value: 88);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 396,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 397,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 398,
                column: "StockQuantity",
                value: 58);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 399,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 400,
                column: "StockQuantity",
                value: 71);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 401,
                column: "StockQuantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 402,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 403,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 405,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 406,
                column: "StockQuantity",
                value: 86);

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
                value: 66);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 409,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 410,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 411,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 412,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 413,
                column: "StockQuantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 414,
                column: "StockQuantity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 415,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 416,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 417,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 418,
                column: "StockQuantity",
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 419,
                column: "StockQuantity",
                value: 89);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 420,
                column: "StockQuantity",
                value: 77);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 421,
                column: "StockQuantity",
                value: 20);

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
                value: 52);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 424,
                column: "StockQuantity",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 425,
                column: "StockQuantity",
                value: 76);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 426,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 427,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 428,
                column: "StockQuantity",
                value: 62);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 429,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 430,
                column: "StockQuantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 431,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 432,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 433,
                column: "StockQuantity",
                value: 32);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 434,
                column: "StockQuantity",
                value: 51);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 435,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 436,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 437,
                column: "StockQuantity",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 438,
                column: "StockQuantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 439,
                column: "StockQuantity",
                value: 81);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 440,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 441,
                column: "StockQuantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 442,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 443,
                column: "StockQuantity",
                value: 94);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 444,
                column: "StockQuantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 445,
                column: "StockQuantity",
                value: 39);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 446,
                column: "StockQuantity",
                value: 68);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 447,
                column: "StockQuantity",
                value: 54);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 448,
                column: "StockQuantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 449,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 450,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 451,
                column: "StockQuantity",
                value: 28);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 452,
                column: "StockQuantity",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 453,
                column: "StockQuantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 454,
                column: "StockQuantity",
                value: 73);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 455,
                column: "StockQuantity",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 456,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 457,
                column: "StockQuantity",
                value: 37);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 458,
                column: "StockQuantity",
                value: 56);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 459,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 460,
                column: "StockQuantity",
                value: 98);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 461,
                column: "StockQuantity",
                value: 46);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 462,
                column: "StockQuantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 463,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 464,
                column: "StockQuantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 465,
                column: "StockQuantity",
                value: 87);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 466,
                column: "StockQuantity",
                value: 21);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 467,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 468,
                column: "StockQuantity",
                value: 97);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 469,
                column: "StockQuantity",
                value: 42);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 470,
                column: "StockQuantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 471,
                column: "StockQuantity",
                value: 62);

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
                value: 59);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 474,
                column: "StockQuantity",
                value: 84);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 475,
                column: "StockQuantity",
                value: 26);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 476,
                column: "StockQuantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 477,
                column: "StockQuantity",
                value: 78);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 478,
                column: "StockQuantity",
                value: 93);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 479,
                column: "StockQuantity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 480,
                column: "StockQuantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 481,
                column: "StockQuantity",
                value: 65);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 482,
                column: "StockQuantity",
                value: 33);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 483,
                column: "StockQuantity",
                value: 92);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 484,
                column: "StockQuantity",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 485,
                column: "StockQuantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantID",
                keyValue: 486,
                column: "StockQuantity",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 17, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 21, 46, 41, 491, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 3, 46, 41, 491, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 6, 46, 41, 491, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 8, 46, 41, 491, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 16, 41, 491, DateTimeKind.Local).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 9, 31, 41, 491, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 21, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(7596), "4g-U8jvbNjePrw-AbgWARksdDoO0C193zR0rokNicZQ" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 11, 21, 9, 46, 41, 491, DateTimeKind.Local).AddTicks(7674), "17ImiE4qI7kAL355tEFuyfEipAYlcpC0AQ3PW3sdegM" });
        }
    }
}
