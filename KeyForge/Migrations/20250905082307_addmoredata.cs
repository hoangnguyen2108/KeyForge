using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyForge.Migrations
{
    /// <inheritdoc />
    public partial class addmoredata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23587ca1-93fc-45e1-9af1-acefa3db1966");

            migrationBuilder.InsertData(
                table: "ApiKeyClasses",
                columns: new[] { "Id", "CreateAt", "ExpiresAt", "IsActive", "IsTrial", "Key", "UserId" },
                values: new object[] { 3, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, true, "TEST - KEY - WITHUSERAdmin - 1234567890", "a4245943-934d-46eb-b3fa-123933f1f2bb" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82dffdd1-27de-44d0-a8e2-f343ec418d89", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4245943-934d-46eb-b3fa-123933f1f2bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc3902d5-5434-41ef-ad6f-fff6d29b160d", "AQAAAAIAAYagAAAAEJJofcz8OxXfzaZPYH3mZRWVfl6R1nSkKsXyyrgxPaE8uyO1hyYRtieYuLQcafwr9A==", "34e509fa-fb8a-437f-8db4-d1315b52c630" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ecd01b95-943e-46be-9d56-9bc89b668f58", 0, "c2fe40ea-eccd-4906-acf1-4a5059496636", "user2normal@gmail.com", true, "User", "Normal", false, null, "USER2NORMAL@GMAIL.COM", "USER2NORMAL@GMAIL.COM", "AQAAAAIAAYagAAAAEARz8wpSR8kpKmgaQb6DoTJDV+5xTDZ1hvRdhb4+6rjIVHfz07vcK7uWD6fqynKRfg==", null, false, "4e9af31b-ec5a-4490-bc08-20f1f30ca362", false, "user2normal@gmail.com" });

            migrationBuilder.InsertData(
                table: "ApiKeyClasses",
                columns: new[] { "Id", "CreateAt", "ExpiresAt", "IsActive", "IsTrial", "Key", "UserId" },
                values: new object[] { 4, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, true, "TEST - KEY - WITHUSERnormaluser - 1234567899", "ecd01b95-943e-46be-9d56-9bc89b668f58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApiKeyClasses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82dffdd1-27de-44d0-a8e2-f343ec418d89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecd01b95-943e-46be-9d56-9bc89b668f58");

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
        }
    }
}
