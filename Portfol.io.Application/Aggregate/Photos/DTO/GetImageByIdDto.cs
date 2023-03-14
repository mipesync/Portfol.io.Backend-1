namespace Portfol.io.Application.Aggregate.Photos.DTO
{
    public class GetImageByIdDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
    }
}