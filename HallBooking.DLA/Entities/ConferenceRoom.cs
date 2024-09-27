using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Entities
{
    public class ConferenceRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity {  get; set; }
        public decimal? PriceHour {  get; set; }

    }
}
