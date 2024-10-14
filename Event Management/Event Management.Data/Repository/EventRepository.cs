﻿using Event_Management.Data.Models;
using Event_Management.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public readonly ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Event>> GetMyRegistrationsAsync(string userId)
        {
            var userWithEventAttendees = await _db.ApplicationUsers
            .Include(u => u.EventAttendees) 
            .ThenInclude(ea => ea.Event)    
            .FirstOrDefaultAsync(u => u.Id == userId);

            if (userWithEventAttendees == null)
            {
                return Enumerable.Empty<Event>();
            }

            return userWithEventAttendees.EventAttendees
                .Select(ea => ea.Event)
                .ToList();
        }
        public async Task<bool> RegisterUserAsync(Guid eventId, string userId)
        {
            await _db.EventsAttendees.AddAsync(new EventAttendee
            {
                AttendeeId = userId,
                EventId = eventId,
            });
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRegistrationAsync(Guid eventId, string userId)
        {
            // Check if particular registration exist 
            var registrationRecord = await _db.EventsAttendees.FirstOrDefaultAsync(ea => ea.EventId == eventId && ea.AttendeeId == userId);
            if(registrationRecord == null)
            {
                return false;
            }
            _db.EventsAttendees.Remove(registrationRecord);
            return await _db.SaveChangesAsync() > 0;

        }
    }
}
