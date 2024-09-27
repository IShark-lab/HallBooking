using HallBooking.DLA.Entities;
using HallBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Interfaces
{
    //Iнтерфейси для маппера
    public interface IMapper<TDto, TEntity>
    {
        TDto ToDto(TEntity entity);
        TEntity ToEntity(TDto entityDto);
    }
    
    public interface IMapperServices : IMapper<ServiceDto, Service>
    {
        Service ToEntityWithData(ServiceDto entityDto);
        ServiceDto ToDtoWithData(Service entity);
    }
}
