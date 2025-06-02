using BookingServer.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Command.UpdateBooking
{
    public class PatchBookingCommand:IRequest<BookingDto>
    {
        public int Id { get; set; }
        public JsonPatchDocument<PatchBookingDto> PatchDocument { get; set; }

        public PatchBookingCommand(int id, JsonPatchDocument<PatchBookingDto> patchDocument)
        {
            Id = id;
            PatchDocument = patchDocument;
        }
    }
}
