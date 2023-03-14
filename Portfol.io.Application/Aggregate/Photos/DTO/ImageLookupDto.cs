namespace Portfol.io.Application.Aggregate.Photos.DTO
{
    public class ImageLookupDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
    }
}