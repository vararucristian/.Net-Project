using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;


namespace Pets_MS.DTO
{
    public class UpdatePet : IRequest<Dictionary<string, object>>
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
