using Event_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Dtos.ResponseDto
{
    public class EventResponseForUserDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] public string Description { get; set; }

        [Required] public string Location { get; set; }

        [Required] public DateTime DateTime { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        public string OrganizerId { get; set; }
        public string ImageUrl { get; set; }

        public Boolean IsRegistered { get; set; }

        //navigation Property
        public AttendeeResponseDto? Organizer { get; set; }
        
    }
}
