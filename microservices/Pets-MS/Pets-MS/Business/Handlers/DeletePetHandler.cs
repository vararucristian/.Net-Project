using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pets_MS.Data;
using Pets_MS.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pets_Ms.Business.Commands;

namespace Pets_MS.Business.Handlers
{
    public class DeletePetHandler : IRequestHandler<DeletePet, Dictionary<string, object>>
    {
        private readonly PetContext PetContext;
        private readonly IMediator _mediator;
        public DeletePetHandler(PetContext petContext, IMediator mediator)
        {
            PetContext = petContext;
            _mediator = mediator;
        }


        public async Task<Dictionary<string, object>> Handle(DeletePet request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, object>();
            var getResponse = await _mediator.Send(new GetPetByIdQuery(request.Id));
            bool exists = (bool)getResponse["succes"];
            if (exists.Equals(false))
            {
                response.Add("succes", false);
                return response;
            }
            var pet = (Pet)getResponse["pet"];
            var ll =(Coordinate)getResponse["location"];
            Location location = PetContext.Locations.Where(l => l.Latitude == ll.Latitude && l.Longitude == ll.Longitude ).FirstOrDefault();
            location.Pets.Remove(pet);
            pet.Location = location;
            PetContext.Pets.Remove(pet);
            PetContext.SaveChanges();
            response.Add("succes", true);
            return response;
        }
    }
}
