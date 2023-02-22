using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    /// <summary>
    /// Запрос на получение альбомов по тегам
    /// </summary>
    public class GetAlbumsByTagsQuery : IRequest<GetAlbumsDto>
    {
        /// <summary>
        /// Список идентификаторов тегов
        /// </summary>
        public IEnumerable<Guid> TagIds { get; set; } = null!;
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
