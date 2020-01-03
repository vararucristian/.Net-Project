using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Pets_MS.DTO
{
    public class DeletePet : IRequest<Dictionary<string, object>>
    {
        public DeletePet(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
