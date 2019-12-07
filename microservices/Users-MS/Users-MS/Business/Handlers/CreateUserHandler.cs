using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;

        public CreateUserHandler(UserContext userContext)
        {
            UserContext = userContext;

        }

        public async Task<Dictionary<string, object>> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            bool succes = true;
            var response = new Dictionary<string, object>();
            
            var user = User.Create(request.FirstName, request.LastName, request.UserName, request.Email, request.Password);
            try
            {
                UserContext.Users.Add(user);
                await UserContext.SaveChangesAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {

                succes = false;

                
            }

            response.Add("succes", succes);
            response.Add("user", user);
            return response;

        }
    }
}
