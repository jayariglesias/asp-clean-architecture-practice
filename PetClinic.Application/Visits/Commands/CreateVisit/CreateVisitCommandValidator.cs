using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Common.Interfaces;

namespace PetClinic.Application.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {

        public CreateVisitCommandValidator(IDataContext context)
        {

            RuleFor(p => p.PetId)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (petId, cancellation) =>
                {
                    var exists = await context.Pets.FirstOrDefaultAsync(x => x.PetId == petId);
                    return exists != null ? true : false;
                }).WithMessage("{PropertyName} is not existed in the database. You can`t create visit if pet is not registered.");

            RuleFor(p => p.Notes)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.VisitType)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}