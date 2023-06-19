using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQueryHandler : IRequestHandler<GetMarkedAlbumsQuery, GetAlbumsDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMarkedAlbumsQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAlbumsDto> Handle(GetMarkedAlbumsQuery request, CancellationToken cancellationToken)
        {
            var albums = (await _dbContext.AlbumBookmarks
                .AsNoTracking()
                .Include(u => u.Album)
                .Where(u => u.UserId == request.UserId)
                .ToListAsync(cancellationToken))
                ?? throw new NotFoundException(nameof(Album), request.UserId);

            var lookups = AlbumMapper.Map(_mapper, albums.Select(u => u.Album).ToList(), request.UserId, request.Url);

            return new GetAlbumsDto { Albums = lookups };
        }
    }
}
