namespace Portfol.io.Application.Aggregate.Files.DTO
{
    public class GetImageByIdDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
    }
}