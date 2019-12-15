using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;

namespace Pets_Ms.Business.Commands
{
    public class GetPetsByUsernameQuery : IRequest<List<Dictionary<string, object>>>
    {
        public string Username { get; set; }

        public GetPetsByUsernameQuery(string username)
        {
            Username = username;
        }

    }
}