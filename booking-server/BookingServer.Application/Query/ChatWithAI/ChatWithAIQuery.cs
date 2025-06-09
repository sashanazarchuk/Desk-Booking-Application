using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.ChatWithAI
{
    public record ChatWithAIQuery(string UserMessage) : IRequest<string>;
  
}
