using MediatR;

namespace Portfol.io.Application.Aggregate.Files.Commands.DeleteImage
{
    /// <summary>
    /// Команда на удаление файла из альбома
    /// </summary>
    public class DeleteImageCommand : IRequest<Unit>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        public Guid ImageId { get; set; }
        /// <summary>
        /// Корневой путь проекта
        /// </summary>
        public string WebRootPath { get; set; } = null!;
    }
}
