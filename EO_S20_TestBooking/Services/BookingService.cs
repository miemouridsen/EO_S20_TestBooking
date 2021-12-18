using EO_S20_TestBooking.Data;
using EO_S20_TestBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EO_S20_TestBooking.Services
{
    public interface IBookingService
    {
        Task<int> MakeAppointment(Appointment appointment);
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Location>> GetAllLocations();
        Task<List<Appointment>> GetAppointments(Guid id);
        Task<Location> GetLocation(Guid id);
    }

    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<int> MakeAppointment(Appointment appointment)
        {
            //if (appointment == null) throw new ArgumentNullException(nameof(appointment));
            //if (appointment.AppointmentIsValid) throw new ArgumentOutOfRangeException(nameof(appointment.Date));
            //if (appointment.LocationIsValid) throw new ArgumentException("Location is not valid");
            //if (appointment.SsnIsValid) throw new ArgumentException("SSN is not valid");

            await _context.Appointments.AddAsync(appointment);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations
                .Include(location => location.Appointments)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointments(Guid id)
        {
            return await _context.Appointments.Where(a => a.LocationId == id).ToListAsync();
        }

        public async Task<Location> GetLocation(Guid id)
        {
            return await _context.Locations.SingleOrDefaultAsync(l => l.Id == id);
        }
    }
}
