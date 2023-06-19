using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;
using System.Text.RegularExpressions;

namespace Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum
{
    public class MarkAlbumCommandHandler : IRequestHandler<MarkAlbumCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public MarkAlbumCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //TODO: Разделить функционал тут и в лайках
        public async Task<Unit> Handle(MarkAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = (await _dbContext.Albums
                .FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken))
                ?? throw new NotFoundException(nameof(Album), request.AlbumId);

            var entity = new AlbumBookmark
            {
                UserId = request.UserId,
                Album = album
            };

            await _dbContext.AlbumBookmarks.AddAsync(entity, cancellationToken);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException e)
            {
                if (Regex.IsMatch(e.InnerException!.Message, @"\w*23505"))
                {
                    _dbContext.AlbumBookmarks.Attach(entity);
                    _dbContext.AlbumBookmarks.Remove(entity);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }

            return Unit.Value;
        }
    }
}
