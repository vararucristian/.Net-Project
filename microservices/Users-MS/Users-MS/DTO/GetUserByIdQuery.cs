using MediatR;
using Users_Ms.Data;
using System;
using System.Collections.Generic;

namespace Users_Ms.Business.Commands
{
    public class GetUserByIdQuery : IRequest<Dictionary<string, object>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}
