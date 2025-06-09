using BookingServer.Domain.Entities;
using BookingServer.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class RoomSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
            // Coworking 1 – Workspace 1 (Open Space), Workspace 2 (Private rooms)
                new Room { Id = 1, WorkspaceType = WorkspaceType.OpenSpace, Capacity = 24, RoomsCount = 1, WorkspaceId = 1 },
                new Room { Id = 2, WorkspaceType = WorkspaceType.PrivateRoom, Capacity = 1, RoomsCount = 7, WorkspaceId = 2 },
                new Room { Id = 3, WorkspaceType = WorkspaceType.PrivateRoom, Capacity = 3, RoomsCount = 2, WorkspaceId = 2 },

            // Coworking 2 – Workspace 3 (Open Space), Workspace 4 (Meeting rooms)
                new Room { Id = 4, WorkspaceType = WorkspaceType.OpenSpace, Capacity = 16, RoomsCount = 1, WorkspaceId = 3 },
                new Room { Id = 5, WorkspaceType = WorkspaceType.MeetingRoom, Capacity = 8, RoomsCount = 2, WorkspaceId = 4 },
                new Room { Id = 6, WorkspaceType = WorkspaceType.MeetingRoom, Capacity = 14, RoomsCount = 1, WorkspaceId = 4 },

            // Coworking 3 – Workspace 5 (Open Space), Workspace 6 (Private rooms)
                new Room { Id = 7, WorkspaceType = WorkspaceType.OpenSpace, Capacity = 10, RoomsCount = 1, WorkspaceId = 5 },
                new Room { Id = 8, WorkspaceType = WorkspaceType.PrivateRoom, Capacity = 2, RoomsCount = 3, WorkspaceId = 6 },

            // Coworking 4 – Workspace 7 (Meeting rooms), Workspace 8 (Open Space)
                new Room { Id = 9, WorkspaceType = WorkspaceType.MeetingRoom, Capacity = 12, RoomsCount = 2, WorkspaceId = 7 },
                new Room { Id = 10, WorkspaceType = WorkspaceType.OpenSpace, Capacity = 20, RoomsCount = 1, WorkspaceId = 8 },

            // Coworking 5 – Workspace 9 (Open Space), Workspace 10 (Private rooms)
                new Room { Id = 11, WorkspaceType = WorkspaceType.OpenSpace, Capacity = 15, RoomsCount = 1, WorkspaceId = 9 },
                new Room { Id = 12, WorkspaceType = WorkspaceType.PrivateRoom, Capacity = 2, RoomsCount = 2, WorkspaceId = 10 },
                new Room { Id = 13, WorkspaceType = WorkspaceType.PrivateRoom, Capacity = 4, RoomsCount = 1, WorkspaceId = 10 }
            );

        }
    }
}