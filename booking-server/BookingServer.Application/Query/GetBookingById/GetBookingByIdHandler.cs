using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Exceptions;
using BookingServer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetBookingById
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, PatchBookingDto>
    {
        private readonly IBookingRepository repository;
        private readonly IMapper mapper;

        public GetBookingByIdHandler(IBookingRepository repository, IMapper mapper)
        {
            this.repository = repository;   
            this.mapper = mapper;
        }
        public async Task<PatchBookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await repository.GetBookingByIdAsync(request.id, cancellationToken)
            ?? throw new NotFoundException($"Booking with given id doesn't exist.");

            return mapper.Map<PatchBookingDto>(booking);
        }
    }
}