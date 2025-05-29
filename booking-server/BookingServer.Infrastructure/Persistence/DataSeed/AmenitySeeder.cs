using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class AmenitySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "Wi-Fi", IconUrl = "https://example.com/icons/wifi.png" },
                new Amenity { Id = 2, Name = "Coffee", IconUrl = "https://example.com/icons/coffee.png" },
                new Amenity { Id = 3, Name = "Game Room", IconUrl = "https://example.com/icons/game-room.png" }
            );
        }
    }
}