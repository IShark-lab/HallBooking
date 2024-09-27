using HallBooking.DLA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.EF
{
    public class HallBookingContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
        public DbSet<Service> Services { get; set; }

        public HallBookingContext(DbContextOptions<HallBookingContext> options)
            : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
