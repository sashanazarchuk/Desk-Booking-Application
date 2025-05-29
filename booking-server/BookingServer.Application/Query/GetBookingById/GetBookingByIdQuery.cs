using BookingServer.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetBookingById
{
    public record GetBookingByIdQuery(int id) : IRequest<PatchBookingDto>;
}
