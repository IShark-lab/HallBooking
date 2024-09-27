using HallBooking.BLL.Interfaces;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using HallBooking.DLA.Repository;
using HallBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Services
{
    public class ConferenceRoomService : IConferenceRoomService
    {
        private readonly IConferenceRoomRepository _repository;
        private readonly IMapper<ConferenceRoomDto, ConferenceRoom> _mapper;

        public ConferenceRoomService(IConferenceRoomRepository repository, IMapper<ConferenceRoomDto, ConferenceRoom> mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        //Створити зал
        public async Task<int?> CreateAsync(ConferenceRoomDto conferenceDto)
        {
            if (conferenceDto is null)
                return null;

            var conference = _mapper.ToEntity(conferenceDto);

            int? idNewConferece;

            try
            {
                return idNewConferece = await _repository.CreateAsync(conference);
            }
            catch
            {
                return null;
            }
        }

        //Видалити зал
        public async Task<Result> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        //Обновити зал
        public async Task<Result> UpdateAsync(int id, ConferenceRoomDto entityDto)
        {
            if (entityDto.Id != id)
                return new Result() { Message = "Wrong Id", Success = false };

            var entity = _mapper.ToEntity(entityDto);
            entity.Id = entityDto.Id;

            return await _repository.UpdateAsync(id, entity);
        }

        


    }
}
