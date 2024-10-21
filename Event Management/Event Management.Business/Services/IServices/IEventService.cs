using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Services.IServices
{
    public interface IEventService
    {
        Task<EventResponseDto> CreateEventAsync(EventRequestDto d, string organizerId);
        Task<EventResponseForUserDto> GetEventByIdAsync(Guid id, string? userid=null);
        Task<IEnumerable<EventResponseDto>> GetMyRegistrationsAsync(string userId);
        Task<bool> RegisterUserAsync(Guid eventId, string userId);
        Task<bool> RemoveRegistrationAsync(Guid eventId, string userId);
        Task<EventResponseDto> CancelEventAsync(Guid eventId);
        Task<EventResponseDto> UpdateEventAsync(Guid eventId, EventRequestDto e);
        Task<IEnumerable<EventResponseDto>> GetEventsForOrganizerAsync(string userId);
        Task<IEnumerable<EventResponseForUserDto>> GetUpcomingEventsForAttendeeAsync(string userId);
    }
}
