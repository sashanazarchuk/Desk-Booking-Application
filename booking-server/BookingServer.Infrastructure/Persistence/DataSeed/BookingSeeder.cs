using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class BookingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, Name = "Charlie", Email = "charlie@example.com", RoomId = 1, StartDate = new DateTime(2025, 6, 6), EndDate = new DateTime(2025, 6, 10) },
                new Booking { Id = 2, Name = "Diana", Email = "diana@example.com", RoomId = 3, StartDate = new DateTime(2025, 6, 2), EndDate = new DateTime(2025, 6, 4) },
                new Booking { Id = 3, Name = "Ethan", Email = "ethan@example.com", RoomId = 2, StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 13) },
                new Booking { Id = 4, Name = "Fiona", Email = "fiona@example.com", RoomId = 1, StartDate = new DateTime(2025, 6, 12), EndDate = new DateTime(2025, 6, 15) },
                new Booking { Id = 5, Name = "George", Email = "george@example.com", RoomId = 4, StartDate = new DateTime(2025, 6, 5), EndDate = new DateTime(2025, 6, 8) },
                new Booking { Id = 6, Name = "Hannah", Email = "hannah@example.com", RoomId = 3, StartDate = new DateTime(2025, 6, 9), EndDate = new DateTime(2025, 6, 11) },
                new Booking { Id = 7, Name = "Ian", Email = "ian@example.com", RoomId = 2, StartDate = new DateTime(2025, 6, 14), EndDate = new DateTime(2025, 6, 18) },
                new Booking { Id = 8, Name = "Julia", Email = "julia@example.com", RoomId = 1, StartDate = new DateTime(2025, 6, 20), EndDate = new DateTime(2025, 6, 22) },
                new Booking { Id = 9, Name = "Kevin", Email = "kevin@example.com", RoomId = 5, StartDate = new DateTime(2025, 6, 3), EndDate = new DateTime(2025, 6, 6) },
                new Booking { Id = 10, Name = "Laura", Email = "laura@example.com", RoomId = 4, StartDate = new DateTime(2025, 6, 7), EndDate = new DateTime(2025, 6, 9) },
                new Booking { Id = 11, Name = "Mike", Email = "mike@example.com", RoomId = 5, StartDate = new DateTime(2025, 6, 11), EndDate = new DateTime(2025, 6, 14) },
                new Booking { Id = 12, Name = "Nina", Email = "nina@example.com", RoomId = 3, StartDate = new DateTime(2025, 6, 15), EndDate = new DateTime(2025, 6, 17) },
                new Booking { Id = 13, Name = "Oscar", Email = "oscar@example.com", RoomId = 2, StartDate = new DateTime(2025, 6, 19), EndDate = new DateTime(2025, 6, 23) },
                new Booking { Id = 14, Name = "Paula", Email = "paula@example.com", RoomId = 4, StartDate = new DateTime(2025, 6, 20), EndDate = new DateTime(2025, 6, 25) },
                new Booking { Id = 15, Name = "Quinn", Email = "quinn@example.com", RoomId = 1, StartDate = new DateTime(2025, 6, 24), EndDate = new DateTime(2025, 6, 28) }
);
        }
    }
}
