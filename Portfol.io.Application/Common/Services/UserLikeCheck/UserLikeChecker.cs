using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Services.UserLikeCheck
{
    /// <summary>
    /// Check the user's like album. <see cref="T"/> will be <see cref="List{T}"/>
    /// </summary>
    /// <typeparam name="T">The list type to be returned</typeparam>
    public class UserLikeChecker<T> where T : GetAlbumLookupDto
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Check the user's like album
        /// </summary>
        public UserLikeChecker(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Проверяет, оценён ли альбом текущим пользователем
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="albums">Список альбомов</param>
        /// <returns>Список альбомов с true/false значениями isLiked</returns>
        public List<T> Check(Guid userId, List<Album> albums)
        {
            var response = new List<T>();

            foreach (var album in albums)
            {
                var dto = _mapper.Map<T>(album);

                if (album.AlbumLikes!.Any(u => u.UserId == userId))
                    dto.IsLiked = true;

                response.Add(dto);
            }

            return response;
        }
    }
}
