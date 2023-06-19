using Microsoft.EntityFrameworkCore;
using Portfol.io.Domain;

namespace Portfol.io.Application.Interfaces
{
    /// <summary>
    ///     Классы, реализующие этот интерфейс, добавят таблицы в основной контекст
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        ///     Получить/установить список альбомов
        /// </summary>
        DbSet<Album> Albums { get; set; }
        /// <summary>
        ///     Получить/установить список файлов
        /// </summary>
        DbSet<Domain.File> Files { get; set; }
        /// <summary>
        ///     Получить/установить список тегов
        /// </summary>
        DbSet<Tag> Tags { get; set; }
        /// <summary>
        ///     Получить/установить список связанных тегов и альбомов
        /// </summary>
        DbSet<AlbumTag> AlbumTags { get; set; }
        /// <summary>
        ///     Получить/установить список связанных альбомов и лайков
        /// </summary>
        DbSet<AlbumLike> AlbumLikes { get; set; }
        /// <summary>
        ///     Получить/установить список связанных альбомов и заметок
        /// </summary>
        DbSet<AlbumBookmark> AlbumBookmarks { get; set; }

        /// <summary>
        ///     Ассинхронно сохраняет сделанные изменения
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
