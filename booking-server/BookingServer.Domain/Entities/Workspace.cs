using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CoworkingId { get; set; }
        public Coworking Coworking { get; set; }


        public List<Room> Rooms { get; set; } = new();
        public List<WorkspacePhoto> Photos { get; set; } = new();
        public List<WorkspaceAmenity> WorkspaceAmenities { get; set; } = new();
    }
}