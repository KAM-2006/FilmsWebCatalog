using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsWebCatalog.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7bc1ef1-7a1b-4dbe-955f-5c213332a9e5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "291d856a-5bfb-4808-b50e-e580599e5c66", 0, "93032ce1-213e-47dc-99df-1d3db1093b34", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEMpeym8fjg4pqZ3fKi4L+3evVpyUvdn3gWWCNkYV5jxROYEokfX/zN0JD3W+9IN+wA==", null, false, "20a1b439-59fa-4804-acd7-3dd49001dd55", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82213299-1100-4aa3-967a-c3d058d6881c", 0, "e3d33a69-6923-42c3-a534-b2a08d07e8fa", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEL0Xyy2XMCkpKooJFm5I9JcWu88/iZbmoq4TejMrXlDwEWpu5lUgukv+RUdrH1i7YA==", null, false, "6faefc01-7755-4119-bd7e-6ad412cd3dbd", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserID",
                value: "82213299-1100-4aa3-967a-c3d058d6881c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "291d856a-5bfb-4808-b50e-e580599e5c66");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82213299-1100-4aa3-967a-c3d058d6881c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c", 0, "b7ac4f3a-aacf-4dcd-b422-3f10d09fef3a", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEDqnzpzbUSmf31rNwcVHSzLbulY9TowbieuHDTgAT5reNeBVTrWpdZ9cT3ZU0mryFA==", null, false, "22812f20-f1c3-4a9b-a29f-38b984680617", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7bc1ef1-7a1b-4dbe-955f-5c213332a9e5", 0, "5dad1bdf-83e1-4c09-920c-254798a0fc21", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAELz02dt7vwndmDKXum2VWfTdk/406tcm81efCofcAhsUIv4jM1//kYVmNA0dzxd9jg==", null, false, "69ba1ba7-0639-4b55-959b-94a2ebbb5b7b", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserID",
                value: "a4fa25b3-8bd2-4d5a-b121-e9b0af92877c");
        }
    }
}
