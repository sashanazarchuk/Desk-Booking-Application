using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces.AI;
using BookingServer.Application.Query.ChatWithAI;
using BookingServer.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {

        private readonly IMediator mediator;
        public AIController(IMediator mediator)
        {
            this.mediator = mediator; 
        }


        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] UserMessageDto userMessage, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userMessage.Message))
                return BadRequest(new { error = "Message cannot be empty." });

            var response = await mediator.Send(new ChatWithAIQuery(userMessage.Message), cancellationToken);


            if (string.IsNullOrEmpty(response))
                return StatusCode(500, new { error = "AI returned an empty response." });

            return Ok(new { reply = response });
        }
 
    }


    

}