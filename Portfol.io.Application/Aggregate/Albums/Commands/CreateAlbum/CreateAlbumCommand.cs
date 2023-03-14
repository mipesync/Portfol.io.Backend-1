using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    /// <summary>
    /// Команда на создание альбома
    /// </summary>
    public class CreateAlbumCommand : IRequest<Guid>
    {
        /// <summary>
        ///     Название продукта
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        ///     Описание продукта
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        ///     Идентификатор создателя альбома
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        ///     Список тэгов
        /// </summary>
        public List<Tag>? Tags { get; set; }
    }
}
