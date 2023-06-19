using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Files.Commands.AddImage
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand, ICollection<Guid>>
    {
        private readonly IDbContext _dbContext;
        private readonly IFileUploader _uploader;

        public AddImageCommandHandler(IDbContext dbContext, IFileUploader uploader)
        {
            _dbContext = dbContext;
            _uploader = uploader;
        }

        public async Task<ICollection<Guid>> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Albums
                .FirstOrDefaultAsync(u => u.Id == request.AlbumId, cancellationToken);

            if (entity is null || entity.Id != request.AlbumId)
                throw new NotFoundException(nameof(Album), request.AlbumId);

            var guids = new List<Guid>();

            foreach (var image in request.Files)
            {
                _uploader.File = image;
                _uploader.WebRootPath = request.WebRootPath is null
                    ? throw new ArgumentException("WebRootPath не может быть пустым")
                    : request.WebRootPath;
                _uploader.AbsolutePath = $"/AlbumImages/{entity.UserId}/{entity.Id}";
                var imagePath = await _uploader.Upload();

                var photo = new Domain.File
                {
                    Path = imagePath,
                    AlbumId = request.AlbumId
                };

                await _dbContext.Files.AddAsync(photo, cancellationToken);

                guids.Add(photo.Id);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return guids;
        }
    }
}
