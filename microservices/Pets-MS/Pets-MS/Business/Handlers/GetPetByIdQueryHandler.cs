using MediatR;
using Pets_MS.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pets_Ms.Business.Commands;
using System;

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
            var pet = pets.Where(p => p.Id == request.Id).FirstOrDefault();
            try 
            { 
                var location = PetContext.Locations.Where(l => l.Id == pet.LocationId).Select(l  => Coordinate.Create(l.Latitude, l.Longitude)).FirstOrDefault();
                response.Add("pet", pet);
                response.Add("location", location);
            }
            catch (InvalidOperationException) 
            {
                response.Add("succes", false);
            }
            if (pet != null)  
            {
                response.Add("succes", true);
            }
            return response;
        }
    }
}