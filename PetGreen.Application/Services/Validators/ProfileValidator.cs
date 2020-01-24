using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Description)
             .NotEmpty().WithMessage("The description is empty.")
             .NotNull().WithMessage("The description is null.");
        }
    }
}