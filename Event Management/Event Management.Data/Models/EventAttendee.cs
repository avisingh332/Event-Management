using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data.Models
{
    public class EventAttendee
    {
        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        [ForeignKey("Attendee")]
        public string AttendeeId { get; set; }
        // navigation Property 

        public virtual Event  Event { get; set; }
        public virtual ApplicationUser Attendee { get; set; }
    }
}
