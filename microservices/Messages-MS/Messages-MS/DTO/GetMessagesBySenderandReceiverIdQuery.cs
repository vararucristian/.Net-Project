
using MediatR;
using Messages_MS.Data;
using System;
using System.Collections.Generic;

namespace Messages_MS.DTO
{
    public class GetMessagesBySenderandReceiverIdQuery : IRequest<List<Message>>
    {
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }

        public GetMessagesBySenderandReceiverIdQuery(Guid receiverId, Guid senderId)
        {
            ReceiverId = receiverId;
            SenderId = senderId;
        }
    }
}
