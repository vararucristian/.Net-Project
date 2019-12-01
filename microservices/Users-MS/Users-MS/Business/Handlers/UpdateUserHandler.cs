using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Business.Commands;
using Users_Ms.Data;

namespace Users_MS.Business.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        public UpdateUserHandler(UserContext userContext, IMediator mediator)
        {
            UserContext = userContext;
            _mediator = mediator;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request.Id));
            if (user != null)
            {
                user.Email = request.Email;
                user.Password = request.Password;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                UserContext.SaveChanges();
            }
            return user;            
        }
    }
}
