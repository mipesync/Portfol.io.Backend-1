using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    /// <summary>
    /// Класс тега
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Идентификатор тега
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
        [JsonIgnore]
        public virtual ICollection<AlbumTag> AlbumTags { get; set; } = new List<AlbumTag>();
    }
}
