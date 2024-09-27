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
    //Мапер для переобразования з ConferenceRoom в ConferenceRoomDto
    public class ConfereceRoomMapper : IMapper<ConferenceRoomDto, ConferenceRoom>
    {
        public ConferenceRoomDto ToDto(ConferenceRoom entity)
        {
            return new ConferenceRoomDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Capacity = entity.Capacity,
                PriceHour = entity.PriceHour,
            };
        }

        public ConferenceRoom ToEntity(ConferenceRoomDto entityDto) 
        {
            return new ConferenceRoom
            {
                Name = entityDto.Name,
                Capacity = entityDto.Capacity,
                PriceHour = entityDto.PriceHour,
            };
        }

    }
}
