using BookingServer.Application.Interfaces;
using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.Repositories
{
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly BookingDbContext context;

        public WorkspaceRepository(BookingDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Workspace>> GetAllAsync(CancellationToken cancellationToken)
        {
            var workspaces = await context.Workspaces
                .Include(w => w.Rooms)
                .Include(w => w.Photos)
                .Include(w => w.WorkspaceAmenities)
                    .ThenInclude(wa => wa.Amenity)
                .ToListAsync();

            return workspaces;
        }

        public async Task<List<Workspace>> GetWorkspacesByCoworkingIdAsync(int coworkingId, CancellationToken cancellationToken)
        {

            return await context.Workspaces
                .Where(c => c.CoworkingId == coworkingId)
                .Include(w => w.Rooms)
                .Include(w => w.Photos)
                .Include(w => w.WorkspaceAmenities)
                    .ThenInclude(wa => wa.Amenity)
                .ToListAsync(cancellationToken);


        }
    }
}