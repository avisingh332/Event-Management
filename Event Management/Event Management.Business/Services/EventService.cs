using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using Event_Management.Business.Services.IServices;
using Event_Management.Data.Models;
using Event_Management.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<EventResponseDto> GetEventByIdAsync(Guid id)
        {
            var e = await _eventRepository.GetAsync(e => e.Id == id);
            if (e == null)
            {
                throw new KeyNotFoundException("No Record Found with this key");
            }
            var response = new EventResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Location = e.Location,
                DateTime = e.DateTime,
                CreatedAt = e.CreatedAt,
                OrganizerId = e.OrganizerId

            };
            return response;
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(string userId, string role)
        {
            IEnumerable<Event> events = new List<Event>();
            switch (role)
            {
                case "Organizer":
                    events = await _eventRepository.GetAllAsync(e => e.OrganizerId == userId, includeProperties:"Organizer");
                    break;
                case "Attendee":
                    events = await _eventRepository.GetAllAsync(e => e.DateTime > DateTime.Now);
                    break;
            }
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
                        OrganizerId = e.OrganizerId
                    };
                    if (e.Organizer!=null)
                    {
                        e.Organizer.OrganizedEvents = null;
                        respObj.Organizer = e.Organizer;
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
                    return new EventResponseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        DateTime = e.DateTime,
                        CreatedAt = e.CreatedAt,
                        OrganizerId = e.OrganizerId,
                        Organizer = e.Organizer
                    };
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
                Organizer = eventToRemove.Organizer
            };
            return response;
        }

        public async Task<EventResponseDto> UpdateEventAsync(Guid eventId, EventRequestDto e)
        {
            var eventToUpdate = await _eventRepository.GetAsync(e => e.Equals(eventId)) ?? throw new KeyNotFoundException("Event Doesn't Exist");

            eventToUpdate.Name = e.Name;
            eventToUpdate.Description = e.Description;
            eventToUpdate.Location = e.Location;
            eventToUpdate.DateTime = e.DateTime;

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
                Organizer = updatedEvent.Organizer
            };
            return response;
        }
    }
}
