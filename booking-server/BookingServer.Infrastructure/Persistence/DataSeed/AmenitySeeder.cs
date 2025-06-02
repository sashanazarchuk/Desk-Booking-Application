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
                new Amenity { Id = 1, Name = "Wi-Fi", IconUrl = "/icons/wifi.svg" },
                new Amenity { Id = 2, Name = "Coffee", IconUrl = "/icons/coffee.svg" },
                new Amenity { Id = 3, Name = "Game Room", IconUrl = "/icons/gamepad.svg" },
                new Amenity { Id = 4, Name = "Air Conditioning", IconUrl = "/icons/air-conditioning.svg" },
                new Amenity { Id = 5, Name = "Armchair", IconUrl = "/icons/armchair.svg" },
                new Amenity { Id = 6, Name = "Headphones", IconUrl = "/icons/headphones.svg" },
                new Amenity { Id = 7, Name = "Microphone", IconUrl = "/icons/microphone.svg" },
                new Amenity { Id = 8, Name = "User", IconUrl = "/icons/user.svg" }
            );
        }
    }
}