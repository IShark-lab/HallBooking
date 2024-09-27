using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HallBooking.Domain.Models
{
    //ДТО для Presentation Layer
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


}
