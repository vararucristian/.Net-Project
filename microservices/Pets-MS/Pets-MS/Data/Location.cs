using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_MS.Data
{
    public class Location
    {
        public Guid Id { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public ICollection<Pet> Pets { get; private set; }

        private Location()
        {

        }

        public static Location Create(double latitude, double longitude)
        {
            return new Location
            {
                Id = Guid.NewGuid(),
                Latitude = latitude,
                Longitude= longitude
            };
        }
    }
}
