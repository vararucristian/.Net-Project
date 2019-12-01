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
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        public DeleteUserHandler(UserContext userContext, IMediator mediator)
        {
            UserContext = userContext;
            _mediator = mediator;
        }


        public async Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request.Id));
            if (user != null)
            {
                UserContext.Users.Remove(user);
                UserContext.SaveChanges();
                
            }
            return user;
        }
    }
}
