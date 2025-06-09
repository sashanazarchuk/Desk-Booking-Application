using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces.AI
{
    public interface IAIService
    {
        Task<string> GetResponseAsync(string userMessage, CancellationToken cancellationToken);
     }
}
