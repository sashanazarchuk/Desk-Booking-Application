using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class CreateBookingDto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int RoomId { get; set; }
        public int SeatsToBook { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime EndDate  { get; set; }
    }
}
