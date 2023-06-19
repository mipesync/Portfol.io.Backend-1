namespace Portfol.io.Application.Aggregate.Albums.DTO
{
    public class GetAlbumsDto
    {
        public ICollection<GetAlbumLookupDto> Albums { get; set; } = null!;
    }
}
