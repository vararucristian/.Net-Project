using MediatR;
using System;
using System.Collections.Generic;

namespace Messages_MS.DTO
{
    public class CreateMessage : IRequest<Dictionary<string, object>>
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Text { get; set; }

    }
}
