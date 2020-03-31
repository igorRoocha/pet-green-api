using FluentValidation;
using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Application.Services.Validators.Register
{
    public class SpecieValidator : AbstractValidator<Specie>
    {
        public SpecieValidator()
        {
            RuleFor(s => s)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(s => s.Name)
             .NotEmpty().WithMessage("The Name is empty.")
             .NotNull().WithMessage("The Name is null.");

            RuleFor(s => s.CreatedAt)
                .NotEmpty().WithMessage("The CreatedAt is empty.")
                .NotNull().WithMessage("The CreatedAt is null.");
        }
    }
}
