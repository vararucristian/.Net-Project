using MediatR;
using Messages_MS.Data;
using System;
using System.Collections.Generic;

namespace Messages_MS.DTO
{
    public class GetMessagesBySenderIdQuery : IRequest<List<Message>>
    {
        public Guid SenderId { get; set; }

        public GetMessagesBySenderIdQuery(Guid senderId)
        {
            SenderId = senderId;
        }
    }
}
