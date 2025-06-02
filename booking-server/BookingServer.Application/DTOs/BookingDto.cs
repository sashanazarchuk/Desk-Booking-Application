using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        
        public int RoomId { get; set; }
        public RoomDto Rooms{ get; set; } =null!;
                            
        public WorkspaceDto Workspace { get; set; } = null!;
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SeatsBooked { get; set; }
    }
}
