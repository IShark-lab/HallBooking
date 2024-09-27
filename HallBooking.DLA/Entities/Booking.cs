using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.DLA.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int ConferenceRoomId { get; set; }
        public ConferenceRoom ConferenceRoom { get; set; }

        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();
        public decimal? TotalPrice {  get; set; }
    }

}

