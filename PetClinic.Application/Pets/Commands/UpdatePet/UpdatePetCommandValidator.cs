using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Common.Interfaces;

namespace PetClinic.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {

        public UpdatePetCommandValidator(IDataContext context)
        {
            RuleFor(p => p.PetName)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PetType)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Breed)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.");
        }
    }
}