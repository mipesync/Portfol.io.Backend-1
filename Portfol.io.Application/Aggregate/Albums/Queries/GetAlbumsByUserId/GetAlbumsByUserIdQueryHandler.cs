﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQueryHandler : IRequestHandler<GetAlbumsByUserIdQuery, GetAlbumsDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlbumsByUserIdQueryHandler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetAlbumsDto> Handle(GetAlbumsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entities = (await _dbContext.Albums
                .AsNoTracking()
                .Include(u => u.Files)
                .Include(u => u.AlbumLikes!)
                .Where(u => u.UserId == request.UserId)
                .ToListAsync(cancellationToken))
                ?? throw new NotFoundException(nameof(Album), request.UserId);

            var lookups = AlbumMapper.Map(_mapper, entities, request.AUserId, request.Url);

            return new GetAlbumsDto { Albums = lookups }; 
        }
    }
}
