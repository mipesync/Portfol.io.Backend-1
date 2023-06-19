using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    /// <summary>
    /// Запрос на получение альбомов по идентификатору пользователя
    /// </summary>
    public class GetAlbumsByUserIdQuery : IRequest<GetAlbumsDto>
    {
        /// <summary>
        /// Идентификатор владельца альбомов
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Идентификатор авторизованного пользователя
        /// </summary>
        public Guid AUserId { get; set; }
        /// <summary>
        /// Адрес текущего хоста
        /// </summary>
        public string Url { get; set; } = "";
    }
}
