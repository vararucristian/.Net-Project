using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_MS.Data
{
    public class Pet
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Species { get; private set; }
        public string Genre { get; private set; }
        public string Username { get; private set; }
        public string Description { get; private set; }
        public Location Location { get; set; }
        public DateTime BirthDate { get; private set; }
        public Guid LocationId { get; private set; }


        private Pet()
        {

        }

        public static Pet Create(string name, string species, string genre, string username, string description, DateTime birthDate, Guid locationId)
        {
            return new Pet
            {
                Id = Guid.NewGuid(),
                Name = name,
                Species = species,
                Genre = genre,
                Username = username,
                Description = description,
                BirthDate = birthDate,
                LocationId= locationId 
             
            };
        }
    }
}
