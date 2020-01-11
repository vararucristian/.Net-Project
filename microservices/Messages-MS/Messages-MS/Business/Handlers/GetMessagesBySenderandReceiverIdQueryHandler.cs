using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business.Handlers
{
    public class GetMessagesBySenderandReceiverIdQueryHandler : IRequestHandler<GetMessagesBySenderandReceiverIdQuery, List<Message>>
    {
        private readonly MessageContext MessageContext;

        public GetMessagesBySenderandReceiverIdQueryHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<List<Message>> Handle(GetMessagesBySenderandReceiverIdQuery request, CancellationToken cancellationToken)
        {
            var messages = MessageContext.Messages.ToList();
            var query = messages.Where(m => (m.ReceiverId == request.ReceiverId && m.SenderId == request.SenderId)
            || (m.ReceiverId == request.SenderId && m.SenderId == request.ReceiverId)).OrderBy(m => m.CreatedAt);

            return query.ToList();
        }
    }
}
