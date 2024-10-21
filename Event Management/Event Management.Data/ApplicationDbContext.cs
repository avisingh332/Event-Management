using Event_Management.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt):base(opt)
        {
            
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<EventAttendee> EventsAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            string userId1 = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();
            string userId3 = Guid.NewGuid().ToString();
            //Password Hasher
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasData(
                     new ApplicationUser
                     {
                         Id = userId1,
                         FullName = "Organizer 1",
                         UserName = "organizer1@test.com",
                         Email = "organizer1@test.com",
                         NormalizedEmail = "organizer1@test.com".ToUpper(),
                         NormalizedUserName = "organizer1@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = userId2,
                         FullName = "Attendee 1",
                         UserName = "attendee1@test.com",
                         NormalizedUserName = "attendee1@test.com".ToUpper(),
                         Email = "attendee1@test.com",
                         NormalizedEmail = "attendee1@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = userId3,
                         FullName = "Attendee 2",
                         UserName = "attendee2@test.com",
                         NormalizedUserName = "attendee2@test.com".ToUpper(),
                         Email = "attendee2@test.com",
                         NormalizedEmail = "attendee2@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     }
                );
            });

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = Guid.NewGuid(), 
                    Name = "Laugh Now Lucknow", 
                    Location= "Dripp Cafe : Lucknow", 
                    DateTime = DateTime.Parse("2024-10-19 17:00:00"),
                    OrganizerId = userId1,
                    ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U2F0LCAxOSBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00344290-xcgwplybxh-portrait.jpg",
                    Description = "Hello Aadab, Namastey !\r\n\r\n\r\n\r\nAfter spending an " +
                    "entire week with stress and lectures from your boss/parents, it`s time for " +
                    "you to sit back and Laugh Now Lucknow  \r\n\r\nThe 4 comics from Lucknow " +
                    "will take up the job to get you on a laughter ride. The guys don`t tickle " +
                    "the ribs because that`s what surgeons do, instead they make sure you have a good time."
                },
                new Event
                {
                    Id = Guid.NewGuid(), 
                    Name = "TAB UNSCRIPTED (Singing)", 
                    Location = "The Artist BareFoot: Lucknow", 
                    DateTime = DateTime.Parse("2024-10-20 18:00:00"),
                    OrganizerId = userId1,
                    ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Qgb253YXJkcw%3D%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411517-zvhdhjmfxj-portrait.jpg",
                    Description = "This Sunday, let your voice take flight,\r\n\r\nAt TAB UNSCRIPTED, " +
                    "where we sing through the night.\r\n\r\nWhether you`re a pro or just love to sing," +
                    "\r\n\r\nCome share your melody, let the music ring.\r\n\r\nFrom soulful tunes to powerful ballads," +
                    "\r\n\r\nOur stage is open to all your talents.\r\n\r\nAt The Artist Barefoot, the vibe’s just right," +
                    "\r\n\r\nFor voices to soar and hearts to ignite.\r\n\r\n\r\n\r\n" +
                    "📅 Every Sunday | 6 PM To 7 PM\r\n\r\n📍 The Artist Barefoot, 1st Floor, Above HDFC Bank, " +
                    "Rana Pratap Marg, Near Dainik Jagran Chauraha\r\n\r\n\r\n\r\nNo scripts, just pure, live harmonies," +
                    "\r\n\r\nTAB UNSCRIPTED is where your voice is free.\r\n\r\nJoin us for a night of music and cheer," +
                    "\r\n\r\nWhether you sing or listen, everyone’s welcome here!"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Name = "Guru Randhawa - Moon Rise Tour, Lucknow",
                    Location = "Indira Gandhi Pratishtahn , Lucknow",
                    DateTime  = DateTime.Parse("2024-11-10 18:00:00"),
                    OrganizerId = userId1,
                    ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAxMCBOb3Y%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411817-dfbcsfgdde-portrait.jpg",
                    Description = "The sensational Punjabi superstar Guru Randhawa is hitting the road for an epic Indian Tour! " +
                    "\r\n\r\nBrace yourselves for electrifying performances, unforgettable moments, and a musical journey like never before. " +
                    "Gather your squad, and get ready to groove to the beats of your favorite hits!\r\n\r\n " +
                    "\r\n\r\nExpect nothing but the best as Guru brings his electrifying performances to each city, " +
                    "complete with exclusive setlists, surprise fan interactions, " +
                    "and unforgettable moments that only a global superstar can deliver. Whether it's belting out his biggest hits or " +
                    "connecting with fans in unexpected ways, Guru's tour is all about creating a once-in-a-lifetime experience.\r\n\r\n\r\n\r\n#GuruRandhawa #IndianTour #LiveConcert #MoonriseTour"
                }, 
                new Event
                {
                    Id = Guid.NewGuid(), 
                    Name = "Naram Lehja by Kanha Kamboj", 
                    Location = "Kanha Kamboj, Lucknow",
                    DateTime = DateTime.Parse("2024-10-19 16:00:00"),
                    OrganizerId = userId1,
                    ImageUrl = "https://assets-in.bmscdn.com/discovery-catalog/events/tr:w-400,h-600,bg-CCCCCC:w-400.0,h-660.0,cm-pad_resize,bg-000000,fo-top:l-text,ie-U3VuLCAyMCBPY3Q%3D,fs-29,co-FFFFFF,ly-612,lx-24,pa-8_0_0_0,l-end/et00411760-amskuctpyc-portrait.jpg",
                    Description = "Kanha is touring across India with his one hour long special Naram Lehja by Kanha, " +
                    "is an Indian poet and song writter. Born in Palwal,Haryana, " +
                    "Kanha gained recognition from his poetry videos on YouTube. Kanha have also traveled across India and " +
                    "performed in numerous colleges, schools and streets\r\n\r\nHe is popularly known for his viral poetries " +
                    "such as Ye narm lehja ,Acha rahega,Tumhara Pagal etc"
                }
            );

            var organizerRoleId = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1";
            var attendeeRoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = organizerRoleId,
                    Name = "Organizer",
                    NormalizedName = "Organizer".ToUpper(),
                    ConcurrencyStamp = organizerRoleId
                },
                new IdentityRole()
                {
                    Id = attendeeRoleId,
                    Name  = "Attendee",
                    NormalizedName = "Attendee".ToUpper(),
                    ConcurrencyStamp = attendeeRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var assignRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = userId1,
                    RoleId = organizerRoleId
                },
                new()
                {
                    UserId = userId2,
                    RoleId = attendeeRoleId
                },
                new()
                {
                    UserId = userId3,
                    RoleId = attendeeRoleId
                },

            };
            builder.Entity<IdentityUserRole<string>>().HasData(assignRoles);

            builder.Entity<EventAttendee>().HasKey(x => new { x.EventId, x.AttendeeId });

            builder.Entity<EventAttendee>()
                .HasOne(x => x.Attendee)
                .WithMany(au => au.EventAttendees)
                .HasForeignKey(x => x.AttendeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EventAttendee>()
                .HasOne(x => x.Event)
                .WithMany(e => e.EventAttendees)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
