using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business
{

    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, List<Message>>
    {
        private readonly MessageContext MessageContext;

        public GetMessagesQueryHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<List<Message>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return MessageContext.Messages.ToList();
        }
    }
}
