﻿using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using Event_Management.Business.Extensions;
using Event_Management.Business.Services.IServices;
using Event_Management.Data.Models;
using Event_Management.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EventResponseDto>> GetEventById([FromRoute] Guid id)
        {
            string userId = User.GetUserId();
            var response = await _eventService.GetEventByIdAsync(id, userId);
            return Ok(response);
        }
        
        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<ActionResult<EventResponseDto>> CreateEventAsync([FromBody] EventRequestDto req)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return ValidationProblem("User is not Valid");
            var response = await _eventService.CreateEventAsync(req, userId);
            return Created($"api/Event/{response.Id}", response);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        [Route("Organizer")]
        public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetAllEventsForOrganizer()
        {
            var userId = User.GetUserId();
            //var role = User.GetRole();
            if (string.IsNullOrEmpty(userId)) return ValidationProblem("Unauthorized User");
            return Ok(await _eventService.GetEventsForOrganizerAsync(userId));
            
        }
        [HttpGet]
        [Route("Attendee")]
        public async Task<ActionResult<IEnumerable<EventResponseForUserDto>>> GetAllEventsForAttendee()
        {
            var userId = User.GetUserId();
            //if ( string.IsNullOrEmpty(userId)) return ValidationProblem("Unauthorized User");
           return Ok(await _eventService.GetUpcomingEventsForAttendeeAsync(userId));
        }

        [HttpGet]
        [Authorize(Roles = "Attendee")]
        [Route("my-registrations")]
        public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetMyRegistrations()
        {
            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authorizsed");

            var response = await _eventService.GetMyRegistrationsAsync(userId);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Attendee")]
        [Route("{eventId}/register")]
        public async Task<IActionResult> RegisterUser([FromRoute] Guid eventId)
        {
            string userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authorizsed");
            bool isCompleted = await _eventService.RegisterUserAsync(eventId, userId);
            if (isCompleted)
            {
                return Ok(new
                {
                    Message = "User Has Successfully Registered For Event",
                });
            }
            else
            {
                return BadRequest(new
                {
                    Message  = "Failed to Register for Event"
                });
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Attendee")]
        [Route("my-registration/{eventId}")]

        public async Task<IActionResult> RemoveRegistrationAsync([FromRoute] Guid eventId)
        {
            string userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authorizsed");
            var isSuccess = await _eventService.RemoveRegistrationAsync(eventId, userId);
            if (isSuccess)
            {
                return Ok(new
                {
                    Message="Successfully Removed Registration",
                });
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Failed to Remove Registration."
                });
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Organizer")]
        [Route("{id}")]
        public async Task<ActionResult<EventResponseDto>> CancelEventAsync([FromRoute] Guid id)
        {
            var response = await _eventService.CancelEventAsync(id);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Organizer")]
        [Route("{id}")]

        public async Task<ActionResult<EventResponseDto>> UpdateEventAsync([FromRoute] Guid id, [FromBody] EventRequestDto req)
        {
            var response = await _eventService.UpdateEventAsync(id, req);
            return Ok(response);
        }
        
    }
}
