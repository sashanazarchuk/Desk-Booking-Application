using BookingServer.Application.Exceptions;
using BookingServer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Command.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
    {

        private readonly IBookingRepository repository;
        public DeleteBookingCommandHandler(IBookingRepository repository) 
        {
            this.repository = repository;        
        }
        public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await repository.GetBookingByIdAsync(request.Id, cancellationToken);

            if (booking is null)
                throw new NotFoundException($"Booking with ID {request.Id} not found.");
             
            await repository.DeleteBookingAsync(booking, cancellationToken);
        }
    }
}