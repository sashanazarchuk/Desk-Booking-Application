using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AmenitySeeder.Seed(modelBuilder);
            WorkspaceSeeder.Seed(modelBuilder);
            RoomSeeder.Seed(modelBuilder);
            WorkspacePhotoSeeder.Seed(modelBuilder);
            WorkspaceAmenitySeeder.Seed(modelBuilder);
            BookingSeeder.Seed(modelBuilder);
            CoworkingSeeder.Seed(modelBuilder); 
        }
    }
}
