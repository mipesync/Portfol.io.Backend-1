using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Application.Models
{
    public class DeleteFromAlbumDto
    {
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public Guid ImageId { get; set; }
    }
}
