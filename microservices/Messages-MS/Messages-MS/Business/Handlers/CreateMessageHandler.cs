using MediatR;
using Messages_MS.Data;
using Messages_MS.DTO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Messages_MS.Business
{
    public class CreateMessageHandler : IRequestHandler<CreateMessage, Dictionary<string, object>>
    {
        private readonly MessageContext MessageContext;

        public CreateMessageHandler(MessageContext messageContext)
        {
            MessageContext = messageContext;
        }

        public async Task<Dictionary<string, object>> Handle(CreateMessage request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            bool succes = true;
            var response = new Dictionary<string, object>();

            var message = Message.Create(request.SenderId, request.ReceiverId, request.Text, DateTime.Now);

            try
            {
                MessageContext.Messages.Add(message);
                await MessageContext.SaveChangesAsync(cancellationToken);
            }
            catch 
            {
                succes = false;

            }

            response.Add("succes", succes);
            response.Add("message", message);
            return response;

        }
    }
}
