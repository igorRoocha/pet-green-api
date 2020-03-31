using FluentValidation;
using PetGreen.Domain.Entities.Register;
using System;

namespace PetGreen.Application.Services.Validators.Register
{
    public class CatererValidator : AbstractValidator<Caterer>
    {
        public CatererValidator()
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

            RuleFor(c => c.TaxId)
            .NotEmpty().WithMessage("The TaxId is empty.")
            .NotNull().WithMessage("The TaxId is null.");

            RuleFor(c => c.SocialReason)
            .NotEmpty().WithMessage("The SocialReason is empty.")
            .NotNull().WithMessage("The SocialReason is null.");

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("The Email is empty.")
            .NotNull().WithMessage("The Email is null.");

            RuleFor(c => c.ClinicID)
            .NotEmpty().WithMessage("The ClinicID is empty.")
            .NotNull().WithMessage("The ClinicID is null.");

            RuleFor(c => c.CreatedAt)
                .NotEmpty().WithMessage("The CreatedAt is empty.")
                .NotNull().WithMessage("The CreatedAt is null.");
        }
    }
}
