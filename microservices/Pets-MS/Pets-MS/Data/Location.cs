using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_MS.Data
{
    public class Location
    {
        public Guid Id { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public ICollection<Pet> Pets { get; private set; }

        private Location()
        {

        }

        public static Location Create(string country, string zipCode)
        {
            return new Location
            {
                Id = Guid.NewGuid(),
                Country = country,
                ZipCode= zipCode
            };
        }
    }
}
