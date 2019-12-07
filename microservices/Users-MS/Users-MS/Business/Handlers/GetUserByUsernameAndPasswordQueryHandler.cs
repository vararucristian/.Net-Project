﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class GetUserByUsernameAndPasswordQueryHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        public GetUserByUsernameAndPasswordQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }

        public async Task<Dictionary<string, object>> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var users = UserContext.Users;
            var user = users.Where(u => u.UserName == request.UserName && u.Password == request.Password).FirstOrDefault();
            if (user == null)
            {
                response.Add("succes", false);
            }
            else
            {
                response.Add("succes", true);
            }
            response.Add("user", user);
            return response;
            
        }
    }
}
