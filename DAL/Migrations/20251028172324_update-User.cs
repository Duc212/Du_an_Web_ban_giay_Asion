using DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [Users] SET [Status] = 0 WHERE [Status] = 'Active'");
            migrationBuilder.Sql("UPDATE [Users] SET [Status] = 1 WHERE [Status] = 'Inactive'");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Status", "Username" },
                values: new object[] { new DateTime(2025, 10, 29, 0, 23, 21, 826, DateTimeKind.Local).AddTicks(163), "YIqHLmGMgGx-OLaxoTFNi_Q5xf-4SItXIhojRyZwZWw", 0, "Admin123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "Status" },
                values: new object[] { new DateTime(2025, 10, 29, 0, 23, 21, 827, DateTimeKind.Local).AddTicks(4679), "96LmdrsXo9uyhaMgJglFF834xnVoLsr6yt0s1xuu_00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Status", "Username" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 1, 58, 401, DateTimeKind.Local).AddTicks(257), "123", "Active", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "Status" },
                values: new object[] { new DateTime(2025, 10, 28, 10, 1, 58, 401, DateTimeKind.Local).AddTicks(270), "123", "Active" });
        }
    }
}
