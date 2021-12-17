using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EO_S20_TestBooking.Models
{
    public class AvailableTime
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateNTime { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }

    }
}
