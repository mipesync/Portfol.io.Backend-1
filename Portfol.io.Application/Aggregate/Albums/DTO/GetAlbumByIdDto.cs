using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.DTO
{
    public class GetAlbumByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
        public bool IsLiked { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
    }
}
