using MediatR;
using Portfol.io.Application.Aggregate.Photos.DTO;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageByAlbumId
{
    /// <summary>
    /// Запрос на получение файлов по идентификатору альбома
    /// </summary>
    public class GetImagesByAlbumIdQuery : IRequest<GetImagesByAlbumIdDto>
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
    }
}
