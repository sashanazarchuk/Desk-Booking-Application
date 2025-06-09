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
    public class CoworkingRepository : ICoworkingRepository
    {
        private readonly BookingDbContext context;

        public CoworkingRepository(BookingDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Coworking>> GetAllAsync(CancellationToken cancellationToken)
        {
            var coworkings = await context.Coworkings
                .Include(w=>w.Workspaces)
                    .ThenInclude(w=>w.Rooms)
                .ToListAsync(cancellationToken);
            return coworkings;
        }

        public async Task<Coworking?> GetCoworkingByIdAsync(int id, CancellationToken cancellationToken)
        {
            var coworking = await context.Coworkings
                .Include(w => w.Workspaces).FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

            return coworking;
        }
    }
}
