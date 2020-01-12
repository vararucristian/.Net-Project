using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        public GetUserByUsernameQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<Dictionary<string, object>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var users = UserContext.Users;
            var image = "";
            var user = users.Where(u => u.UserName == request.UserName).FirstOrDefault();
            if (user == null)
            {
                response.Add("succes", false);
            }
            else
            {
                response.Add("succes", true);
                image = Convert.ToBase64String(File.ReadAllBytes(user.ImagePath));
            }
            response.Add("image", image);
            response.Add("user", user);
            return response;
            
        }
    }
}
