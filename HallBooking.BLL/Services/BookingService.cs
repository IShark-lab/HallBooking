using HallBooking.BLL.Interfaces;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using HallBooking.DLA.Repository;
using HallBooking.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IConferenceRoomRepository _conferenceRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper<BookingDto, Booking> _mapperBooking;
        private readonly IMapper<ConferenceRoomDto, ConferenceRoom> _mapperRoom;
        private readonly RentalPriceCalculator _rentalPriceCalculator;
        public BookingService(IBookingRepository repository, IMapper<BookingDto,Booking> mapper,IMapper<ConferenceRoomDto, ConferenceRoom> mapperRoom, 
            IConferenceRoomRepository conference, IServiceRepository serviceRepository, RentalPriceCalculator calc)
        {
            this._bookingRepository = repository;
            this._conferenceRepository = conference;
            this._serviceRepository = serviceRepository;    
            this._rentalPriceCalculator = calc;
            this._mapperBooking = mapper;
            this._mapperRoom = mapperRoom;
        }

        //Основна логiка резервацii з розрахунком та вiддачей результату
        public async Task<Result> ReservationAsync(BookingDto bookingDto)
        {
            var validation = await IsValid(bookingDto);
            if (!validation.Success)
                return validation;

            var entity = _mapperBooking.ToEntity(bookingDto);

            if (!await _bookingRepository.IsAvaibleTime(entity))
                return Result.UnsuccessResult("Time is not avaible");

            var resultCalculate = await CalculateAllAndChange(entity);

            if (!resultCalculate.Success)
                return resultCalculate;


            var result = await _bookingRepository.SaveReservationAsync(entity);

            if (result.Success)
                result.Message = $"Total price: {entity.TotalPrice}";


            return result;
        }

        //Валiдацiя заказу
        private async Task<Result> IsValid(BookingDto bookingDto)
        {
            if (bookingDto is null)
                return Result.UnsuccessResult("Is null");
            else if (bookingDto.StartTime > bookingDto.EndTime || bookingDto.StartTime == bookingDto.EndTime)
                return Result.UnsuccessResult("Wrong time");

            return Result.SuccessResult();
        }

        //розраховка цiни по ввiдним данним та одразу змiнюю
        private async Task<Result> CalculateAllAndChange(Booking entity)
        {
            var priceHourRoom = await _conferenceRepository.GetPriceById(entity.ConferenceRoomId);

            if (priceHourRoom is null)
                return Result.UnsuccessResult("Id Conference is not exist");

            IEnumerable<int> services = null;
            if (entity.Services != null)
                services = entity.Services.Select(s => s.Id);

            decimal? sumPriceServices = await _serviceRepository.GetSumPriceById(services) ?? 0m;

            decimal? rentFullPrice = _rentalPriceCalculator.CalculateRentalPrice(entity.StartTime, entity.EndTime, priceHourRoom);

            entity.TotalPrice = rentFullPrice + sumPriceServices;

            return Result.SuccessResult();
        }

        //Отримати усi зали якi пiдохять по умовi та переробити в Dto объект
        public async Task<IEnumerable<ConferenceRoomDto>> GetAllAvaibleRooms(DateTime startTime,DateTime endTime, int amountPeople)
        {
            var list = await _bookingRepository.AvaibleConferenceRoom(startTime, endTime, amountPeople);
            if (list.IsNullOrEmpty())
                return null;

            var listDto = list.Select(x => _mapperRoom.ToDto(x));

            return listDto;
        }
    }
}
