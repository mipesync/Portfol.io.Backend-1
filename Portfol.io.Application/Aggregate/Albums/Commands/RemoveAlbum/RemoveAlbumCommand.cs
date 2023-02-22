using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    /// <summary>
    /// Команда на удаление альбома
    /// </summary>
    public class RemoveAlbumCommand : IRequest<Unit>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid Id { get; set; }
    }
}
