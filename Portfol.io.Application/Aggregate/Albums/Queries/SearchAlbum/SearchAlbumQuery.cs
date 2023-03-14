using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    /// <summary>
    /// Запрос на поиск альбома
    /// </summary>
    public class SearchAlbumQuery : IRequest<GetAlbumsDto>
    {
        /// <summary>
        /// Строка запроса
        /// </summary>
        public string? Query { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
