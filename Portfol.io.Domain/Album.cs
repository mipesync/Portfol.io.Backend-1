using NpgsqlTypes;

namespace Portfol.io.Domain
{
    /// <summary>
    /// Класс альбома
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название альбома
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Описание альбома
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Обложка альбома
        /// </summary>
        public string? Cover { get; set; }
        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Вектор поиска
        /// </summary>
        public NpgsqlTsVector SearchVector { get; set; } = null!;
		
        public ICollection<File>? Files { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<AlbumTag> AlbumTags { get; set; } = new List<AlbumTag>();
        public ICollection<AlbumLike> AlbumLikes { get; set; } = new List<AlbumLike>();
        public ICollection<AlbumBookmark> AlbumBookmarks { get; set; } = new List<AlbumBookmark>();
    }
}
