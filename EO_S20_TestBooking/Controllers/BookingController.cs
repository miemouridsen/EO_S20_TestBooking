using EO_S20_TestBooking.Models;
using EO_S20_TestBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EO_S20_TestBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public string Ssn { get; set; } = "0000000000";
        public Location SelectedLocation { get; set; } = new();
        public DateTime SelectedDate { get; set; } = new();

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public IActionResult Index(SsnPageModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> TestCenters(LocationPageModel model)
        {
            var ssn = model.Ssn;
            Ssn = ssn;
            List<Location> testCenters = await _bookingService.GetAllLocations();
            model.Locations = testCenters;

            return View(model);
        }

        public async Task<IActionResult> AvailableTimes(Guid id, AvailableTimesPageModel model)
        {
            SelectedLocation = await _bookingService.GetLocation(id);
            List<DateTime> availableTimes = SelectedLocation.AvailableTimes.ToList();
            List<Appointment> appointments = await _bookingService.GetAppointments(id);

            if (appointments.Count > 0)
            {
                foreach (Appointment appointment in appointments)
                {
                    var test = availableTimes.SingleOrDefault(time => appointment.Date.Day == time.Day && appointment.Date.Hour == time.Hour && appointment.Date.Minute == time.Minute);
                    availableTimes.Remove(test);
                }
            }

            model.AvailableTimes = availableTimes;

            return View(model);
        }

        //Virker ikke pga. alt er null
        public IActionResult Confirmation(AppointmentConfirmationPageModel model)
        {
            SelectedDate.AddYears(model.Date.Year);
            SelectedDate.AddMonths(model.Date.Month);
            SelectedDate.AddDays(model.Date.Day);
            SelectedDate.AddHours(model.Time.Hour);
            SelectedDate.AddMinutes(model.Time.Minute);

            //model.Appointment.Id = Guid.NewGuid();
            model.Appointment.Ssn = Ssn;
            model.Appointment.Location = SelectedLocation;
            // If argument exception, pass string and parse to date
            model.Appointment.Date = SelectedDate;
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Redirection()
        {
            var appointment = new Appointment();
            appointment.Id = Guid.NewGuid();
            appointment.Ssn = Ssn;
            appointment.Date = SelectedDate;
            appointment.LocationId = SelectedLocation.Id;
            int i = await _bookingService.MakeAppointment(appointment);
            return Redirect("/Home/Index");
        }
    }
}
