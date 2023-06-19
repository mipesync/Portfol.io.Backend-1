﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover
{
    public class DeleteAlbumCoverCommandHandler : IRequestHandler<DeleteAlbumCoverCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public DeleteAlbumCoverCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteAlbumCoverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums.FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken);

            if (entity is null || entity.Id != request.AlbumId)
                throw new NotFoundException(nameof(Album), request.AlbumId);

            System.IO.File.Delete(String.Concat(request.WebRootPath, entity.Cover));
            //TODO: Удалить этот бред
            entity.Cover = "/AlbumCovers/default.png";

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
