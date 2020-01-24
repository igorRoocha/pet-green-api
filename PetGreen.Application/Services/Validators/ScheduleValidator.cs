using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator()
        {
            RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Day)
             .NotEmpty().WithMessage("The day is empty.")
             .NotNull().WithMessage("The day is null.");

            RuleFor(c => c.StartHour)
             .NotEmpty().WithMessage("The start hour is empty.")
             .NotNull().WithMessage("The start hour is null.");

            RuleFor(c => c.EndHour)
             .NotEmpty().WithMessage("The end hour is empty.")
             .NotNull().WithMessage("The end hour is null.");
        }
    }
}