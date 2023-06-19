using AutoMapper;
using Portfol.io.Application.Aggregate.Files.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Mappings.MappingProfiles
{
    internal class PhotoMappingProfile : Profile
    {
        public PhotoMappingProfile()
        {
            CreateMap<Domain.File, GetImageByIdDto>(MemberList.Source);
            CreateMap<Domain.File, ImageLookupDto>(MemberList.Source);
        }
    }
}
