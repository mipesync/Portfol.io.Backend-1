using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum
{
    /// <summary>
    /// Команда на добавление альбома в закладки
    /// </summary>
    public class MarkAlbumCommand : IRequest<Unit>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
