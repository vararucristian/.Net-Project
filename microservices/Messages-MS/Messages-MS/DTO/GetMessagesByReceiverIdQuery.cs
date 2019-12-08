using MediatR;
using Messages_MS.Data;
using System;
using System.Collections.Generic;

namespace Messages_MS.DTO
{
    public class GetMessagesByReceiverIdQuery : IRequest<List<Message>>
    {
        public Guid ReceiverId { get; set; }

        public GetMessagesByReceiverIdQuery(Guid receiverId)
        {
            ReceiverId = receiverId;
        }

    }
}
