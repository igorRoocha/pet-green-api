using FluentValidation;
using PetGreen.Domain.Entities;
using System;

namespace PetGreen.Application.Services.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(a => a.Cep)
             .NotEmpty().WithMessage("The Cep is empty.")
             .NotNull().WithMessage("The Cep is null.");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("The Number is empty.")
                .NotNull().WithMessage("The Number is null.");

            RuleFor(a => a.CreatedAt)
                .NotEmpty().WithMessage("The CreatedAt is empty.")
                .NotNull().WithMessage("The CreatedAt is null.");

            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The Street is empty.")
                .NotNull().WithMessage("The Street is null.");

            RuleFor(a => a.Neighborhood)
                .NotEmpty().WithMessage("The Neighborhood is empty.")
                .NotNull().WithMessage("The Neighborhood is null.");
        }
    }
}
