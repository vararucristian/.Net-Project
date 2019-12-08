using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Business.Commands;
using Users_Ms.Data;

namespace Users_MS.Business.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UPdateUser, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public UpdateUserHandler(UserContext userContext, IMediator mediator)
        {
            UserContext = userContext;
            _mediator = mediator;
        }

        public async Task<Dictionary<string, object>> Handle(UPdateUser request, CancellationToken cancellationToken)
        {
            bool succes = false;
            var response = new Dictionary<string, object>();
            var getResponse = await _mediator.Send(new GetUserByIdQuery(request.Id));
            var user = (User)getResponse["user"];
            if (user != null)
            {
                try
                {

                    user.Email = request.Email;
                    user.Password = request.Password;
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    UserContext.SaveChanges();
                    succes = true;
                }
                catch (DbUpdateException)
                {
                    logger.Info("Missing data from json body!");
                }


            }
            response.Add("succes", succes);
            response.Add("user", user);
            return response;
        }
    }
}
