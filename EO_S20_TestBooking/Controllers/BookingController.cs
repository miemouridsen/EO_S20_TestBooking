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
        private readonly ILogger<HomeController> _logger;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<HomeController> logger, IBookingService bookingService)
        {
            _logger = logger;
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

        public async Task<IActionResult> AvailableTimes(Guid id, AppointmentPageModel model)
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

        public IActionResult Confirmation(SsnPageModel ssnModel, LocationPageModel locModel, AppointmentPageModel appModel, ConfirmationPageModel model)
        {
            model.Appointment.Id = Guid.NewGuid();
            model.Appointment.LocationId = Guid.NewGuid();
            model.Appointment.Date = new DateTime(appModel.Date.Year, appModel.Date.Month, appModel.Date.Day, 0, 0, 0);
            
            return View(model);
        }
    }
}
