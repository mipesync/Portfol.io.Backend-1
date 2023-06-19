using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Services
{
    /// <summary>
    /// Позволяет смаппить список <see cref="Album"/> в список <see cref="GetAlbumLookupDto"/>
    /// </summary>
    public static class AlbumMapper
    {
        /// <summary>
        /// Преобразует список <see cref="Album"/> в список <see cref="GetAlbumLookupDto"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="albums">Список альбомов</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="hostUrl"></param>
        /// <returns></returns>
        public static List<GetAlbumLookupDto> Map(IMapper mapper, List<Album> albums, Guid userId, string hostUrl)
        {
            var lookups = new List<GetAlbumLookupDto>();

            foreach (var entity in albums)
            {
                var lookup = mapper.Map<GetAlbumLookupDto>(entity, opt =>
                {
                    opt.Items["userId"] = userId;
                    opt.Items["url"] = hostUrl;
                });

                lookups.Add(lookup);
            }

            return lookups;
        }
    }
}
