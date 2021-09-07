using FluentValidation;

namespace PetShop.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("{Property Name} must not null.");
        }
    }
}