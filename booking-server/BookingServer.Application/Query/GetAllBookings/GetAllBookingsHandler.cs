using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using BookingServer.Application.Query.Workspace;
using BookingServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetAllBookings
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsQuery, List<BookingDto>>
    {
        private readonly IBookingRepository repository;
        private readonly IMapper mapper;
        public GetAllBookingsHandler(IBookingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        public async Task<List<BookingDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var booking = await repository.GetAllAsync(cancellationToken);

            return mapper.Map<List<BookingDto>>(booking);
        }
    }
}
