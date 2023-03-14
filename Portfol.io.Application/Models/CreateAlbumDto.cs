using Portfol.io.Domain;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Application.Models
{
    public class CreateAlbumDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? Description { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
