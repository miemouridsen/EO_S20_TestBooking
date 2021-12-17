using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EO_S20_TestBooking.Models
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Address { get; set; }
        [NotMapped]
        public List<DateTime> AvailableTimes { get; set; } = GetAvailableTimes();
        public List<Appointment> Appointments { get; set; }

        private static List<DateTime> GetAvailableTimes()
        {
            var list = new List<DateTime>();
            for (int day = 1; day < 32; day++)
            {
                for (int hour = 8; hour < 18; hour++)
                {
                    for (int minute = 0; minute < 60; minute += 10)
                    {
                        list.Add(new DateTime(2021, 12, day, hour, minute, 0));
                    }
                }
            }
            return list;
        }
    }
}