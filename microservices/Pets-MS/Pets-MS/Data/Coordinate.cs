using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_MS.Data
{
    public class Coordinate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; } 

        private Coordinate()
        {

        }

        public static Coordinate Create(double latitude, double longitude)
        {
            return new Coordinate
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }
    }
}