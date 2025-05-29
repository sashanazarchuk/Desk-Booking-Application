using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using MediatR;
using BookingServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingServer.Domain.Enum;
using BookingServer.Application.DTOs.Models;
using BookingServer.Application.Exceptions;

namespace BookingServer.Application.Command.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        private readonly IBookingRepository repository;

        private readonly IMapper mapper;

        public CreateBookingCommandHandler(IBookingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {

            var room = await repository.GetRoomByIdAsync(request.dto.RoomId, cancellationToken);
            if (room == null)
                throw new NotFoundException($"Room with ID {request.dto.RoomId} was not found.");

             
            if (room.WorkspaceType == WorkspaceType.OpenSpace)
            {
                var availability = new OpenSpaceAvailability
                {
                    RoomId = request.dto.RoomId,
                    StartDate = request.dto.StartDate,
                    EndDate = request.dto.EndDate,
                    SeatsToBook = request.dto.SeatsToBook
                };

                var isAvailable = await repository.CheckOpenSpaceAvailabilityAsync(availability, cancellationToken);
                if (!isAvailable)
                    throw new BusinessException($"There are no available seats in OpenSpace for the selected number of seats: {request.dto.SeatsToBook}.");
            }
            else
            {
                var reservation = new RoomReservation
                {
                    RoomId = request.dto.RoomId,
                    StartDate = request.dto.StartDate,
                    EndDate = request.dto.EndDate
                };

                var isReserved = await repository.IsRoomAvailableAsync(reservation, cancellationToken);
                if (!isReserved)
                    throw new BusinessException($"Room is not available in the selected period");
            }

            var booking = new Booking
            {
                Name = request.dto.Name,
                Email = request.dto.Email,
                RoomId = request.dto.RoomId,
                StartDate = request.dto.StartDate,
                EndDate = request.dto.EndDate,
                SeatsBooked = room.WorkspaceType == WorkspaceType.OpenSpace ? request.dto.SeatsToBook : 1
            };

            var created = await repository.CreateBookingAsync(booking, cancellationToken);
            return mapper.Map<BookingDto>(created);
        }
    }
}