using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class MidiaSocialValidator : AbstractValidator<MidiaSocial>
    {
        public MidiaSocialValidator()
        {
            RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.URL)
             .NotEmpty().WithMessage("The URL is empty.")
             .NotNull().WithMessage("The URL is null.");

            RuleFor(c => c.Clinic)
            .NotEmpty().WithMessage("The Clinic is empty.")
            .NotNull().WithMessage("The Clinic is null.");

        }
    }
}