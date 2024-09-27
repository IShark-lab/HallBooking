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
    public class ServicesRepository : IServiceRepository
    {
        //Контекст БД
        private readonly HallBookingContext _context;

        public ServicesRepository(HallBookingContext context)
        {
            this._context = context;
        }

        //Отримати сумму усiх додаткових услуг по id
        public async Task<decimal?> GetSumPriceById(IEnumerable<int> id)
        {
            try
            {
                decimal? sum = _context.Services.Where(x => id.Contains(x.Id)).Sum(x => x.Price);

                return sum;
            }
            catch
            {
                return null;
            }

        }
        //Отримати усi додатковi послуги
        public async Task<IEnumerable<Service>> GetAllServicesAsync(int page, int pageSize)
        {
            var query = _context.Services.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
