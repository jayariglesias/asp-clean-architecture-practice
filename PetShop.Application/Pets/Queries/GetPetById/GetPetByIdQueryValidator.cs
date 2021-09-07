using FluentValidation;

namespace PetShop.Application.Pets.Queries.GetPetById
{
    public class GetPetByIdQueryValidator : AbstractValidator<GetPetByIdQuery>
    {
        public GetPetByIdQueryValidator()
        {
            RuleFor(p => p.PetId).NotEmpty().WithMessage("{PropertyName} must not null.");
        }
    }
}