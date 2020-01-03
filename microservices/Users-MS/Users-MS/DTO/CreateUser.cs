using MediatR;
using System.Collections.Generic;

namespace Users_MS.DTO
{
    public class CreateUser: IRequest<Dictionary<string, object>>
    {
        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public string UserName { get;  set; }

        public string Email { get;  set; }

        public string Password { get;  set; }

        public string ConfirmPassword { get; set; }

        public string ImageData { get; set; }
            
            

    }
}
