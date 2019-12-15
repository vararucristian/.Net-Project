using MediatR;
using Pets_MS.Data;
using Pets_MS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets_MS.Business.Handlers
{
    public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, List<Dictionary<string, object>>>
    {
        private readonly PetContext PetContext;

        public GetPetsQueryHandler(PetContext petContext)
        {
            PetContext = petContext;
        }

        public async Task<List<Dictionary<string, object>>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var response =new List<Dictionary<string, object>>();
            var pets = PetContext.Pets.ToList();
            foreach (Pet pet in pets)
            {
                var entity = new Dictionary<string, object>();
                var location = PetContext.Locations.Where(l => l.Id == pet.LocationId).Select(l => Coordinate.Create(l.Latitude, l.Longitude)).FirstOrDefault();
                entity.Add("pet", pet);
                entity.Add("location", location);
                response.Add(entity);
            }
            return response;
        }


    }
}
