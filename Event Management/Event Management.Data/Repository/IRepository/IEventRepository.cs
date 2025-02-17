﻿using Event_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data.Repository.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetMyRegistrationsAsync(string userId);
        Task<bool> RegisterUserAsync(Guid eventId, string userId);
        Task<bool> RemoveRegistrationAsync(Guid eventId, string userId);
        Task<IEnumerable<Event>> GetUpcomingEventsForUserAsync( Expression<Func<Event, bool>>? filter = null);
        Task<IEnumerable<Event>> GetAllEventWithAttendeesAsync(Expression<Func<Event, bool>>? filter = null);
    }
}
