using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    /// <summary>
    /// Класс закладок
    /// </summary>
    public class AlbumBookmark
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Album Album { get; set; } = new Album();
    }
}
