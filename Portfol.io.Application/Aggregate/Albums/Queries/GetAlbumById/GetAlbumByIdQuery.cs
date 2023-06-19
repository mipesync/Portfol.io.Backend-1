using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    /// <summary>
    /// Запрос на получение альбома по идентификатору
    /// </summary>
    public class GetAlbumByIdQuery : IRequest<GetAlbumByIdDto>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid Id { get; set; }
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
