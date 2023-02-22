using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover
{
    /// <summary>
    /// Команда на удаление обложки альбома
    /// </summary>
    public class DeleteAlbumCoverCommand : IRequest<Unit>
    {
        /// <summary>
        ///     Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        ///     Корневой путь проекта
        /// </summary>
        public string WebRootPath { get; set; } = null!;
    }
}
