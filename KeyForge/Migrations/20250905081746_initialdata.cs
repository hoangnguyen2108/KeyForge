using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyForge.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd77f415-2502-4493-8d73-5577df42664a");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApiKeyClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), null });

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "ExpiresAt", "UserId" },
                values: new object[] { new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23587ca1-93fc-45e1-9af1-acefa3db1966", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4245943-934d-46eb-b3fa-123933f1f2bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2b9415f-dc70-472c-a2e0-18211036fec7", "AQAAAAIAAYagAAAAEHQ58Dy6ZQFUFfasiVB0oDWYA8f2E9JN9t77g9isGnpBrWtoPY2VKugCwS+cf1QEKA==", "c4b37a23-9435-4102-9703-4363b99849f3" });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyClasses_UserId",
                table: "ApiKeyClasses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiKeyClasses_AspNetUsers_UserId",
                table: "ApiKeyClasses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiKeyClasses_AspNetUsers_UserId",
                table: "ApiKeyClasses");

            migrationBuilder.DropIndex(
                name: "IX_ApiKeyClasses_UserId",
                table: "ApiKeyClasses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23587ca1-93fc-45e1-9af1-acefa3db1966");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApiKeyClasses");

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 9, 4, 17, 42, 59, 944, DateTimeKind.Local).AddTicks(1717), new DateTime(2025, 10, 4, 10, 42, 59, 944, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "ExpiresAt" },
                values: new object[] { new DateTime(2025, 9, 4, 17, 42, 59, 944, DateTimeKind.Local).AddTicks(1736), new DateTime(2025, 10, 4, 10, 42, 59, 944, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd77f415-2502-4493-8d73-5577df42664a", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4245943-934d-46eb-b3fa-123933f1f2bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cba86a4-4f6e-4fb0-9665-1aae0c5ecb69", "AQAAAAIAAYagAAAAEFqmT34mnP/utOht3qdVWFHRjvVQjJQTLFGmN9UzKB9X8aErS1wJoKuMTRIeFeynmg==", "38a1ba54-5cfd-40e0-8800-7b660582566a" });
        }
    }
}
