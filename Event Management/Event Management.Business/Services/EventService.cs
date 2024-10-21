using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using Event_Management.Business.Services.IServices;
using Event_Management.Data.Models;
using Event_Management.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Event_Management.Business.Services
{
    public class EventService : IEventService
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEventRepository _eventRepository;
        public EventService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEventRepository eventRepository)
        {
            //_userManager = userManager;
            //_roleManager = roleManager;
            _eventRepository = eventRepository;
        }

        public async Task<EventResponseDto> CreateEventAsync(EventRequestDto d, string organizerId)
        {
            Guid eventId = Guid.NewGuid();
            //string userId = _userManager.GetUserId();

            Event e = new Event
            {
                Id = eventId,
                Name = d.Name,
                Description = d.Description,
                Location = d.Location,
                DateTime = d.DateTime,
                CreatedAt = DateTime.UtcNow,
                OrganizerId = organizerId,
                ImageUrl = d.ImageUrl,
            };
             await _eventRepository.AddAsync(e);
            var eventAdded = await _eventRepository.GetAsync(e => e.Id ==eventId);
            if(eventAdded == null)
            {
                throw new Exception("Event could not be added.");
            }

            var response = new EventResponseDto
            {
                Id = eventAdded.Id,
                Name = eventAdded.Name,
                Description = eventAdded.Description,
                Location = eventAdded.Location,
                DateTime = eventAdded.DateTime,
                CreatedAt = eventAdded.CreatedAt,
                OrganizerId = eventAdded.OrganizerId
            };
            return response;
        }

        public async Task<EventResponseForUserDto> GetEventByIdAsync(Guid id, string? userid=null)
        {
            var e = await _eventRepository.GetAsync(e => e.Id == id, includeProperties: "EventAttendees,Organizer");
            if (e == null)
            {
                throw new KeyNotFoundException("No Record Found with this key");
            }
            var response = new EventResponseForUserDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Location = e.Location,
                DateTime = e.DateTime,
                CreatedAt = e.CreatedAt,
                OrganizerId = e.OrganizerId,
                ImageUrl = e.ImageUrl,
                IsRegistered = e.EventAttendees.Any(ea => ea.AttendeeId ==userid),
            };
            if (e.Organizer != null)
            {

                response.Organizer = new AttendeeResponseDto
                {
                    Id = e.OrganizerId,
                    Name = e.Organizer.FullName,
                    Email = e.Organizer.Email != null ? e.Organizer.Email : "",
                };
            }
            return response;
        }

        public async Task<IEnumerable<EventResponseDto>> GetEventsForOrganizerAsync(string userId)
        {
            var events = await _eventRepository.GetAllEventWithAttendeesAsync(e => e.OrganizerId == userId);
            IEnumerable<EventResponseDto> response = new List<EventResponseDto>();
            if (events.Any())
            {
                response = events.Select(e =>
                {
                    var respObj = new EventResponseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        DateTime = e.DateTime,
                        CreatedAt = e.CreatedAt,
                        OrganizerId = e.OrganizerId, 
                        ImageUrl = e.ImageUrl,
                    };
                    if (e.Organizer != null)
                    {

                        respObj.Organizer = new AttendeeResponseDto
                        {
                            Id = e.OrganizerId,
                            Name = e.Organizer.FullName,
                            Email = e.Organizer.Email!=null? e.Organizer.Email: "",
                        };
                    }
                    if ( e.EventAttendees!=null && e.EventAttendees.Any())
                    {
                        respObj.Attendees = e.EventAttendees.Select<EventAttendee, AttendeeResponseDto>(ea =>
                        {
                            return new AttendeeResponseDto
                            {
                                Id = ea.AttendeeId,
                                Name = ea.Attendee.FullName,
                                Email = e.Organizer.Email != null ? e.Organizer.Email : "",
                            };
                        });
                    }
                    return respObj;
                });
            }

            return response;
        }
        public async Task<IEnumerable<EventResponseForUserDto>> GetUpcomingEventsForAttendeeAsync(string? userId = null)
        {
            var events = await _eventRepository.GetUpcomingEventsForUserAsync(e => e.DateTime > DateTime.Now);
            IEnumerable<EventResponseForUserDto> response = new List<EventResponseForUserDto>();
            if (events.Any())
            {
                response = events.Select(e =>
                {
                    var respObj = new EventResponseForUserDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        DateTime = e.DateTime,
                        CreatedAt = e.CreatedAt,
                        OrganizerId = e.OrganizerId,
                        ImageUrl = e.ImageUrl,
                        IsRegistered = e.EventAttendees.Any(ea => ea.AttendeeId == userId)
                    };
                    if (e.Organizer != null)
                    {
                        respObj.Organizer = new AttendeeResponseDto
                        {
                            Id = e.OrganizerId,
                            Name = e.Organizer.FullName,
                            Email = e.Organizer.Email != null ? e.Organizer.Email : "",
                        };
                    }

                    return respObj;
                });
            }
            
            return response;
        }

        public async Task<IEnumerable<EventResponseDto>> GetMyRegistrationsAsync(string userId)
        {
            var myEvents = await _eventRepository.GetMyRegistrationsAsync(userId);
            List<EventResponseDto> response = new List<EventResponseDto>();
            if (myEvents!=null &&  myEvents.Any())
            {
                response = myEvents.Select(e =>
                {
                    var respObj = new EventResponseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        DateTime = e.DateTime,
                        CreatedAt = e.CreatedAt,
                        OrganizerId = e.OrganizerId, 
                        ImageUrl = e.ImageUrl,
                    };
                    if (e.Organizer != null)
                    {
                        respObj.Organizer = new AttendeeResponseDto
                        {
                            Id = e.OrganizerId,
                            Name = e.Organizer.FullName,
                            Email = e.Organizer.Email != null ? e.Organizer.Email : "",
                        };
                    }
                    return respObj;
                }).ToList();
            }
            return response;
        }

        public async Task<bool> RegisterUserAsync(Guid eventId, string userId)
        {
            var response = await _eventRepository.RegisterUserAsync(eventId, userId);
            return response;
        }

        public async Task<bool> RemoveRegistrationAsync(Guid eventId, string userId)
        {
             return await _eventRepository.RemoveRegistrationAsync(eventId, userId);

        }

        public async Task<EventResponseDto> CancelEventAsync(Guid eventId)
        {
            var eventToRemove = await _eventRepository.GetAsync(e => e.Id == eventId);

            //if(eventToRemove == null)   Throw Some Error here 

            await _eventRepository.RemoveAsync(eventToRemove);

            //await _eventRepository.RemoveAsync(eventToRemove)?? throw some error
            var response = new EventResponseDto
            {
                Id = eventToRemove.Id,
                Name = eventToRemove.Name,
                Description = eventToRemove.Description,
                Location = eventToRemove.Location,
                DateTime = eventToRemove.DateTime,
                CreatedAt = eventToRemove.CreatedAt,
                OrganizerId = eventToRemove.OrganizerId,
            };
            if (eventToRemove.Organizer != null)
            {

                response.Organizer = new AttendeeResponseDto
                {
                    Id = eventToRemove.OrganizerId,
                    Name = eventToRemove.Organizer.FullName,
                    Email = eventToRemove.Organizer.Email != null ? eventToRemove.Organizer.Email : "",
                };
            }
            return response;
        }

        public async Task<EventResponseDto> UpdateEventAsync(Guid eventId, EventRequestDto e)
        {
            var eventToUpdate = await _eventRepository.GetAsync(e => e.Id == eventId) ?? throw new KeyNotFoundException("Event Doesn't Exist");

            eventToUpdate.Name = e.Name;
            eventToUpdate.Description = e.Description;
            eventToUpdate.Location = e.Location;
            eventToUpdate.DateTime = e.DateTime;
            if(string.IsNullOrEmpty(e.ImageUrl)) eventToUpdate.ImageUrl = e.ImageUrl;

            await _eventRepository.UpdateAsync(eventToUpdate);

            var updatedEvent = await _eventRepository.GetAsync(e => e.Id == e.Id);

            var response =  new EventResponseDto
            {
                Id = updatedEvent.Id,
                Name = updatedEvent.Name,
                Description = updatedEvent.Description,
                Location = updatedEvent.Location,
                DateTime = updatedEvent.DateTime,
                CreatedAt = updatedEvent.CreatedAt,
                OrganizerId = updatedEvent.OrganizerId,
            };
            if (updatedEvent.Organizer != null)
            {

                response.Organizer = new AttendeeResponseDto
                {
                    Id = updatedEvent.OrganizerId,
                    Name = updatedEvent.Organizer.FullName,
                    Email = updatedEvent.Organizer.Email != null ? updatedEvent.Organizer.Email : "",
                };
            }
            return response;
        }

    }
}
