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
                new Booking
                {
                    Id = 1,
                    Name = "Alice",
                    Email = "alice@example.com",
                    RoomId = 1,
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 5)
                },
                new Booking
                {
                    Id = 2,
                    Name = "Bob",
                    Email = "bob@example.com",
                    RoomId = 2,
                    StartDate = new DateTime(2025, 6, 3),
                    EndDate = new DateTime(2025, 6, 7)
                }
            );
        }
    }
}
