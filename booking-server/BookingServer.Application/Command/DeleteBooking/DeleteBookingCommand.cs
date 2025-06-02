using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Command.DeleteBooking
{
    public record DeleteBookingCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;   
        }
    }
}
