using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Application.Models
{
    public class UpdateAlbumDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
