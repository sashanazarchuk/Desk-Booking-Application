using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class WorkspaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int CoworkingId { get; set; }
         
        public List<RoomDto> Rooms { get; set; } = new();
        public List<WorkspacePhotoDto> Photos { get; set; } = new();
        public List<AmenityDto> Amenities { get; set; } = new();
    }


}
