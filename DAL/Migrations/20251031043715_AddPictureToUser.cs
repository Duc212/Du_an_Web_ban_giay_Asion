using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Picture" },
                values: new object[] { new DateTime(2025, 10, 31, 11, 37, 13, 43, DateTimeKind.Local).AddTicks(2738), "cFUde_iwTxlhE807QVi6D96AeXbrHn0DwClgecJs7HA", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "Picture" },
                values: new object[] { new DateTime(2025, 10, 31, 11, 37, 13, 43, DateTimeKind.Local).AddTicks(2805), "p_01T6zOpZ8duVVrbojSEl-E6xZtVBO09kXqLH5usnk", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 29, 0, 23, 21, 826, DateTimeKind.Local).AddTicks(163), "YIqHLmGMgGx-OLaxoTFNi_Q5xf-4SItXIhojRyZwZWw" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 10, 29, 0, 23, 21, 827, DateTimeKind.Local).AddTicks(4679), "96LmdrsXo9uyhaMgJglFF834xnVoLsr6yt0s1xuu_00" });
        }
    }
}
