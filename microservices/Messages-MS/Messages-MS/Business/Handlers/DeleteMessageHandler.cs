using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business.Handlers
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessage, Message>
    {
        
            private readonly MessageContext MessageContext;
            private readonly IMediator _mediator;
            public DeleteMessageHandler(MessageContext messageContext, IMediator mediator)
            {
                MessageContext = messageContext;
                _mediator = mediator;
            }


            public async Task<Message> Handle(DeleteMessage request, CancellationToken cancellationToken)
            {
                var message = await _mediator.Send(new GetMessageByIdQuery(request.Id));
                if (message != null)
                {
                    MessageContext.Messages.Remove(message);
                    MessageContext.SaveChanges();

                }
                return message;
            }
        }
    
}
