using MediatR;
using Portfol.io.Application.Aggregate.Files.DTO;

namespace Portfol.io.Application.Aggregate.Files.Queries.GetImageByAlbumId
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
