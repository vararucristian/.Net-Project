using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;


namespace Pets_MS.DTO
{
    public class CreatePet:IRequest<Dictionary<string, object>>
    {

        public string Name { get;  set; }
        public Animal Species { get;  set; }
        public Gen Genre { get;  set; }
        public string Username { get;  set; }
        public string Description { get;  set; }
        public DateTime BirthDate { get;  set; }
        public double Latitude { get;  set; }
        public double Longitude { get;  set; }

    }
}
