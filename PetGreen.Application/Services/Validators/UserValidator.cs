using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
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

            RuleFor(c => c.PasswordHash)
            .NotEmpty().WithMessage("The PasswordHash is empty.")
            .NotNull().WithMessage("The PasswordHash is null.");

            RuleFor(c => c.PasswordSalt)
            .NotEmpty().WithMessage("The PasswordSalt is empty.")
            .NotNull().WithMessage("The PasswordSalt is null.");

            RuleFor(c => c.Profile)
            .NotEmpty().WithMessage("The Profile is empty.")
            .NotNull().WithMessage("The Profile is null.");
        }
    }
}