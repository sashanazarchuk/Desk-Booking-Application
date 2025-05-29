using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetAllBookings
{
    public record GetAllBookingsQuery: IRequest<List<BookingDto>>
    {
    }
}
