using HallBooking.DLA.EF;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Repository
{
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private readonly HallBookingContext _context;

        public ConferenceRoomRepository(HallBookingContext context)
        {
            this._context = context;
        }


        //Створити конферес руму та вiддае id конференц руми
        public async Task<int?> CreateAsync(ConferenceRoom entity)
        {
            await _context.ConferenceRooms.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        //Видалити конферес зал та отримати результат
        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await _context.ConferenceRooms.FindAsync(id);
            try
            {
                _context.ConferenceRooms.Remove(entity);
                await _context.SaveChangesAsync();
                return Result.SuccessResult("Delete succsess");
            }
            catch
            {
                return Result.UnsuccessResult("Unsuccsess delete");
            }
        }

        //Обновити конференс зал з результатом
        public async Task<Result> UpdateAsync(int id, ConferenceRoom entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Result.SuccessResult("Updated");
            }
            catch
            {
                return Result.UnsuccessResult("Error update");
            }

        }
        //Отримати цiну залу по id
        public async Task<decimal?> GetPriceById(int id)
        {
            var entity = await _context.ConferenceRooms.FindAsync(id);

            return entity?.PriceHour;
        }

        

    }
}
