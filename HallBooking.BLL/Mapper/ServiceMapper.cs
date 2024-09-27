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
    //Мапер для переобразования з Service в ServiceDto
    public class ServiceMapper : IMapperServices
    {
        public ServiceDto ToDto(Service entity)
        {
            return new ServiceDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
            };
        }

        public Service ToEntity(ServiceDto entityDto)
        {
            return new Service()
            {
                Id = entityDto.Id
            };
        }
        public Service ToEntityWithData(ServiceDto entityDto)
        {
            return new Service()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                Price = entityDto.Price
            };
        }
        public ServiceDto ToDtoWithData(Service entity)
        {
            return new ServiceDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }


    }
}
