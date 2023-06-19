using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Files.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Files.Queries.GetImageByAlbumId
{
    public class GetImagesByAlbumIdQueryHandler : IRequestHandler<GetImagesByAlbumIdQuery, GetImagesByAlbumIdDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetImagesByAlbumIdQueryHandler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetImagesByAlbumIdDto> Handle(GetImagesByAlbumIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Files
                .AsNoTracking()
                .Where(u => u.AlbumId == request.AlbumId)
                .ProjectTo<ImageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (entities.Count == 0)
                throw new NotFoundException(nameof(List<Domain.File>), request.AlbumId);

            return new GetImagesByAlbumIdDto { Images = entities };
        }
    }
}
