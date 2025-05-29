using BookingServer.Application.Query.Workspace;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {

        private readonly IMediator mediator;
        
        public WorkspaceController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var workspace = await mediator.Send(new GetAllWorkspacesQuery());

            return Ok(workspace);
        }
    }
}