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
                new WorkspacePhoto { Id = 1, Url = "https://example.com/photos/workspace1.jpg", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 2, Url = "https://example.com/photos/workspace1.jpg", WorkspaceId = 1 },
                new WorkspacePhoto { Id = 3, Url = "https://example.com/photos/workspace1.jpg", WorkspaceId = 1 },

                new WorkspacePhoto { Id = 4, Url = "https://example.com/photos/workspace2.jpg", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 5, Url = "https://example.com/photos/workspace2.jpg", WorkspaceId = 2 },
                new WorkspacePhoto { Id = 6, Url = "https://example.com/photos/workspace2.jpg", WorkspaceId = 2 },

                new WorkspacePhoto { Id = 7, Url = "https://example.com/photos/workspace3.jpg", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 8, Url = "https://example.com/photos/workspace3.jpg", WorkspaceId = 3 },
                new WorkspacePhoto { Id = 9, Url = "https://example.com/photos/workspace3.jpg", WorkspaceId = 3 }

            );
        }
    }
}
