using System;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Application.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Number)
             .NotEmpty().WithMessage("The number is empty.")
             .NotNull().WithMessage("The number is null.");

            RuleFor(c => c.ContactType)
             .NotEmpty().WithMessage("The contactType is empty.")
             .NotNull().WithMessage("The contactType is null.");
        }
    }
}