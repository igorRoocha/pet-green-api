using FluentValidation;
using PetGreen.Domain.Entities;
using System;

namespace PetGreen.Application.Services.Validators
{
    public class StateValidator : AbstractValidator<State>
    {
        public StateValidator()
        {
            RuleFor(s => s)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(s => s.Name)
             .NotEmpty().WithMessage("The name is empty.")
             .NotNull().WithMessage("The name is null.");

            RuleFor(s => s.UF)
            .NotEmpty().WithMessage("The UF is empty.")
            .NotNull().WithMessage("The UF is null.");

            RuleFor(s => s.CreatedAt)
            .NotEmpty().WithMessage("The CreatedAt is empty.")
            .NotNull().WithMessage("The CreatedAt is null.");

        }
    }
}
