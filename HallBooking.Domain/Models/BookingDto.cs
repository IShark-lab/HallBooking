using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HallBooking.Domain.Models
{
    //ДТО для Presentation Layer
    public class BookingDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public int ConferenceRoomId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public List<int>? ServicesId { get; set; } = new List<int>();
        [JsonIgnore]
        public decimal TotalPrice { get; set; }
    }
}
