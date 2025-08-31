using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyForge.Migrations
{
    /// <inheritdoc />
    public partial class addtrialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84427a3f-a277-4fa6-ad17-029c05771ae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b3441fe-0fea-4c25-bf8c-20ebfa45c97b");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrial",
                table: "ApiKeyClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt", "IsTrial" },
                values: new object[] { new DateTime(2025, 8, 31, 10, 59, 47, 561, DateTimeKind.Local).AddTicks(6052), new DateTime(2025, 9, 30, 3, 59, 47, 561, DateTimeKind.Utc).AddTicks(6069), true });

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "ExpiresAt", "IsTrial" },
                values: new object[] { new DateTime(2025, 8, 31, 10, 59, 47, 561, DateTimeKind.Local).AddTicks(6078), new DateTime(2025, 9, 30, 3, 59, 47, 561, DateTimeKind.Utc).AddTicks(6079), true });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ccc571d-ab5b-4926-a693-05b3b016438a", null, "Admin", "ADMIN" },
                    { "b842ece5-0e43-4d3f-ac90-1e275c1bf594", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ccc571d-ab5b-4926-a693-05b3b016438a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b842ece5-0e43-4d3f-ac90-1e275c1bf594");

            migrationBuilder.DropColumn(
                name: "IsTrial",
                table: "ApiKeyClasses");

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 8, 21, 17, 58, 41, 132, DateTimeKind.Local).AddTicks(4468), new DateTime(2025, 9, 20, 10, 58, 41, 132, DateTimeKind.Utc).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 8, 21, 17, 58, 41, 132, DateTimeKind.Local).AddTicks(4488), new DateTime(2025, 9, 20, 10, 58, 41, 132, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84427a3f-a277-4fa6-ad17-029c05771ae7", null, "Admin", "ADMIN" },
                    { "8b3441fe-0fea-4c25-bf8c-20ebfa45c97b", null, "User", "USER" }
                });
        }
    }
}
