using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum
{
    /// <summary>
    /// Команда на изменение информации об альбоме
    /// </summary>
    public class UpdateAlbumCommand : IRequest<Unit>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название альбома
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Описание альбома
        /// </summary>
        public string? Description { get; set; }
    }
}
