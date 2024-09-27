using HallBooking.DLA.EF;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HallBookingContext _context;

        public BookingRepository(HallBookingContext context)
        {
            this._context = context;
        }

        //Перевiрка на сервiси в бронюваннi, якi сервicи додати
        public async Task<Result> SaveReservationAsync(Booking booking)
        {
            try
            {
                if (booking.Services is null)
                    return await AddReservationAsync(booking);

                var services = await _context.Services
                .Where(s => booking.Services.Select(x => x.Id).Contains(s.Id))
                .ToListAsync();

                booking.Services = services;

                return await AddReservationAsync(booking);
            }
            catch
            {
                return Result.UnsuccessResult("Failed adding");
            }
        }


        //Зберегти запис о бронюваннi в базу данних
        private async Task<Result> AddReservationAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return Result.SuccessResult();
        }

        //Перевiрка на доступнicть бронювання по времени
        public async Task<bool> IsAvaibleTime(Booking booking)
        {
            var query = _context.Bookings.Where(b => b.ConferenceRoomId == booking.ConferenceRoomId &&
            (booking.StartTime < b.EndTime && booking.EndTime > b.StartTime));


            if (query.Any())
                return false;

            return true;
        }

        //Усi конференс зали якi доступнi
        public async Task<IEnumerable<ConferenceRoom>> AvaibleConferenceRoom(DateTime startTime, DateTime endTime, int capacity)
        {
            var bookedRoomIds = _context.Bookings.Where(x => startTime < x.EndTime && endTime > x.StartTime)
            .Select(x => x.ConferenceRoomId);

            var rooms = _context.ConferenceRooms.Where(x => x.Capacity >=  capacity && !bookedRoomIds.Contains(x.Id));

            return rooms;
        }
    }
}
