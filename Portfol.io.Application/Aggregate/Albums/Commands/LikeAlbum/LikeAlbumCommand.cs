using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum
{
    /// <summary>
    /// Команда на оценку альбома
    /// </summary>
    public class LikeAlbumCommand : IRequest<Unit>
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
