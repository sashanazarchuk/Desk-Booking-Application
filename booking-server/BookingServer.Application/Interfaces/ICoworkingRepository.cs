using BookingServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces
{
    public interface ICoworkingRepository : IGenericRepository<Coworking>
    {
        Task<Coworking?> GetCoworkingByIdAsync(int id, CancellationToken cancellationToken);
    }
}
