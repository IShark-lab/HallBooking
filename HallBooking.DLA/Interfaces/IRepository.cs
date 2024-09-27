using HallBooking.DLA.Entities;
using HallBooking.DLA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Interfaces
{
    //Усi iнтерфейси

    public interface IRepository<T>
    {
        Task<int?> CreateAsync(T entity);
        Task<Result> UpdateAsync(int id, T entity);
        Task<Result> DeleteAsync(int id);

    }

    public interface IConferenceRoomRepository : IRepository<ConferenceRoom>
    {
        Task<decimal?> GetPriceById(int id);
    }

    public interface IBookingRepository
    {
        Task<Result> SaveReservationAsync(Booking booking);
        Task<bool> IsAvaibleTime(Booking booking);
        Task<IEnumerable<ConferenceRoom>> AvaibleConferenceRoom(DateTime startTime, DateTime endTime, int capacity);
    }
    public interface IServiceRepository
    {
        Task<decimal?> GetSumPriceById(IEnumerable<int> id);
        Task<IEnumerable<Service>> GetAllServicesAsync(int page, int pageSize);
    }

}
