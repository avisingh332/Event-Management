using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event_Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seededuserandroledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "Organizer", "ORGANIZER" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "Attendee", "ATTENDEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10b30d03-646a-4ce9-87e7-fa460260a2b1", 0, "f4eab2f7-5466-4719-85db-cc55a2895340", "attendee2@test.com", false, "Attendee 2", false, null, "ATTENDEE2@TEST.COM", "ATTENDEE2@TEST.COM", "AQAAAAIAAYagAAAAEOoD8VihTFMXrOz5QeISn92yBd0PE1B2z2w7TI80AmIWx2m8pc49GdRhYFsFdYJ/0Q==", null, false, "fb6087bf-7452-4e48-805f-97665c6b698a", false, "attendee2@test.com" },
                    { "4fa89d5e-79fe-435c-b38d-52a81ee2754e", 0, "46ac766e-a732-40ef-acaf-6d998fd458e9", "attendee1@test.com", false, "Attendee 1", false, null, "ATTENDEE1@TEST.COM", "ATTENDEE1@TEST.COM", "AQAAAAIAAYagAAAAEP9zF2nna08kLyTlT4M5POtdxFcpywLzKCtb3zEAR/2MPQavKxdy77EIl+KqwlZGcQ==", null, false, "00e555a7-d618-458b-a648-6db31135c51e", false, "attendee1@test.com" },
                    { "f71cd1fd-5fcc-4247-94dd-0137d7bbbc81", 0, "9bcb7b4e-538d-42f6-aa41-01a7d4046cdc", "organizer1@test.com", false, "Organizer 1", false, null, "ORGANIZER1@TEST.COM", "ORGANIZER1@TEST.COM", "AQAAAAIAAYagAAAAEPCfoPlrtcDnV9uc8NDkm+4S7E4PbkVPG5OJAGb30ZhsMqXEPCYu2l4Y6hBZokXW/Q==", null, false, "447f6848-3bb2-46f6-9d46-99b5d4bf4cdb", false, "organizer1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "10b30d03-646a-4ce9-87e7-fa460260a2b1" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "4fa89d5e-79fe-435c-b38d-52a81ee2754e" },
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "f71cd1fd-5fcc-4247-94dd-0137d7bbbc81" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "10b30d03-646a-4ce9-87e7-fa460260a2b1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "4fa89d5e-79fe-435c-b38d-52a81ee2754e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "f71cd1fd-5fcc-4247-94dd-0137d7bbbc81" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95cb1e1c-d8b6-45a2-b240-6d211c06fd00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10b30d03-646a-4ce9-87e7-fa460260a2b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa89d5e-79fe-435c-b38d-52a81ee2754e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f71cd1fd-5fcc-4247-94dd-0137d7bbbc81");
        }
    }
}
