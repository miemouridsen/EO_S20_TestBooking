using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EO_S20_TestBooking.Models
{
    public class SsnPageModel : PageModel
    {
        [BindProperty]
        public string Ssn { get; set; }
    }

    public class LocationPageModel
    {
        public List<Location> Locations { get; set; }
    }

    public class AvailableTimesPageModel
    {
        [BindProperty, DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        [BindProperty, DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public List<DateTime> AvailableTimes { get; set; }
    }

    public class AppointmentConfirmationPageModel
    {
        public Appointment Appointment { get; set; }
    }
}
