using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business.Handlers
{
    public class GetMessagesByReceiverIdQueryHandler : IRequestHandler<GetMessagesByReceiverIdQuery, List<Message>>
    {
        private readonly MessageContext MessageContext;

        public GetMessagesByReceiverIdQueryHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<List<Message>> Handle(GetMessagesByReceiverIdQuery request, CancellationToken cancellationToken)
        {
            var messages = MessageContext.Messages.ToList();
            var query = from m in messages
                        where m.ReceiverId == request.ReceiverId
                        select m;

            return query.ToList();
        }
    }
}
