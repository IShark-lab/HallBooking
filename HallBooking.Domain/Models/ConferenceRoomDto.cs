﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallBooking.Domain.Models
{
    //ДТО для Presentation Layer
    public class ConferenceRoomDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Capacity { get; set; }
        [Required]
        public decimal? PriceHour { get; set; }
    }
}
