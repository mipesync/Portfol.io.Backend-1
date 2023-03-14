using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Application.Models
{
    public class AddToAlbumDto
    {
        [Required]
        public ICollection<IFormFile> Files { get; set; } = null!;
        [Required]
        public Guid AlbumId { get; set; }
    }
}
