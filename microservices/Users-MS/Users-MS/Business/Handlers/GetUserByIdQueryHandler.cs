using MediatR;
using Users_Ms.Business.Commands;
using Users_Ms.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Users_Ms.Business.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;

        public GetUserByIdQueryHandler(UserContext userContext)
        {
            UserContext = userContext;
        }
        public async Task<Dictionary<string, object>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var response = new Dictionary<string, object>();
            var users = UserContext.Users;
            var user = users.Where(u => u.Id == request.Id).FirstOrDefault();
            if(user == null)
            {
                response.Add("succes", false);
            }
            else
            {
                response.Add("succes", true);
            }

            byte[] imageArray = System.IO.File.ReadAllBytes(user.ImagePath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            response.Add("user", user);
            response.Add("imageData", base64ImageRepresentation);

            return response;
        }
    }
}
