using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;


namespace Pets_Ms.Business.Commands
{
    public class GetPetsByLocationQuery : IRequest<List<Dictionary<string, object>>>
    {
        public Animal Species { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }

        public GetPetsByLocationQuery(Animal species, double latitude, double longitude, double distance)
        {
            Species = species;
            Latitude = latitude;
            Longitude = longitude;
            Distance = distance;
        }

    }
}
