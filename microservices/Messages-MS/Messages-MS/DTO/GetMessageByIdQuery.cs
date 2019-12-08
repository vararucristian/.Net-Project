using MediatR;
using Messages_MS.Data;
using System;

namespace Messages_MS.DTO
{
    public class GetMessageByIdQuery : IRequest<Message>
    {
        public Guid Id { get; set; }

        public GetMessageByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
