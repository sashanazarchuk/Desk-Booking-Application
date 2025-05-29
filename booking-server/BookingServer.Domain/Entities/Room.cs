using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public WorkspaceType WorkspaceType { get; set; }
        public int Capacity { get; set; }  
        public int RoomsCount { get; set; } 
        
        public int WorkspaceId { get; set; }

        public Workspace Workspace { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = new();
    }
}