using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoomId { get; set; }
        public Room Rooms { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int SeatsBooked { get; set; } = 1;


    }
}
