using MediatR;
using Messages_MS.Data;
using System;

namespace Messages_MS.DTO
{
    public class DeleteMessage : IRequest<Message>
    {
        public Guid Id { get; set; }
        public DeleteMessage(Guid id)
        {
            Id = id;
        }
    }
}
