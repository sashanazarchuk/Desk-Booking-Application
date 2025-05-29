using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces
{
    public interface IBookingValidationService
    {
        Task<bool> RoomExists(int roomId, CancellationToken ct);
        Task<bool> IsBookingDurationValid(int roomId, DateTime startDate, DateTime endDate, CancellationToken ct);
        Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, CancellationToken ct);
        Task<bool> IsNotDoubleBookingForSameUser(string email, DateTime startDate, DateTime endDate, CancellationToken ct);
    }
}
