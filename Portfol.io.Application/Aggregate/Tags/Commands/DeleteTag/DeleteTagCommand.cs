﻿using MediatR;

namespace Portfol.io.Application.Aggregate.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
