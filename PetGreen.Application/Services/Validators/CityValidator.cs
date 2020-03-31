using FluentValidation;
using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Application.Services.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Name)
             .NotEmpty().WithMessage("The Name is empty.")
             .NotNull().WithMessage("The Name is null.");

            RuleFor(c => c.IBGE)
                .NotEmpty().WithMessage("The IBGE is empty.")
                .NotNull().WithMessage("The IBGE is null.");

            RuleFor(c => c.CreatedAt)
                .NotEmpty().WithMessage("The CreatedAt is empty.")
                .NotNull().WithMessage("The CreatedAt is null.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The State is empty.")
                .NotNull().WithMessage("The State is null.");
        }
    }
}
