using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Services;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQueryHandler : IRequestHandler<SearchAlbumQuery, GetAlbumsDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchAlbumQueryHandler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetAlbumsDto> Handle(SearchAlbumQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Albums
                .AsNoTracking()
                .Include(u => u.AlbumLikes)
                .Where(x => x.SearchVector.Matches(request.Query!))
                .ToListAsync(cancellationToken);

            var lookups = AlbumMapper.Map(_mapper, entities, request.UserId, request.Url);

            return new GetAlbumsDto { Albums = lookups };
        }
    }
}
