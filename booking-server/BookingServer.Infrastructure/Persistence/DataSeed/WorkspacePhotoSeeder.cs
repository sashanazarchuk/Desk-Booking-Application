using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class WorkspacePhotoSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkspacePhoto>().HasData(

                // Open Space: WorkspaceIds 1, 3, 5, 8, 9
                new WorkspacePhoto { Id = 1, Url = "/images/open-space-1.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 2, Url = "/images/open-space-2.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 3, Url = "/images/open-space-3.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 4, Url = "/images/open-space-4.png", WorkspaceId = 1 },

                new WorkspacePhoto { Id = 5, Url = "/images/open-space-1.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 6, Url = "/images/open-space-2.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 7, Url = "/images/open-space-3.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 8, Url = "/images/open-space-4.png", WorkspaceId = 3 },

                new WorkspacePhoto { Id = 9, Url = "/images/open-space-1.png", WorkspaceId = 5 },
                new WorkspacePhoto { Id = 10, Url = "/images/open-space-2.png", WorkspaceId = 5 },
                new WorkspacePhoto { Id = 11, Url = "/images/open-space-3.png", WorkspaceId = 5 },
                new WorkspacePhoto { Id = 12, Url = "/images/open-space-4.png", WorkspaceId = 5 },

                new WorkspacePhoto { Id = 13, Url = "/images/open-space-1.png", WorkspaceId = 8 },
                new WorkspacePhoto { Id = 14, Url = "/images/open-space-2.png", WorkspaceId = 8 },
                new WorkspacePhoto { Id = 15, Url = "/images/open-space-3.png", WorkspaceId = 8 },
                new WorkspacePhoto { Id = 16, Url = "/images/open-space-4.png", WorkspaceId = 8 },

                new WorkspacePhoto { Id = 17, Url = "/images/open-space-1.png", WorkspaceId = 9 },
                new WorkspacePhoto { Id = 18, Url = "/images/open-space-2.png", WorkspaceId = 9 },
                new WorkspacePhoto { Id = 19, Url = "/images/open-space-3.png", WorkspaceId = 9 },
                new WorkspacePhoto { Id = 20, Url = "/images/open-space-4.png", WorkspaceId = 9 },

                // Private rooms: WorkspaceIds 2, 6, 10
                new WorkspacePhoto { Id = 21, Url = "/images/private-room-1.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 22, Url = "/images/private-room-2.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 23, Url = "/images/private-room-3.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 24, Url = "/images/private-room-4.png", WorkspaceId = 2 },

                new WorkspacePhoto { Id = 25, Url = "/images/private-room-1.png", WorkspaceId = 6 },
                new WorkspacePhoto { Id = 26, Url = "/images/private-room-2.png", WorkspaceId = 6 },
                new WorkspacePhoto { Id = 27, Url = "/images/private-room-3.png", WorkspaceId = 6 },
                new WorkspacePhoto { Id = 28, Url = "/images/private-room-4.png", WorkspaceId = 6 },

                new WorkspacePhoto { Id = 29, Url = "/images/private-room-1.png", WorkspaceId = 10 },
                new WorkspacePhoto { Id = 30, Url = "/images/private-room-2.png", WorkspaceId = 10 },
                new WorkspacePhoto { Id = 31, Url = "/images/private-room-3.png", WorkspaceId = 10 },
                new WorkspacePhoto { Id = 32, Url = "/images/private-room-4.png", WorkspaceId = 10 },

                // Meeting rooms: WorkspaceIds 4, 7
                new WorkspacePhoto { Id = 33, Url = "/images/meeting-room-1.png", WorkspaceId = 4 },
                new WorkspacePhoto { Id = 34, Url = "/images/meeting-room-2.png", WorkspaceId = 4 },
                new WorkspacePhoto { Id = 35, Url = "/images/meeting-room-3.png", WorkspaceId = 4 },
                new WorkspacePhoto { Id = 36, Url = "/images/meeting-room-4.png", WorkspaceId = 4 },

                new WorkspacePhoto { Id = 37, Url = "/images/meeting-room-1.png", WorkspaceId = 7 },
                new WorkspacePhoto { Id = 38, Url = "/images/meeting-room-2.png", WorkspaceId = 7 },
                new WorkspacePhoto { Id = 39, Url = "/images/meeting-room-3.png", WorkspaceId = 7 },
                new WorkspacePhoto { Id = 40, Url = "/images/meeting-room-4.png", WorkspaceId = 7 }
            );
        }
    }
}
