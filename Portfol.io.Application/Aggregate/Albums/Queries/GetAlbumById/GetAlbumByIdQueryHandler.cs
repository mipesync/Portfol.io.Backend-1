using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, GetAlbumByIdDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public GetAlbumByIdQueryHandler(IDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<GetAlbumByIdDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = (await _dbContext.Albums
                .Include(u => u.Files)
                .Include(u => u.Tags)
                .Include(u => u.AlbumLikes)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken))
                ?? throw new NotFoundException(nameof(Album), request.Id);

            entity.Views++;

            var dto = _mapper.Map<GetAlbumByIdDto>(entity, opt =>
            {
                opt.Items["userId"] = request.UserId;
                opt.Items["url"] = request.Url;
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return dto;
        }
    }
}
