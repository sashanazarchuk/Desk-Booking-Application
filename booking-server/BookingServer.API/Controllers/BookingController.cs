using BookingServer.Application.Command.CreateBooking;
using BookingServer.Application.Command.DeleteBooking;
using BookingServer.Application.Command.UpdateBooking;
using BookingServer.Application.DTOs;
using BookingServer.Application.Query.GetAllBookings;
using BookingServer.Application.Query.GetBookingById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookingServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<CreateBookingDto> createValidator;
        private readonly IValidator<PatchBookingDto> patchValidator;
        public BookingController(IMediator mediator, IValidator<CreateBookingDto> createValidator, IValidator<PatchBookingDto> patchValidator)
        {
            this.mediator = mediator;
            this.createValidator = createValidator;
            this.patchValidator = patchValidator;
        }


        [HttpPost()]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto, CancellationToken cancellationToken)
        {

            var validationResult = await createValidator.ValidateAsync(dto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await mediator.Send(new CreateBookingCommand(dto));

            return Created();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<PatchBookingDto> patchDoc, CancellationToken cancellationToken)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }


            var bookingDto = await mediator.Send(new GetBookingByIdQuery(id), cancellationToken);


            if (bookingDto == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(bookingDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var validationResult = await patchValidator.ValidateAsync(bookingDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await mediator.Send(new PatchBookingCommand(id, patchDoc), cancellationToken);

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteBookingCommand(id));
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GettAllBookings()
        {
            var booking = await mediator.Send(new GetAllBookingsQuery());
            return Ok(booking);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await mediator.Send(new GetBookingByIdQuery(id));
            return Ok(booking);
        }




    }
}