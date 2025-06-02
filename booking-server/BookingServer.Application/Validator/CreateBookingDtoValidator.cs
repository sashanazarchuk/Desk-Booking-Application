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
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 60).WithMessage("Name must be between 2 and 60 characters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.StartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Start date and time is required.")
                .Must(date => date > DateTime.Now).WithMessage("Start date and time must be greater than current date and time.");

            RuleFor(x => x.EndDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("End date and time is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date and time must be greater than start date and time.");

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.RoomExists(dto.RoomId, ct))
                .WithMessage("Selected room does not exist.")
                .When(x => x.RoomId > 0);

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsBookingDurationValid(dto.RoomId, dto.StartDate, dto.EndDate, ct))
                .WithMessage("The booking period is incorrect.")
                .When(x => x.RoomId > 0 && x.StartDate != default && x.EndDate != default);

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsRoomAvailable(dto.RoomId, dto.StartDate, dto.EndDate, ct))
                .WithMessage("Room is not available in the selected period.")
                .When(x => x.RoomId > 0 && x.StartDate != default && x.EndDate != default);

            RuleFor(x => x)
                .MustAsync((dto, ct) => validationService.IsNotDoubleBookingForSameUser(dto.Email, dto.StartDate, dto.EndDate, ct))
                .WithMessage("You already have a booking in this period.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email) && x.StartDate != default && x.EndDate != default);

        }
    }
}