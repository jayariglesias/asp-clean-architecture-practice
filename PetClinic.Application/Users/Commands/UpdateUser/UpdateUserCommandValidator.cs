using FluentValidation;
using PetClinic.Application.Common.Interfaces;

namespace PetClinic.Application.Users.Commands.UpdateUser
{

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(IDataContext context)
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must greater than 3 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must greater than 3 characters.");
        }
    }

}
