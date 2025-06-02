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

                //OpenSpace
                new WorkspacePhoto { Id = 1, Url = "/images/open-space-1.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 2, Url = "/images/open-space-2.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 3, Url = "/images/open-space-3.png", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 4, Url = "/images/open-space-4.png", WorkspaceId = 1 },

                //PrivateRoom
                new WorkspacePhoto { Id = 5, Url = "/images/private-room-1.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 6, Url = "/images/private-room-2.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 7, Url = "/images/private-room-3.png", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 8, Url = "/images/private-room-4.png", WorkspaceId = 2 },

                //MeetingRoom
                new WorkspacePhoto { Id = 9,  Url = "/images/meeting-room-1.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 10, Url = "/images/meeting-room-2.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 11, Url = "/images/meeting-room-3.png", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 12, Url = "/images/meeting-room-4.png", WorkspaceId = 3 }
            );
        }
    }
}
