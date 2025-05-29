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

                // OpenSpace
                new Room
                {
                    Id = 1,
                    WorkspaceType = WorkspaceType.OpenSpace,
                    Capacity = 24,
                    RoomsCount = 1,
                    WorkspaceId = 1
                },

                // Private Rooms
                new Room
                {
                    Id = 2,
                    WorkspaceType = WorkspaceType.PrivateRoom,
                    Capacity = 1,
                    RoomsCount = 7,
                    WorkspaceId = 2
                },
                new Room
                {
                    Id = 3,
                    WorkspaceType = WorkspaceType.PrivateRoom,
                    Capacity = 2,
                    RoomsCount = 5,
                    WorkspaceId = 2
                },
                new Room
                {
                    Id = 4,
                    WorkspaceType = WorkspaceType.PrivateRoom,
                    Capacity = 10,
                    RoomsCount = 1,
                    WorkspaceId = 2
                },

                // Meeting Rooms
                new Room
                {
                    Id = 5,
                    WorkspaceType = WorkspaceType.MeetingRoom,
                    Capacity = 10,
                    RoomsCount = 4,
                    WorkspaceId = 3
                },
                new Room
                {
                    Id = 6,
                    WorkspaceType = WorkspaceType.MeetingRoom,
                    Capacity = 20,
                    RoomsCount = 1,
                    WorkspaceId = 3
                }
            );
        }
    }
}
