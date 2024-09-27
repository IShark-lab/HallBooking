using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Entities
{
    public class Service
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
