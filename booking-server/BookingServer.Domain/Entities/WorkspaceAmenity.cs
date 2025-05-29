using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class WorkspaceAmenity
    {
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; } = default!;

        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; } = default!;
    }
}