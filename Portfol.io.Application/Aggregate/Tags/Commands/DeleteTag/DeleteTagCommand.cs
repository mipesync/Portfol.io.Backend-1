using MediatR;

namespace Portfol.io.Application.Aggregate.Tags.Commands.DeleteTag
{
    /// <summary>
    /// Команда на удаление тега
    /// </summary>
    public class DeleteTagCommand : IRequest<Unit>
    {
        /// <summary>
        /// Идентификатор тега
        /// </summary>
        public Guid Id { get; set; }
    }
}
