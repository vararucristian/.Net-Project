using MediatR;
using Pets_MS.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pets_Ms.Business.Commands;

namespace Pets_MS.Business.Handlers
{
    public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, Dictionary<string, object>>
    {
        private readonly PetContext PetContext;

        public GetPetByIdQueryHandler(PetContext petContext)
        {
            PetContext = petContext;
        }
        public async Task<Dictionary<string, object>> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
        {

            var response = new Dictionary<string, object>();
            var pets = PetContext.Pets;
            var pet = pets.Where(u => u.Id == request.Id).FirstOrDefault();
            var location = PetContext.Locations.Where(l => l.Id == pet.LocationId).Select(l  => new { l.ZipCode, l.Country }).FirstOrDefault();
            if (pet == null)
            {
                response.Add("succes", false);
            }
            else
            {
                response.Add("succes", true);
            }
            response.Add("pet", pet);
            response.Add("location", location);
            return response;
        }
    }
}