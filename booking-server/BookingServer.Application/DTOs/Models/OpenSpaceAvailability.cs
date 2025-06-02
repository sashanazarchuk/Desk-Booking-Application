﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs.Models
{
    public class OpenSpaceAvailability
    {
        public int RoomId { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public int SeatsToBook { get; init; }
    }
}
