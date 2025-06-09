using BookingServer.Application.Query.GetAllCoworkings;
using BookingServer.Application.Query.GetWorkspacesByCoworkingId;
using BookingServer.Application.Query.Workspace;
using BookingServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkingController : ControllerBase
    {

        private IMediator mediator;

        public CoworkingController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCoworkingsAsync()
        {
            var coworkings = await mediator.Send(new GetAllCoworkingsQuery());

            if (coworkings == null)
                return NotFound("No coworkings found.");

            return Ok(coworkings);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCoworkingsByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid coworking ID.");

            var workspaces = await mediator.Send(new GetWorkspacesByCoworkingIdQuery(id));

            if (workspaces == null || !workspaces.Any())
                return NotFound($"No workspaces found for coworking ID {id}.");

            return Ok(workspaces);
        }

    }
}
