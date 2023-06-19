using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    /// <summary>
    /// Запрос на получение всех альбомов пользователя
    /// </summary>
    public class GetAllAlbumsQuery : IRequest<GetAlbumsDto>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Адрес текущего хоста
        /// </summary>
        public string Url { get; set; } = "";
    }
}
