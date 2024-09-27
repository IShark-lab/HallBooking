using HallBooking.BLL.Interfaces;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using HallBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapperServices _mapper;

        public ServicesService(IServiceRepository repository, IMapperServices mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        //Отримати усi сервiси з пагiнацiей
        public async Task<IEnumerable<ServiceDto>> GetAllServices(int page, int pageSize)
        {
            var result = await _repository.GetAllServicesAsync(page, pageSize);
            if (result is null)
                return null;

            var resultDto = result.Select(x => _mapper.ToDtoWithData(x));

            return resultDto;
        }
    }
}
