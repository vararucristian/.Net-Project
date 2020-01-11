using MediatR;
using Pets_MS.Data;
using Pets_MS.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                var image = Convert.ToBase64String(File.ReadAllBytes(pet.ImagePath));

                entity.Add("pet", pet);
                entity.Add("location", location);
                entity.Add("image", image);
                response.Add(entity);
                
            }
            return response;
        }


    }
}
