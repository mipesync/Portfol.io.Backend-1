using AutoMapper;
using Portfol.io.Application.Aggregate.Photos.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Mappings.MappingProfiles
{
    internal class PhotoMappingProfile : Profile
    {
        public PhotoMappingProfile()
        {
            CreateMap<Photo, GetImageByIdDto>(MemberList.Source);
            CreateMap<Photo, ImageLookupDto>(MemberList.Source);
        }
    }
}
