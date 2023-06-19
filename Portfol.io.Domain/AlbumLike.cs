using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    /// <summary>
    /// Класс лайка
    /// </summary>
    public class AlbumLike
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        public Guid AlbumId { get; set; }

        [JsonIgnore]
        public Album Album { get; set; } = new Album();
    }
}
