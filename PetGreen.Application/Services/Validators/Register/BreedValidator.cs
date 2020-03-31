using FluentValidation;
using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Application.Services.Validators.Register
{
    public class BreedValidator : AbstractValidator<Breed>
    {
        public BreedValidator()
        {
            RuleFor(b => b)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("The Name is empty.")
                .NotNull().WithMessage("The Name is null.");

            RuleFor(b => b.SpecieID)
                .NotEmpty().WithMessage("The SpecieID is empty.")
                .NotNull().WithMessage("The SpecieID is null.");

            RuleFor(b => b.CreatedAt)
                .NotEmpty().WithMessage("The CreatedAt is empty.")
                .NotNull().WithMessage("The CreatedAt is null.");
        }
    }
}
