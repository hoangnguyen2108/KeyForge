using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyForge.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ApiKeyClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ApiKeyClasses",
                columns: new[] { "Id", "CreateAt", "ExpiresAt", "IsActive", "Key" },
                values: new object[] { 1, new DateTime(2025, 8, 20, 9, 38, 51, 140, DateTimeKind.Local).AddTicks(2799), new DateTime(2025, 9, 19, 2, 38, 51, 140, DateTimeKind.Utc).AddTicks(2829), true, "TEST - KEY - 1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Key",
                table: "ApiKeyClasses");
        }
    }
}
