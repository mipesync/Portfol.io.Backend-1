using FluentValidation;

namespace Portfol.io.Application.Aggregate.Files.Queries.GetImageById
{
    public class GetImageByIdQueryValidator : AbstractValidator<GetImageByIdQuery>
    {
        public GetImageByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
