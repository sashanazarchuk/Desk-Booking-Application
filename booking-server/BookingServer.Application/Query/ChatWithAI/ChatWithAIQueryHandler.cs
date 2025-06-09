using BookingServer.Application.Interfaces.AI;
using BookingServer.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.ChatWithAI
{
    public class ChatWithAIQueryHandler : IRequestHandler<ChatWithAIQuery, string>
    {

        private readonly IAIService service;

        public ChatWithAIQueryHandler(IAIService service)
        {
            this.service = service; 
        }

        public async Task<string> Handle(ChatWithAIQuery request, CancellationToken cancellationToken)
        {
            return await service.GetResponseAsync(request.UserMessage, cancellationToken);
        }
    }
}