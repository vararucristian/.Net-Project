using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;

namespace Pets_Ms.Business.Commands
{
    public class GetPetByIdQuery : IRequest<Dictionary<string, object>>
    {
        public Guid Id { get; set; }

        public GetPetByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}