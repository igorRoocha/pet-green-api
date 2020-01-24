using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class ClinicValidator : AbstractValidator<Clinic>
    {
        public ClinicValidator()
        {
             RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Name)
             .NotEmpty().WithMessage("The name is empty.")
             .NotNull().WithMessage("The name is null.");

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("The email is empty.")
            .NotNull().WithMessage("The email is null.");

            RuleFor(c => c.CreatedAt)
            .NotEmpty().WithMessage("The CreatedAt is empty.")
            .NotNull().WithMessage("The CreatedAt is null.");

            RuleFor(c => c.TaxId)
            .NotEmpty().WithMessage("The TaxId is empty.")
            .NotNull().WithMessage("The TaxId is null.");
        }
    }
}