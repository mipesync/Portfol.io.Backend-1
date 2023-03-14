using MediatR;
using Portfol.io.Application.Aggregate.Photos.DTO;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageById
{
    /// <summary>
    /// Запрос на получение файла по идентификатору
    /// </summary>
    public class GetImageByIdQuery : IRequest<ImageLookupDto>
    {
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        public Guid Id { get; set; }
    }
}
