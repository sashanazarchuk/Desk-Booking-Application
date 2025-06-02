using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingServer.Application.DTOs
{
    public class PatchBookingDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? RoomId { get; set; }

        public WorkspaceType? WorkspaceType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SeatsBooked { get; set; }

        [JsonIgnore]
        public WorkspaceDto? Workspace { get; set; }  
    }
}
