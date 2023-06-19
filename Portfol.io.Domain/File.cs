using Portfol.io.Domain.Enums;

namespace Portfol.io.Domain
{
    /// <summary>
    /// Класс файла
    /// </summary>
    public class File
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; } = null!;
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Тип файла
        /// </summary>
        public FileTypes Type { get; set; }

        public Album Album { get; set; } = new Album();
    }
}
