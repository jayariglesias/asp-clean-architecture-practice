using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Common.Interfaces;

namespace PetClinic.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {

        public CreatePetCommandValidator(IDataContext context)
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellation) =>
                {
                    var exists = await context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
                    return exists != null ? true : false;
                }).WithMessage("{PropertyName} is not existed in the database. You can`t create pet if user is not registered.");

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