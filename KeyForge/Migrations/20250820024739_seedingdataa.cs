using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyForge.Migrations
{
    /// <inheritdoc />
    public partial class seedingdataa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 8, 20, 9, 47, 38, 885, DateTimeKind.Local).AddTicks(6993), new DateTime(2025, 9, 19, 2, 47, 38, 885, DateTimeKind.Utc).AddTicks(7005) });

            migrationBuilder.InsertData(
                table: "ApiKeyClasses",
                columns: new[] { "Id", "CreateAt", "ExpiresAt", "IsActive", "Key" },
                values: new object[] { 2, new DateTime(2025, 8, 20, 9, 47, 38, 885, DateTimeKind.Local).AddTicks(7015), new DateTime(2025, 9, 19, 2, 47, 38, 885, DateTimeKind.Utc).AddTicks(7016), false, "TEST - KEY - 1234567891" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 8, 20, 9, 38, 51, 140, DateTimeKind.Local).AddTicks(2799), new DateTime(2025, 9, 19, 2, 38, 51, 140, DateTimeKind.Utc).AddTicks(2829) });
        }
    }
}
