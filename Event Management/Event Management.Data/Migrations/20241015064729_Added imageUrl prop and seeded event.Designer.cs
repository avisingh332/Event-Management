﻿// <auto-generated />
using System;
using Event_Management.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_Management.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241015064729_Added imageUrl prop and seeded event")]
    partial class AddedimageUrlpropandseededevent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event_Management.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7b0e16d0-e72c-42ec-b13e-035e2e03ff99",
                            Email = "organizer1@test.com",
                            EmailConfirmed = false,
                            FullName = "Organizer 1",
                            LockoutEnabled = false,
                            NormalizedEmail = "ORGANIZER1@TEST.COM",
                            NormalizedUserName = "ORGANIZER1@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAED5mzdbksK1Y2ZdB53qs6ght5N0cPi/sYYmQIhmg/Ck2tRn3H/O5scSmRd0Smp2BhA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7ea8145c-5c63-451f-9cdf-19b41949fba4",
                            TwoFactorEnabled = false,
                            UserName = "organizer1@test.com"
                        },
                        new
                        {
                            Id = "4740bdf0-b417-4841-9ca2-68b97677df45",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "150e921e-2bf5-425f-9436-aba54bbf6107",
                            Email = "attendee1@test.com",
                            EmailConfirmed = false,
                            FullName = "Attendee 1",
                            LockoutEnabled = false,
                            NormalizedEmail = "ATTENDEE1@TEST.COM",
                            NormalizedUserName = "ATTENDEE1@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAyN7415CMI29A3w9ESwlsY9b7VPX7dEnW+A/snTcfgdTrPGsPaLgme0pCFZ59H3EQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b2d00935-fa3b-479a-99c7-182887e36bea",
                            TwoFactorEnabled = false,
                            UserName = "attendee1@test.com"
                        },
                        new
                        {
                            Id = "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "514277e8-bea4-4ba7-8adf-14cbfbfb2001",
                            Email = "attendee2@test.com",
                            EmailConfirmed = false,
                            FullName = "Attendee 2",
                            LockoutEnabled = false,
                            NormalizedEmail = "ATTENDEE2@TEST.COM",
                            NormalizedUserName = "ATTENDEE2@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKShNI7DsIYJikbZuYJjaA2DpdG/BUgyBMP18ilxpJUMMiPAm2oQ+nK3tRAzXwkFgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e54becf7-36f8-4f08-9e82-d540090f9bdc",
                            TwoFactorEnabled = false,
                            UserName = "attendee2@test.com"
                        });
                });

            modelBuilder.Entity("Event_Management.Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81a337ec-2a7b-483e-a6c5-f1b317d4190d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTime = new DateTime(2024, 10, 19, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Hello Aadab, Namastey !\r\n\r\n\r\n\r\nAfter spending an entire week with stress and lectures from your boss/parents, it`s time for you to sit back and Laugh Now Lucknow  \r\n\r\nThe 4 comics from Lucknow will take up the job to get you on a laughter ride. The guys don`t tickle the ribs because that`s what surgeons do, instead they make sure you have a good time.",
                            ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U2F0LCAxOSBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00344290-xcgwplybxh-portrait.jpg",
                            Location = "Dripp Cafe : Lucknow",
                            Name = "Laugh Now Lucknow",
                            OrganizerId = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7"
                        },
                        new
                        {
                            Id = new Guid("094ebf32-b215-48a2-8231-72a70575306a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTime = new DateTime(2024, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This Sunday, let your voice take flight,\r\n\r\nAt TAB UNSCRIPTED, where we sing through the night.\r\n\r\nWhether you`re a pro or just love to sing,\r\n\r\nCome share your melody, let the music ring.\r\n\r\nFrom soulful tunes to powerful ballads,\r\n\r\nOur stage is open to all your talents.\r\n\r\nAt The Artist Barefoot, the vibe’s just right,\r\n\r\nFor voices to soar and hearts to ignite.\r\n\r\n\r\n\r\n📅 Every Sunday | 6 PM To 7 PM\r\n\r\n📍 The Artist Barefoot, 1st Floor, Above HDFC Bank, Rana Pratap Marg, Near Dainik Jagran Chauraha\r\n\r\n\r\n\r\nNo scripts, just pure, live harmonies,\r\n\r\nTAB UNSCRIPTED is where your voice is free.\r\n\r\nJoin us for a night of music and cheer,\r\n\r\nWhether you sing or listen, everyone’s welcome here!",
                            ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411517-zvhdhjmfxj-portrait.jpg",
                            Location = "The Artist BareFoot: Lucknow",
                            Name = "TAB UNSCRIPTED (Singing)",
                            OrganizerId = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7"
                        },
                        new
                        {
                            Id = new Guid("01d7e6f2-4cbc-4a53-8a90-97b72768e508"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTime = new DateTime(2024, 11, 10, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The sensational Punjabi superstar Guru Randhawa is hitting the road for an epic Indian Tour! \r\n\r\nBrace yourselves for electrifying performances, unforgettable moments, and a musical journey like never before. Gather your squad, and get ready to groove to the beats of your favorite hits!\r\n\r\n \r\n\r\nExpect nothing but the best as Guru brings his electrifying performances to each city, complete with exclusive setlists, surprise fan interactions, and unforgettable moments that only a global superstar can deliver. Whether it's belting out his biggest hits or connecting with fans in unexpected ways, Guru's tour is all about creating a once-in-a-lifetime experience.\r\n\r\n\r\n\r\n#GuruRandhawa #IndianTour #LiveConcert #MoonriseTour",
                            ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAxMCBOb3Y%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411817-dfbcsfgdde-portrait.jpg",
                            Location = "Indira Gandhi Pratishtahn , Lucknow",
                            Name = "Guru Randhawa - Moon Rise Tour, Lucknow",
                            OrganizerId = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7"
                        },
                        new
                        {
                            Id = new Guid("89cd6470-cc2b-4fa3-ac39-4a3c891a0d8c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTime = new DateTime(2024, 10, 19, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kanha is touring across India with his one hour long special Naram Lehja by Kanha, is an Indian poet and song writter. Born in Palwal,Haryana, Kanha gained recognition from his poetry videos on YouTube. Kanha have also traveled across India and performed in numerous colleges, schools and streets\r\n\r\nHe is popularly known for his viral poetries such as Ye narm lehja ,Acha rahega,Tumhara Pagal etc",
                            ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Q%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411760-amskuctpyc-portrait.jpg",
                            Location = "Kanha Kamboj, Lucknow",
                            Name = "Naram Lehja by Kanha Kamboj",
                            OrganizerId = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7"
                        });
                });

            modelBuilder.Entity("Event_Management.Data.Models.EventAttendee", b =>
                {
                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttendeeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventId", "AttendeeId");

                    b.HasIndex("AttendeeId");

                    b.ToTable("EventsAttendees");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1",
                            ConcurrencyStamp = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1",
                            Name = "Organizer",
                            NormalizedName = "ORGANIZER"
                        },
                        new
                        {
                            Id = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00",
                            ConcurrencyStamp = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00",
                            Name = "Attendee",
                            NormalizedName = "ATTENDEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "3f6ee05f-a2c9-4d05-bf73-49b23007d3b7",
                            RoleId = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1"
                        },
                        new
                        {
                            UserId = "4740bdf0-b417-4841-9ca2-68b97677df45",
                            RoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00"
                        },
                        new
                        {
                            UserId = "a9f189d3-b1e2-423f-9c6a-bc2c51fdcd1d",
                            RoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Event_Management.Data.Models.Event", b =>
                {
                    b.HasOne("Event_Management.Data.Models.ApplicationUser", "Organizer")
                        .WithMany("OrganizedEvents")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Event_Management.Data.Models.EventAttendee", b =>
                {
                    b.HasOne("Event_Management.Data.Models.ApplicationUser", "Attendee")
                        .WithMany("EventAttendees")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Event_Management.Data.Models.Event", "Event")
                        .WithMany("EventAttendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Event_Management.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Event_Management.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Event_Management.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Event_Management.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("EventAttendees");

                    b.Navigation("OrganizedEvents");
                });

            modelBuilder.Entity("Event_Management.Data.Models.Event", b =>
                {
                    b.Navigation("EventAttendees");
                });
#pragma warning restore 612, 618
        }
    }
}
