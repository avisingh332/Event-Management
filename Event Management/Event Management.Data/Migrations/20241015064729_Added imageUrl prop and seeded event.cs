using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event_Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedimageUrlpropandseededevent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "0ab5c594-bd8a-424c-a68e-c1d9ff2d0e70" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "2f1c8bc0-2eb7-46cb-b09f-9db5ad32701e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "7b253f0b-aad2-49dc-836e-8188473a8b8c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ab5c594-bd8a-424c-a68e-c1d9ff2d0e70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f1c8bc0-2eb7-46cb-b09f-9db5ad32701e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b253f0b-aad2-49dc-836e-8188473a8b8c");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7", 0, "7b0e16d0-e72c-42ec-b13e-035e2e03ff99", "organizer1@test.com", false, "Organizer 1", false, null, "ORGANIZER1@TEST.COM", "ORGANIZER1@TEST.COM", "AQAAAAIAAYagAAAAED5mzdbksK1Y2ZdB53qs6ght5N0cPi/sYYmQIhmg/Ck2tRn3H/O5scSmRd0Smp2BhA==", null, false, "7ea8145c-5c63-451f-9cdf-19b41949fba4", false, "organizer1@test.com" },
                    { "4740bdf0-b417-4841-9ca2-68b97677df45", 0, "150e921e-2bf5-425f-9436-aba54bbf6107", "attendee1@test.com", false, "Attendee 1", false, null, "ATTENDEE1@TEST.COM", "ATTENDEE1@TEST.COM", "AQAAAAIAAYagAAAAEAyN7415CMI29A3w9ESwlsY9b7VPX7dEnW+A/snTcfgdTrPGsPaLgme0pCFZ59H3EQ==", null, false, "b2d00935-fa3b-479a-99c7-182887e36bea", false, "attendee1@test.com" },
                    { "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d", 0, "514277e8-bea4-4ba7-8adf-14cbfbfb2001", "attendee2@test.com", false, "Attendee 2", false, null, "ATTENDEE2@TEST.COM", "ATTENDEE2@TEST.COM", "AQAAAAIAAYagAAAAEKShNI7DsIYJikbZuYJjaA2DpdG/BUgyBMP18ilxpJUMMiPAm2oQ+nK3tRAzXwkFgA==", null, false, "e54becf7-36f8-4f08-9e82-d540090f9bdc", false, "attendee2@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "4740bdf0-b417-4841-9ca2-68b97677df45" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "DateTime", "Description", "ImageUrl", "Location", "Name", "OrganizerId" },
                values: new object[,]
                {
                    { new Guid("01d7e6f2-4cbc-4a53-8a90-97b72768e508"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "The sensational Punjabi superstar Guru Randhawa is hitting the road for an epic Indian Tour! \r\n\r\nBrace yourselves for electrifying performances, unforgettable moments, and a musical journey like never before. Gather your squad, and get ready to groove to the beats of your favorite hits!\r\n\r\n \r\n\r\nExpect nothing but the best as Guru brings his electrifying performances to each city, complete with exclusive setlists, surprise fan interactions, and unforgettable moments that only a global superstar can deliver. Whether it's belting out his biggest hits or connecting with fans in unexpected ways, Guru's tour is all about creating a once-in-a-lifetime experience.\r\n\r\n\r\n\r\n#GuruRandhawa #IndianTour #LiveConcert #MoonriseTour", "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAxMCBOb3Y%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411817-dfbcsfgdde-portrait.jpg", "Indira Gandhi Pratishtahn , Lucknow", "Guru Randhawa - Moon Rise Tour, Lucknow", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" },
                    { new Guid("094ebf32-b215-48a2-8231-72a70575306a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "This Sunday, let your voice take flight,\r\n\r\nAt TAB UNSCRIPTED, where we sing through the night.\r\n\r\nWhether you`re a pro or just love to sing,\r\n\r\nCome share your melody, let the music ring.\r\n\r\nFrom soulful tunes to powerful ballads,\r\n\r\nOur stage is open to all your talents.\r\n\r\nAt The Artist Barefoot, the vibe’s just right,\r\n\r\nFor voices to soar and hearts to ignite.\r\n\r\n\r\n\r\n📅 Every Sunday | 6 PM To 7 PM\r\n\r\n📍 The Artist Barefoot, 1st Floor, Above HDFC Bank, Rana Pratap Marg, Near Dainik Jagran Chauraha\r\n\r\n\r\n\r\nNo scripts, just pure, live harmonies,\r\n\r\nTAB UNSCRIPTED is where your voice is free.\r\n\r\nJoin us for a night of music and cheer,\r\n\r\nWhether you sing or listen, everyone’s welcome here!", "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411517-zvhdhjmfxj-portrait.jpg", "The Artist BareFoot: Lucknow", "TAB UNSCRIPTED (Singing)", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" },
                    { new Guid("81a337ec-2a7b-483e-a6c5-f1b317d4190d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "Hello Aadab, Namastey !\r\n\r\n\r\n\r\nAfter spending an entire week with stress and lectures from your boss/parents, it`s time for you to sit back and Laugh Now Lucknow  \r\n\r\nThe 4 comics from Lucknow will take up the job to get you on a laughter ride. The guys don`t tickle the ribs because that`s what surgeons do, instead they make sure you have a good time.", "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U2F0LCAxOSBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00344290-xcgwplybxh-portrait.jpg", "Dripp Cafe : Lucknow", "Laugh Now Lucknow", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" },
                    { new Guid("89cd6470-cc2b-4fa3-ac39-4a3c891a0d8c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), "Kanha is touring across India with his one hour long special Naram Lehja by Kanha, is an Indian poet and song writter. Born in Palwal,Haryana, Kanha gained recognition from his poetry videos on YouTube. Kanha have also traveled across India and performed in numerous colleges, schools and streets\r\n\r\nHe is popularly known for his viral poetries such as Ye narm lehja ,Acha rahega,Tumhara Pagal etc", "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Q%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411760-amskuctpyc-portrait.jpg", "Kanha Kamboj, Lucknow", "Naram Lehja by Kanha Kamboj", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "4740bdf0-b417-4841-9ca2-68b97677df45" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("01d7e6f2-4cbc-4a53-8a90-97b72768e508"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("094ebf32-b215-48a2-8231-72a70575306a"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("81a337ec-2a7b-483e-a6c5-f1b317d4190d"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("89cd6470-cc2b-4fa3-ac39-4a3c891a0d8c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4740bdf0-b417-4841-9ca2-68b97677df45");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0ab5c594-bd8a-424c-a68e-c1d9ff2d0e70", 0, "7c0146a2-1e37-4dfc-88df-75d73ee67a5c", "attendee1@test.com", false, "Attendee 1", false, null, "ATTENDEE1@TEST.COM", "ATTENDEE1@TEST.COM", "AQAAAAIAAYagAAAAEIxSE9HhWAm7KlqxkzpXoA1SbdcrPmpAKJ7bSlQP88OSqRcOV7eccfBWsg8/ExCSfw==", null, false, "eae702f1-ff3b-4435-b647-c320a58eed09", false, "attendee1@test.com" },
                    { "2f1c8bc0-2eb7-46cb-b09f-9db5ad32701e", 0, "5030b862-b5a2-47a8-83dd-d4958dc1895a", "attendee2@test.com", false, "Attendee 2", false, null, "ATTENDEE2@TEST.COM", "ATTENDEE2@TEST.COM", "AQAAAAIAAYagAAAAEG51XxWY0dbLO+MzH6YpvS45i7CgSH0Gju+f7gqNExKBYpjdkpZ7pQm1nsaPeZ7Pgg==", null, false, "dfb21258-cd58-415f-a932-62d26caca38b", false, "attendee2@test.com" },
                    { "7b253f0b-aad2-49dc-836e-8188473a8b8c", 0, "3971f494-295f-463b-bac4-38a377c1ce21", "organizer1@test.com", false, "Organizer 1", false, null, "ORGANIZER1@TEST.COM", "ORGANIZER1@TEST.COM", "AQAAAAIAAYagAAAAELQxY0atdkpxdG9MGGAPNjYtkTNwwk4eY9YzrS5mp6NojJtZf5xNUIf5BD6I29Cc+A==", null, false, "458730c0-4d01-4ab7-bbda-ff0ff89c76f0", false, "organizer1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "0ab5c594-bd8a-424c-a68e-c1d9ff2d0e70" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "2f1c8bc0-2eb7-46cb-b09f-9db5ad32701e" },
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "7b253f0b-aad2-49dc-836e-8188473a8b8c" }
                });
        }
    }
}
