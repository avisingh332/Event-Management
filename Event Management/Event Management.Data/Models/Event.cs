using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Organizer")]
        public Guid OrganizerId { get; set; }
        
        //navigation Property
        public ApplicationUser Organizer { get; set; }
        public ICollection<ApplicationUser> Attendees { get; set; }

    }
}
