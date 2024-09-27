using HallBooking.DLA.Repository;
using HallBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Interfaces
{
    //Iнтерфейс для бiзнес логiки
    public interface IService<T>
    {
        Task<int?> CreateAsync(T entity);
        Task<Result> UpdateAsync(int id, T entity);
        Task<Result> DeleteAsync(int id);
    }

    public interface IConferenceRoomService : IService<ConferenceRoomDto>
    {

    }

    public interface IBookingService
    {
        Task<Result> ReservationAsync(BookingDto bookingDto);
        Task<IEnumerable<ConferenceRoomDto>> GetAllAvaibleRooms(DateTime startTime, DateTime endTime, int amountPeople);
    }
    public interface IServicesService
    {
        Task<IEnumerable<ServiceDto>> GetAllServices(int page, int pageSize);
        
    }

    public interface IPriceStrategy
    {
        decimal? CalculatePrice(DateTime time, decimal? basePrice);
        bool IsApplicable(DateTime time);
    }

}
