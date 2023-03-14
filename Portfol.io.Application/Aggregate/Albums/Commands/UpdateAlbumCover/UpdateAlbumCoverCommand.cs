using MediatR;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover
{
    /// <summary>
    /// Команда на изменение обложки альбома
    /// </summary>
    public class UpdateAlbumCoverCommand : IRequest<Unit>
    {
        /// <summary>
        /// Файл изображения
        /// </summary>
        public IFormFile Image { get; set; } = null!;
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Корневой путь проекта
        /// </summary>
        public string WebRootPath { get; set; } = null!;
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
