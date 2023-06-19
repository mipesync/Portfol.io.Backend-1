using Portfol.io.Application.Models;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Services.UserLikeCheck
{
    /// <summary>
    /// Позволяет проверить, оценён ли альбом текущим пользователем
    /// </summary>
    public static class AlbumStatesChecker
    {
        /// <summary>
        /// Проверяет, оценён ли альбом текущим пользователем
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <param name="album">Товар</param>
        /// <returns><see cref="StatesCheckerDto"/></returns>
        public static StatesCheckerDto Check(Guid userId, Album album)
        {
            var result = new StatesCheckerDto();

            if (album.AlbumBookmarks.Any(u => u.UserId == userId))
                result.IsFavourite = true;

            if (album.AlbumLikes!.Any(u => u.UserId == userId))
                result.IsLiked = true;

            return result;
        }
    }
}