using AutoMapper;
using AutoMapper.Configuration;
using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Services;
using Portfol.io.Application.Common.Services.UserLikeCheck;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Mappings.MappingProfiles
{
    public class AlbumMappingProfile : Profile
    {
        public AlbumMappingProfile()
        {
            CreateMap<Album, GetAlbumByIdDto>(MemberList.Source )
                .ForMember(albumLookup => albumLookup.IsLiked, opt =>
                    opt.MapFrom((album, albumLookup, isLiked, context) =>
                    {
                        return AlbumStatesChecker.Check(Guid.Parse(context.Items["userId"].ToString()!), album).IsLiked;
                    }))
                .ForMember(albumLookup => albumLookup.Cover, opt =>
                    opt.MapFrom((album, albumLookup, cover, context) =>
                    {
                        if (album.Cover != null)
                            return UrlParser.Parse(album.Cover!, context.Items["url"].ToString()!);
                        else
                            return null;
                    }))
                .ForMember(albumLookup => albumLookup.Likes, opt => opt.MapFrom(album => album.AlbumLikes.Count));

            CreateMap<Album, GetAlbumLookupDto>(MemberList.Source)
                .ForMember(albumLookup => albumLookup.IsLiked, opt =>
                    opt.MapFrom((album, albumLookup, isLiked, context) =>
                    {
                        return AlbumStatesChecker.Check(Guid.Parse(context.Items["userId"].ToString()!), album).IsLiked;
                    }))
                .ForMember(albumLookup => albumLookup.IsFavourite, opt =>
                    opt.MapFrom((album, albumLookup, isFavourite, context) =>
                    {
                        return AlbumStatesChecker.Check(Guid.Parse(context.Items["userId"].ToString()!), album).IsFavourite;
                    }))
                .ForMember(albumLookup => albumLookup.Cover, opt =>
                    opt.MapFrom((album, albumLookup, cover, context) =>
                    {
                        if (album.Cover != null)
                            return UrlParser.Parse(album.Cover!, context.Items["url"].ToString()!);
                        else
                            return null;
                    }))
                .ForMember(albumLookup => albumLookup.Likes, opt => opt.MapFrom(album => album.AlbumLikes.Count));
        }
    }
}
