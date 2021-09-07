using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Common.Interfaces;

namespace PetShop.Application.Users.Commands.CreateUser
{

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IDataContext context)
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(4).WithMessage("{PropertyName} must greater than 4 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.");

            RuleFor(p => p.MiddleName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.")
                .MustAsync(async (email, cancellation) => {
                     var exists = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
                     return exists == null ? true : false;
                 }).WithMessage("{PropertyName} is existed in the database.");

            RuleFor(p => p.Username)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.")
                .MustAsync(async (username, cancellation) => {
                    var exists = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
                    return exists == null ? true : false;
                }).WithMessage("{PropertyName} is existed in the database.");
            
            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} must greater than 5 characters.");
        }
    }

}
