using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string? Name { get; set; }

        public List<WorkspaceAmenity> WorkspaceAmenities { get; set; } = new();
    }
}