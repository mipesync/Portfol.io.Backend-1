using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    /// <summary>
    /// Запрос на получение альбомов из заметок
    /// </summary>
    public class GetMarkedAlbumsQuery : IRequest<GetAlbumsDto>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
