using BookingServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces
{
    public interface IWorkspaceRepository : IGenericRepository<Workspace>
    {

        Task<List<Workspace>> GetWorkspacesByCoworkingIdAsync(int coworkingId, CancellationToken cancellationToken);
    }
}
