using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum Gen
{
    Male,
    Female
}

public enum Animal
{
    Dog,
    Cat,
    Fish,
    Turtle,
    Rabbit,
    Parrot,
    Hamster
}

namespace Pets_MS.Data
{
    public class Pet
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public Animal Species { get; private set; }
        public Gen Genre { get; private set; }
        public string Username { get; private set; }
        public string Description { get; private set; }
        public Location Location { get; set; }
        public DateTime BirthDate { get; private set; }
        public Guid LocationId { get; private set; }
        public string ImagePath { get; set; }


        private Pet()
        {

        }

        public static Pet Create(Guid id, string name, Animal species, Gen genre, string username, string description, DateTime birthDate, Guid locationId, string imagePath)
        {
            return new Pet
            {
                Id = id,
                Name = name,
                Species = species,
                Genre = genre,
                Username = username,
                Description = description,
                BirthDate = birthDate,
                LocationId= locationId,
                ImagePath = imagePath

            };
        }
    }
}
