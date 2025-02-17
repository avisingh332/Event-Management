﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Data.Models
{
    public  class ApplicationUser :IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<Event>? OrganizedEvents { get; set; }
        public virtual ICollection<EventAttendee>? EventAttendees { get; set; }
    }

}
