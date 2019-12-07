using MediatR;
using System;
using System.Collections.Generic;

namespace Users_Ms.Data
{
    public class UPdateUser: IRequest<Dictionary<string, object>>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }

}
