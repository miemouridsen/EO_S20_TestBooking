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

        // Consider GET vs POST
        // GET for RestFul convention
        // POST for a messed up convention such as MVC
        // [HttpGet("Booking/{ssn}")]
        
        public async Task<IActionResult> AvailableTimes(AvailableTimesPageModel model)
        {
            List<Appointment> appointments = await _bookingService.GetAppointments(model.SelectedLocationId);
            Location location = await _bookingService.GetLocation(model.SelectedLocationId);
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

        public async Task<IActionResult> Confirmation(AppointmentPageModel model)
        {
            model.Location = await _bookingService.GetLocation(model.SelectedLocationId);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAppointment(ConfirmationPageModel model)
        {
            var appointment = new Appointment();
            appointment.Id = Guid.NewGuid();
            appointment.Ssn = model.Ssn;
            appointment.Date = model.SelectedAppointment;
            appointment.LocationId = model.SelectedLocationId;
            int i = await _bookingService.MakeAppointment(appointment);

            return Redirect("/Home/Index");
        }
    }
}
