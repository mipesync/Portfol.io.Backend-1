using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum
{
    /// <summary>
    ///     Команда для снятия оценки с альбома
    /// </summary>
    public class DislikeAlbumCommand : IRequest<Unit>
    {
        /// <summary>
        ///     Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        ///     Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
