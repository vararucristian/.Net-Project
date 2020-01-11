using MediatR;
using Pets_MS.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pets_Ms.Business.Commands;
using Pets_MS.DTO;
using System;
using System.IO;
static class Constants
{
    public const double PI = 3.14159265358979;
    public const double oneKmInDegreesLatitude = 0.0090437173295711;
}

namespace Pets_MS.Business.Handlers
{
    public class GetPetsByLocationQueryHandler : IRequestHandler<GetPetsByLocationQuery, List<Dictionary<string , object>>>
    {
        private readonly PetContext PetContext;

        public GetPetsByLocationQueryHandler(PetContext petContext)
        {
            PetContext = petContext;
        }

        public async Task<List<Dictionary<string, object>>> Handle(GetPetsByLocationQuery request, CancellationToken cancellationToken)
        {
            double distanceInDegreesLatitude = request.Distance * Constants.oneKmInDegreesLatitude;
            double distanceInDegreesLongitude = request.Distance * (1 / (111.320 * Math.Cos((request.Latitude * Constants.PI) / 180)));
            var pets = PetContext.Pets.Where(p => p.Species == request.Species
                                             && p.Location.Latitude <= (request.Latitude + distanceInDegreesLatitude) && p.Location.Latitude >= (request.Latitude - distanceInDegreesLatitude)
                                             && p.Location.Longitude <= (request.Longitude + distanceInDegreesLongitude) && p.Location.Longitude >= (request.Longitude - distanceInDegreesLongitude)
                                            ).OrderBy(p=> 6.371*2*Math.Atan2(Math.Sqrt(Math.Pow(Math.Sin(Math.Abs(p.Location.Latitude-request.Latitude)/2),2)+Math.Cos(p.Location.Latitude)*Math.Cos(request.Latitude)+ Math.Pow(Math.Sin(Math.Abs(p.Location.Latitude - request.Latitude) / 2), 2)), Math.Sqrt(1- (Math.Pow(Math.Sin(Math.Abs(p.Location.Latitude - request.Latitude) / 2), 2)) + Math.Cos(p.Location.Latitude) * Math.Cos(request.Latitude) + Math.Pow(Math.Sin(Math.Abs(p.Location.Latitude - request.Latitude) / 2), 2)))).ToList();
            var response = new List<Dictionary<string, object>>();
            foreach (Pet pet in pets)
            {

                var entity = new Dictionary<string, object>();
                var location = PetContext.Locations.Where(l => l.Id == pet.LocationId).Select(l => new { l.Latitude, l.Longitude }).FirstOrDefault();
                var image = "";
                try
                {
                    image = Convert.ToBase64String(File.ReadAllBytes(pet.ImagePath));
                }
                catch (Exception) { }
                entity.Add("pet", pet);
                entity.Add("location", location);
                entity.Add("image", image);
                response.Add(entity);
            }
            return response;
        }
    }
}