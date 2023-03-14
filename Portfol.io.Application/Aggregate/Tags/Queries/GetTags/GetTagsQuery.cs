using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Tags.Queries.GetTags
{
    /// <summary>
    /// Запрос на получение всех альбомов
    /// </summary>
    public class GetTagsQuery : IRequest<List<Tag>> { }
}
