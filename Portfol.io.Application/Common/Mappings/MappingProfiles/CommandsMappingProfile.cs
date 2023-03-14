using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Aggregate.Photos.Commands.AddImage;
using Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage;
using Portfol.io.Application.Models;

namespace Portfol.io.Application.Common.Mappings.MappingProfiles
{
    internal class CommandsMappingProfile : Profile
    {
        public CommandsMappingProfile()
        {
            CreateMap<AddToAlbumDto, AddImageCommand>(MemberList.Destination);

            CreateMap<CreateAlbumDto, CreateAlbumCommand>(MemberList.Destination);

            CreateMap<DeleteFromAlbumDto, DeleteImageCommand>(MemberList.Destination);

            CreateMap<UpdateAlbumDto, UpdateAlbumCommand>(MemberList.Destination);
        }
    }
}
