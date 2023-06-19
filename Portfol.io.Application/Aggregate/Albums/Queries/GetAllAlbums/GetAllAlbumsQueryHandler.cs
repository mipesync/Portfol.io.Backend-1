using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, GetAlbumsDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllAlbumsQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAlbumsDto> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var entities = (await _dbContext.Albums
                .AsNoTracking()
                .Include(u => u.Files)
                .Include(u => u.AlbumLikes!)
                .ToListAsync(cancellationToken))
                ?? throw new NotFoundException(nameof(Album), "");
            
            var lookups = AlbumMapper.Map(_mapper, entities, request.UserId, request.Url);

            return new GetAlbumsDto { Albums = lookups };
        }
    }
}
