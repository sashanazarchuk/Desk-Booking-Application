using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class WorkspaceAmenitySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkspaceAmenity>().HasData(
                
                //OpenSpace
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 2 },
               
                //PrivateRoom
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 6 },
                
                //MeetingRoom
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 6 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 7 }
            );
        }
    }
}
