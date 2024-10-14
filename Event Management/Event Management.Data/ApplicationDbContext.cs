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
