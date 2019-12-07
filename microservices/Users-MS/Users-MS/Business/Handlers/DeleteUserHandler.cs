using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Business.Commands;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        public DeleteUserHandler(UserContext userContext, IMediator mediator)
        {
            UserContext = userContext;
            _mediator = mediator;
        }


        public async Task<Dictionary<string, object>> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var getRresponse = await _mediator.Send(new GetUserByIdQuery(request.Id));
            var user = (User)getRresponse["user"];
            if (user != null)
            {
                UserContext.Users.Remove(user);
                UserContext.SaveChanges();
                response.Add("succes", true);
            }
            else
            {
                response.Add("succes", false);
            }
            return response;
        }
    }
}
