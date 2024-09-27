using HallBooking.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.BLL.Services
{
    //Все це паттерн стратегiя для аналiзу як разраховувати цiни 

    public class StandardHoursStrategy : IPriceStrategy
    {
        public decimal? CalculatePrice(DateTime time, decimal? basePrice) => basePrice;

        public bool IsApplicable(DateTime time) => time.Hour >= 9 && time.Hour < 18;
    }
    public class EveningHoursStrategy : IPriceStrategy
    {
        public decimal? CalculatePrice(DateTime time, decimal? basePrice) => basePrice * 0.8m;

        public bool IsApplicable(DateTime time) => time.Hour >= 18 && time.Hour < 23;
    }

    public class MorningHoursStrategy : IPriceStrategy
    {
        public decimal? CalculatePrice(DateTime time, decimal? basePrice) => basePrice * 0.9m;

        public bool IsApplicable(DateTime time) => time.Hour >= 6 && time.Hour < 9;
    }

    public class PeakHoursStrategy : IPriceStrategy
    {
        public decimal? CalculatePrice(DateTime time, decimal? basePrice) => basePrice * 1.15m;

        public bool IsApplicable(DateTime time) => time.Hour >= 12 && time.Hour < 14;
    }



    //Класс, який розраховуе
    public class RentalPriceCalculator
    {
        private readonly IEnumerable<IPriceStrategy> _strategies;

        public RentalPriceCalculator(IEnumerable<IPriceStrategy> strategies)
        {
            _strategies = strategies;
        }

        //Перевiряемо кожний час та розраховую цiну в залижку вiд часу
        public decimal? CalculateRentalPrice(DateTime startTime, DateTime endTime, decimal? basePrice)
        {
            decimal? totalPrice = 0m;

            for (var currentTime = startTime; currentTime < endTime; currentTime = currentTime.AddHours(1))
            {
                totalPrice += GetPriceForHour(currentTime, basePrice);
            }

            return totalPrice;
        }

        //Отримую цiну за час
        private decimal? GetPriceForHour(DateTime time, decimal? basePrice)
        {
            foreach (var strategy in _strategies)
            {
                if (strategy.IsApplicable(time))
                {
                    return strategy.CalculatePrice(time, basePrice);
                }
            }
            return 0;
        }
    }


}
