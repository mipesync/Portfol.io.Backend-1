using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Mappings.MappingProfiles
{
    public class AlbumMappingProfile : Profile
    {
        public AlbumMappingProfile()
        {
            CreateMap<Album, GetAlbumByIdDto>(MemberList.Source)
                .ForMember(albumLookup => albumLookup.Likes, opt => opt.MapFrom(album => album.AlbumLikes!.Count));

            CreateMap<Album, GetAlbumLookupDto>(MemberList.Source)
                .ForMember(albumLookup => albumLookup.Likes, opt => opt.MapFrom(album => album.AlbumLikes!.Count));
        }
    }
}
