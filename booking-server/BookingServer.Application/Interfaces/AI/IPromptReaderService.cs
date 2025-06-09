using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Interfaces.AI
{
    public interface IPromptReaderService
    {
        Task<string> GetSystemPromptAsync(CancellationToken cancellationToken);
        Task<string> GenerateDynamicPromptAsync(CancellationToken cancellationToken);

    }
}
