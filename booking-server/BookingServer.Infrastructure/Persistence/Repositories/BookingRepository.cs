using BookingServer.Application.DTOs.Models;
using BookingServer.Application.Interfaces;
using BookingServer.Domain.Entities;
using BookingServer.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext context;
        public BookingRepository(BookingDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync(CancellationToken cancellationToken)
        {
            var bookings = await context.Bookings
                .Include(c => c.Rooms)
                    .ThenInclude(w => w.Workspace)
                    .ThenInclude(w => w.Photos)
                .ToListAsync(cancellationToken);

            return bookings;
        }

        public async Task<Booking?> GetBookingByIdAsync(int id, CancellationToken cancellationToken)
        {
            var booking = await context.Bookings
                .Include(b => b.Rooms)
                    .ThenInclude(r => r.Workspace)
                        .ThenInclude(w => w.Photos)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            return booking;
        }

        public async Task PatchBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            context.Bookings.Update(booking);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Booking>> GetExpiredBookingsAsync(DateTime now, CancellationToken cancellationToken)
        {
            return await context.Bookings
                .Where(b => b.EndDate <= now)
                .ToListAsync(cancellationToken);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            context.Bookings.Add(booking);
            await context.SaveChangesAsync(cancellationToken);
            return booking;
        }



        public async Task<Room> GetRoomByIdAsync(int id, CancellationToken cancellationToken)
        {
            var rooms = await context.Rooms.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
            return rooms;
        }



        public async Task UpdateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            context.Rooms.Update(room);
            await context.SaveChangesAsync(cancellationToken);
        }


        public async Task<bool> CheckOpenSpaceAvailabilityAsync(OpenSpaceAvailability request, CancellationToken cancellationToken)
        {
            var room = await context.Rooms.FindAsync(request.RoomId);
            if (room == null)
                return false;

            if (room.WorkspaceType != WorkspaceType.OpenSpace)
                return true;

            var alreadyBookedSeats = await context.Bookings
                .Where(b => b.RoomId == request.RoomId &&
                            b.StartDate < request.EndDate &&
                            b.EndDate > request.StartDate)
                .SumAsync(b => b.SeatsBooked, cancellationToken);

            var availableSeats = room.Capacity - alreadyBookedSeats;

            return availableSeats >= request.SeatsToBook;
        }



        public async Task<bool> IsRoomAvailableAsync(RoomReservation request, CancellationToken cancellationToken)
        {
            var room = await context.Rooms.FindAsync(request.RoomId);
            if (room == null)
                return false;

            if (room.WorkspaceType != WorkspaceType.OpenSpace)
            {
                var overlappingBookingsCount = await context.Bookings
                    .CountAsync(b => b.RoomId == request.RoomId &&
                                     b.StartDate < request.EndDate &&
                                     b.EndDate > request.StartDate,
                                cancellationToken);

                if (overlappingBookingsCount >= room.RoomsCount)
                    return false;
            }

            return true;
        }


        public async Task<bool> IsOverlappingBookingAsync(string email, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await context.Bookings.AnyAsync(b =>
                b.Email == email &&
                b.StartDate < endDate &&
                b.EndDate > startDate,
                cancellationToken);
        }

    }
}