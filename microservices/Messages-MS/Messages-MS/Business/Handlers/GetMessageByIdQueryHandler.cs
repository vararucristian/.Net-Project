using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business.Handlers
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, Message>
    {
        private readonly MessageContext MessageContext;

        public GetMessageByIdQueryHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<Message> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var messages = MessageContext.Messages;
            var message = messages.Where(m => m.Id == request.Id).FirstOrDefault();
            return message;
        }
    }
}
