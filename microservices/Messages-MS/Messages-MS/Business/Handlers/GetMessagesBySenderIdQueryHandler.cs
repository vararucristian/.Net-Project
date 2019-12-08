using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business.Handlers
{
    public class GetMessagesBySenderIdQueryHandler : IRequestHandler<GetMessagesBySenderIdQuery, List<Message>>
    {
        private readonly MessageContext MessageContext;

        public GetMessagesBySenderIdQueryHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<List<Message>> Handle(GetMessagesBySenderIdQuery request, CancellationToken cancellationToken)
        {
            var messages = MessageContext.Messages.ToList();
            var query = from m in messages
                        where m.SenderId == request.SenderId
                        select m;

            return query.ToList();
        }
    }
}
