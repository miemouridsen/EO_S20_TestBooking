using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace EO_S20_TestBooking.Models
{
    public class LocationPageModel
    {
        public string Ssn { get; set; }
        public Guid SelectedLocationId { get; set; }
        public List<Location> Locations { get; set; }
    }

    public class AvailableTimesPageModel
    {
        public string Ssn { get; set; }
        public Guid SelectedLocationId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime SelectedAppointment { get; set; } = DateTime.Now;
        public List<DateTime> AvailableTimes { get; set; }
    }
    public class AppointmentPageModel
    {
        public string Ssn { get; set; }
        public Guid SelectedLocationId { get; set; }
        public DateTime SelectedAppointment { get; set; } = DateTime.Now;
        public Location Location { get; set; }
    }
    public class ConfirmationPageModel
    {
        public string Ssn { get; set; }
        public Guid SelectedLocationId { get; set; }
        public DateTime SelectedAppointment { get; set; } = DateTime.Now;
    }
}
