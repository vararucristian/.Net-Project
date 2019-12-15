using MediatR;
using System.Collections.Generic;

namespace Users_MS.DTO
{
    public class AuthenticateUser : IRequest<Dictionary<string, object>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
