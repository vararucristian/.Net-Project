using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;

namespace Pets_Ms.Business.Commands
{
    public class GetPetsBySpeciesQuery : IRequest<List<Dictionary<string, object>>>
    {
        public Animal Species { get; set; }

        public GetPetsBySpeciesQuery(Animal species)
        {
            Species=species;
        }

    }
}