using HallBooking.BLL.Interfaces;
using HallBooking.DLA.Entities;
using HallBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Mapper
{
    //Мапер для переобразования з Booking в BookingDto
    public class BookingMapper : IMapper<BookingDto, Booking>
    {
        public BookingDto ToDto(Booking entity)
        {
            return new BookingDto
            {
                Id = entity.Id,
                ConferenceRoomId = entity.ConferenceRoomId,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };
        }

        public Booking ToEntity(BookingDto entityDto)
        {
            return new Booking
            {
                ConferenceRoomId = entityDto.ConferenceRoomId,
                StartTime = entityDto.StartTime,
                EndTime = entityDto.EndTime,
                Services = entityDto.ServicesId?.Select(id => new Service { Id = id }).ToList() ?? null
            };
        }
    }
}
