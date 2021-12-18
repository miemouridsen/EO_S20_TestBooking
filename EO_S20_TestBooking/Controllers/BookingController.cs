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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TestCenters(string ssn, LocationPageModel model)
        {
            model.Ssn = ssn;
            List<Location> testCenters = await _bookingService.GetAllLocations();
            model.Locations = testCenters;

            return View(model);
        }

        public async Task<IActionResult> AvailableTimes(Guid id, AvailableTimesPageModel model)
        {
            model.LocationId = id;
            List<Appointment> appointments = await _bookingService.GetAppointments(id);
            Location location = await _bookingService.GetLocation(id);
            List<DateTime> availableTimes = location.AvailableTimes.ToList();

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

        public async Task<IActionResult> Confirmation(string timeOfAppointment, Guid locId, AppointmentConfirmationPageModel model, string ssn = "8888888888")
        {
            //model.Appointment.Id = Guid.NewGuid();
            model.Appointment.Ssn = ssn;
            model.Appointment.LocationId = locId;
            model.Appointment.Location = await _bookingService.GetLocation(locId);
            // If argument exception, pass string and parse to date
            model.Appointment.Date = DateTime.Parse(timeOfAppointment);
            
            return View(model);
        }

        public async Task<IActionResult> Redirection(string ssn, Guid locId, string timeOfAppointment)
        {
            var appointment = new Appointment();
            appointment.Id = Guid.NewGuid();
            appointment.Ssn = ssn;
            appointment.LocationId = locId;
            // If argument exception, pass string and parse to date
            appointment.Date = DateTime.Parse(timeOfAppointment);
            int i = await _bookingService.MakeAppointment(appointment);
            return Redirect("/Home/Index");
        }
    }
}
