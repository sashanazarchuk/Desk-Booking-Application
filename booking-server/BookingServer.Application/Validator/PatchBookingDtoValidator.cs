using BookingServer.Application.DTOs.Models;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using BookingServer.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Validator
{
    public class PatchBookingDtoValidator : AbstractValidator<PatchBookingDto>
    {
        private readonly IBookingValidationService validationService;

        public PatchBookingDtoValidator(IBookingValidationService validationService)
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
                .GreaterThan(DateTime.Now).WithMessage("Start date and time must be greater than current date and time.")
                .When(x => x.StartDate.HasValue);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date and time is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date and time must be greater than start date and time.")
                .When(x => x.EndDate.HasValue && x.StartDate.HasValue);

            RuleFor(x => x.SeatsBooked)
                .LessThanOrEqualTo(24)
                .WithMessage("The number of reserved seats cannot exceed 24.")
                .When(x => x.SeatsBooked.HasValue && x.WorkspaceType == WorkspaceType.OpenSpace);


            RuleFor(x => x.RoomId)
                .MustAsync(async (roomId, ct) =>
                {
                    if (roomId == null)
                        return true;

                    return await validationService.RoomExists(roomId.Value, ct);
                })
                .WithMessage("Selected room does not exist.")

                .DependentRules(() =>
                {
                    RuleFor(x => x)
                        .MustAsync(async (dto, ct) =>
                        {
                            if (dto.RoomId == null || dto.StartDate == null || dto.EndDate == null)
                                return true;

                            return await validationService.IsBookingDurationValid(
                            dto.RoomId.Value, dto.StartDate.Value, dto.EndDate.Value, ct);
                        })
                        .WithMessage("The booking period is incorrect. Make sure the end date is after the start date.");
                });
        }

    }
}