using MediatR;
using Pets_MS.Data;
using System;
using System.Collections.Generic;

namespace Pets_Ms.Business.Commands
{
    public class GetPetsByLocationQuery : IRequest<List<Dictionary<string, object>>>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GetPetsByLocationQuery(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
