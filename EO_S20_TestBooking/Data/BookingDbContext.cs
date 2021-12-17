using EO_S20_TestBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EO_S20_TestBooking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = id1, Address = "Paludan mullersvej 24, 8200 Aarhus N" }, 
                new Location { Id = id2, Address = "Finlandsgade 67, 8200 Aarhus N" },
                new Location { Id = id3, Address = "Møllegårdsvej 1, 8200 Aarhus N" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001000", Date = new DateTime(2021, 12, 18, 12, 20, 0), LocationId = id1 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001001", Date = new DateTime(2021, 12, 18, 12, 30, 0), LocationId = id1 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001002", Date = new DateTime(2021, 12, 19, 12, 40, 0), LocationId = id1 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001003", Date = new DateTime(2021, 12, 19, 12, 50, 0), LocationId = id1 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001000", Date = new DateTime(2021, 12, 18, 12, 20, 0), LocationId = id2 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001001", Date = new DateTime(2021, 12, 18, 12, 30, 0), LocationId = id2 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001002", Date = new DateTime(2021, 12, 18, 12, 40, 0), LocationId = id3 },
                new Appointment { Id = Guid.NewGuid(), Ssn = "1001001003", Date = new DateTime(2021, 12, 19, 12, 50, 0), LocationId = id3 }
            );
        }
    }
}
