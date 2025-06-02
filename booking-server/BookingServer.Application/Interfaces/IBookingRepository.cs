using BookingServer.Application.Command.CreateBooking;
using BookingServer.Application.DTOs.Models;
using BookingServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<Booking?> GetBookingByIdAsync(int id, CancellationToken cancellationToken);
        Task PatchBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task DeleteBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task<List<Booking>> GetExpiredBookingsAsync(DateTime now, CancellationToken cancellationToken);
        Task<Booking> CreateBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task<Room> GetRoomByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateRoomAsync(Room room, CancellationToken cancellationToken);
        Task<bool> CheckOpenSpaceAvailabilityAsync(OpenSpaceAvailability request, CancellationToken cancellationToken);
        Task<bool> IsRoomAvailableAsync(RoomReservation request, CancellationToken cancellationToken);
        Task<bool> IsOverlappingBookingAsync(string email, DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}