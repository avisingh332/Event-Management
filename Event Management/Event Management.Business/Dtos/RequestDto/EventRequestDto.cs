using Event_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Dtos.RequestDto
{
    public class EventRequestDto
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Description { get; set; } 

    }
}
