using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class CoworkingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Image { get;set; } = null!;   
        public int OpenSpaceCount { get; set; }
        public int PrivateRoomCount { get; set; }
        public int MeetingRoomCount { get; set; }
    }
}
