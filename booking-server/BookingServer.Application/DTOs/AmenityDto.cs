using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class AmenityDto
    {
        public int Id { get; set; }
        public string IconUrl { get; set; } = null!;
        public string? Name { get; set; }
    }
}
