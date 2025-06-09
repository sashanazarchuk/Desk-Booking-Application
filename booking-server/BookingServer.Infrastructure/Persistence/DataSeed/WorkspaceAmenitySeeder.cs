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

                // Open Space: WorkspaceIds 1, 3, 5, 8, 9
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 2 },
                new WorkspaceAmenity { WorkspaceId = 1, AmenityId = 1 },

                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 2 },
                new WorkspaceAmenity { WorkspaceId = 3, AmenityId = 1 },

                new WorkspaceAmenity { WorkspaceId = 5, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 5, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 5, AmenityId = 2 },
                new WorkspaceAmenity { WorkspaceId = 5, AmenityId = 1 },

                new WorkspaceAmenity { WorkspaceId = 8, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 8, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 8, AmenityId = 2 },
                new WorkspaceAmenity { WorkspaceId = 8, AmenityId = 1 },

                new WorkspaceAmenity { WorkspaceId = 9, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 9, AmenityId = 3 },
                new WorkspaceAmenity { WorkspaceId = 9, AmenityId = 2 },
                new WorkspaceAmenity { WorkspaceId = 9, AmenityId = 1 },

                // Private rooms: WorkspaceIds 2, 6, 10
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 2, AmenityId = 6 },

                new WorkspaceAmenity { WorkspaceId = 6, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 6, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 6, AmenityId = 6 },

                new WorkspaceAmenity { WorkspaceId = 10, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 10, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 10, AmenityId = 6 },

                // Meeting rooms: WorkspaceIds 4, 7
                new WorkspaceAmenity { WorkspaceId = 4, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 4, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 4, AmenityId = 6 },
                new WorkspaceAmenity { WorkspaceId = 4, AmenityId = 7 },

                new WorkspaceAmenity { WorkspaceId = 7, AmenityId = 1 },
                new WorkspaceAmenity { WorkspaceId = 7, AmenityId = 4 },
                new WorkspaceAmenity { WorkspaceId = 7, AmenityId = 6 },
                new WorkspaceAmenity { WorkspaceId = 7, AmenityId = 7 }
            );
        }
    }
}
