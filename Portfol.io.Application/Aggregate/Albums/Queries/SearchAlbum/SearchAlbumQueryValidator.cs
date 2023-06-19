using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQueryValidator : AbstractValidator<SearchAlbumQuery>
    {
        public SearchAlbumQueryValidator()
        {
            RuleFor(searchAlbumQuery => searchAlbumQuery.Query)
                .NotEmpty().WithMessage("The query string is requred.");

            RuleFor(searchAlbumQuery => searchAlbumQuery.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required.");

            RuleFor(getAllAlbumsQuery => getAllAlbumsQuery.Url)
                .NotEqual(string.Empty).WithMessage("Url is required.");
        }
    }
}
