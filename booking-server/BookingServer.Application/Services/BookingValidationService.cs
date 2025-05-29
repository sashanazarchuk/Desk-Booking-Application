using BookingServer.Application.DTOs.Models;
using BookingServer.Application.Interfaces;
using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Services
{
    public class BookingValidationService : IBookingValidationService
    {
        private readonly IBookingRepository repository;

        public BookingValidationService(IBookingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> RoomExists(int roomId, CancellationToken ct)
        {
            var room = await repository.GetRoomByIdAsync(roomId, ct);
            return room != null;
        }

        public async Task<bool> IsBookingDurationValid(int roomId, DateTime startDate, DateTime endDate, CancellationToken ct)
        {
            var room = await repository.GetRoomByIdAsync(roomId, ct);
            if (room == null) return false;

            if (endDate <= startDate) return false;

            var duration = endDate - startDate;
            TimeSpan maxDuration = room.WorkspaceType switch
            {
                WorkspaceType.OpenSpace => TimeSpan.FromDays(30),
                WorkspaceType.PrivateRoom => TimeSpan.FromDays(30),
                WorkspaceType.MeetingRoom => TimeSpan.FromDays(1),
                _ => TimeSpan.Zero
            };

            return duration <= maxDuration;
        }

        public async Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, CancellationToken ct)
        {
            var reservation = new RoomReservation
            {
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate
            };

            return await repository.IsRoomAvailableAsync(reservation, ct);
        }

        public async Task<bool> IsNotDoubleBookingForSameUser(string email, DateTime startDate, DateTime endDate, CancellationToken ct)
        {
            return !await repository.IsOverlappingBookingAsync(email, startDate, endDate, ct);
        }
    }
}
