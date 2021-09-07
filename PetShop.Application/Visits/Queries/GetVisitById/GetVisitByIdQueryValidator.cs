using FluentValidation;

namespace PetShop.Application.Visits.Queries.GetVisitById
{
    public class GetVisitByIdQueryValidator : AbstractValidator<GetVisitByIdQuery>
    {
        public GetVisitByIdQueryValidator()
        {
            RuleFor(p => p.VisitId).NotEmpty().WithMessage("{PropertyName} must not null.");
        }
    }
}