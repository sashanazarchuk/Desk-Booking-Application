using BookingServer.Domain.Entities;
using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string WorkspaceType { get; set; } = null!;
        public int Capacity { get; set; }
        public int RoomsCount { get; set; }

        public int WorkspaceId { get; set; }

 
    }

}
