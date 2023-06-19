using MediatR;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Files.Commands.AddImage
{
    /// <summary>
    /// Команда на добавление файлов в альбом
    /// </summary>
    public class AddImageCommand : IRequest<ICollection<Guid>>
    {
        /// <summary>
        /// Список файлов
        /// </summary>
        public ICollection<IFormFile> Files { get; set; } = null!;
        /// <summary>
        /// Корневой путь проекта
        /// </summary>
        public string WebRootPath { get; set; } = null!;
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
    }
}
