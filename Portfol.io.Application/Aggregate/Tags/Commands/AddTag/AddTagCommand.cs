using MediatR;

namespace Portfol.io.Application.Aggregate.Tags.Commands.AddTag
{
    /// <summary>
    /// Команда на добавление тега
    /// </summary>
    public class AddTagCommand :  IRequest<Guid>
    {
        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
