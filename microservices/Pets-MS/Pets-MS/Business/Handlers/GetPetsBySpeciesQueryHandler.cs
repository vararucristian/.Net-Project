using MediatR;
using Pets_MS.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pets_Ms.Business.Commands;
using Pets_MS.DTO;

namespace Pets_MS.Business.Handlers
{
    public class GetPetsBySpeciesQueryHandler : IRequestHandler<GetPetsBySpeciesQuery, List<Dictionary<string, object>>>
    {
        private readonly PetContext PetContext;

        public GetPetsBySpeciesQueryHandler(PetContext petContext)
        {
            PetContext = petContext;
        }
        public async Task<List<Dictionary<string, object>>> Handle(GetPetsBySpeciesQuery request, CancellationToken cancellationToken)
        {
            var pets = PetContext.Pets.Where(p => p.Species == request.Species).ToList();
            var response = new List<Dictionary<string, object>>();
            foreach (Pet pet in pets)
            {
                var entity = new Dictionary<string, object>();
                var location = PetContext.Locations.Where(l => l.Id == pet.LocationId).Select(l => new { l.Latitude, l.Longitude }).FirstOrDefault();
                entity.Add("pet", pet);
                entity.Add("location", location);
                response.Add(entity);
            }
            return response;
        }
    }
}
