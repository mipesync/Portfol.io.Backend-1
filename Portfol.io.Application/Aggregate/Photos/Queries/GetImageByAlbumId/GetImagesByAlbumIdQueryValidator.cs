using FluentValidation;

namespace Portfol.io.Application.Aggregate.Files.Queries.GetImageByAlbumId
{
    public class GetImagesByAlbumIdQueryValidator : AbstractValidator<GetImagesByAlbumIdQuery>
    {
        public GetImagesByAlbumIdQueryValidator()
        {
            RuleFor(x => x.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");
        }
    }
}
