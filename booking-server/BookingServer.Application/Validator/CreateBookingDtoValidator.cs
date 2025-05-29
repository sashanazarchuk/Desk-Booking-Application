using BookingServer.Application.Command.CreateBooking;
using BookingServer.Application.DTOs;
using BookingServer.Application.DTOs.Models;
using BookingServer.Application.Interfaces;
using BookingServer.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Validation
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        private readonly IBookingValidationService validationService;

        public CreateBookingDtoValidator(IBookingValidationService validationService)
        {
            this.validationService = validationService;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 60).WithMessage("Name must be between 2 and 60 characters.")
                .When(x => x.Name is not null);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .When(x => x.Email is not null);

            RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date and time is required.")
            .GreaterThan(DateTime.Now).WithMessage("Start date and time must be greater than current date and time.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date and time is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date and time must be greater than start date and time.");

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.RoomExists(dto.RoomId, ct))
                .WithMessage("Selected room does not exist.");

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsBookingDurationValid(dto.RoomId, dto.StartDate, dto.EndDate, ct))
                .WithMessage("The booking period is incorrect.");

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsRoomAvailable(dto.RoomId, dto.StartDate, dto.EndDate, ct))
                .WithMessage("Room is not available in the selected period.");

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsNotDoubleBookingForSameUser(dto.Email, dto.StartDate, dto.EndDate, ct))
                .WithMessage("You already have a booking in this period.");
        }
    }
}