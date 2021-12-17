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

        public async Task<IActionResult> TestCenters(LocationPageModel model)
        {
            List<Location> testCenters = await _bookingService.GetAllLocations();
            model.Locations = testCenters;

            return View(model);
        }

        public async Task<IActionResult> AvailableTimes(Guid id, AvailableTimesPageModel model)
        {
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

        public IActionResult Confirmation(string timeOfAppointment, AppointmentConfirmationPageModel model)
        {
            model.Appointment.Id = Guid.NewGuid();
            model.Appointment.LocationId = Guid.NewGuid();
            
            // If argument exception, pass string and parse to date
            model.Appointment.Date = DateTime.Parse(timeOfAppointment);
            
            return View(model);
        }
    }
}
