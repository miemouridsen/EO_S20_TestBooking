using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EO_S20_TestBooking.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Ssn { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        [NotMapped]
        public bool AppointmentIsValid => Date < DateTime.Now;
        //public bool LocationIsValid => Location?.Address is not null;
        [NotMapped]
        public bool SsnIsValid => Ssn?.Length == 10;
    }
}
