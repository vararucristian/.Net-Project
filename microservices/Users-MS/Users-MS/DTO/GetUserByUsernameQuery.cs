using MediatR;
using System.Collections.Generic;
using Users_Ms.Data;

namespace Users_MS.DTO
{
    public class GetUserByUsernameQuery : IRequest<Dictionary<string, object>>
    {
        public string UserName { get; private set; }
        public GetUserByUsernameQuery(string userName)
        {
            UserName = userName;
        
        }


    }

}
