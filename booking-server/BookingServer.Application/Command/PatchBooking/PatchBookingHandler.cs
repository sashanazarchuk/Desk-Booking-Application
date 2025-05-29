using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Exceptions;
using BookingServer.Application.Interfaces;
using BookingServer.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Command.UpdateBooking
{
    public class PatchBookingHandler : IRequestHandler<PatchBookingCommand, BookingDto>
    {
        private readonly IBookingRepository repository;
        private readonly IMapper mapper;
        public PatchBookingHandler(IBookingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<BookingDto> Handle(PatchBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await repository.GetBookingByIdAsync(request.Id, cancellationToken);
            if (booking == null)
                throw new NotFoundException($"Booking with ID {request.Id} not found.");

            var dto = mapper.Map<PatchBookingDto>(booking);

            
            request.PatchDocument.ApplyTo(dto);

       
            if (dto.RoomId.HasValue)
            {
                var room = await repository.GetRoomByIdAsync(dto.RoomId.Value, cancellationToken);
                if (room == null)
                    throw new NotFoundException($"Room with ID {dto.RoomId.Value} was not found.");

           
                if (room.WorkspaceType != WorkspaceType.OpenSpace)
                {
                    dto.SeatsBooked = 1;
                }
            }

            dto.Workspace = null!;

            mapper.Map(dto, booking);

            await repository.PatchBookingAsync(booking, cancellationToken);

            return mapper.Map<BookingDto>(booking);
        }
    }
}
