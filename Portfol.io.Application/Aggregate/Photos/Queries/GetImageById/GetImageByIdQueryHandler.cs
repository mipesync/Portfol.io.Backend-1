using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Files.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Files.Queries.GetImageById
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageLookupDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetImageByIdQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ImageLookupDto> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Files
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
                throw new NotFoundException(nameof(Domain.File), request.Id);

            return _mapper.Map<ImageLookupDto>(entity);
        }
    }
}
