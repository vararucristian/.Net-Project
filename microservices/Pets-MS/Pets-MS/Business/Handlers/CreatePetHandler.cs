using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pets_MS.Data;
using Pets_MS.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;

namespace Users_MS.Business.Handlers
{
    public class CreatePetHandler : IRequestHandler<CreatePet, Dictionary<string, object>>
    {
        private readonly PetContext PetContext;

        public CreatePetHandler(PetContext petContext)
        {
            PetContext = petContext;

        }

        public async Task<Dictionary<string, object>> Handle(CreatePet request, CancellationToken cancellationToken)
        {
            
            bool succes = true;
            var response = new Dictionary<string, object>();
            Guid locationID;
            string imagePath = null;
            Guid id =  Guid.NewGuid();
            if (request.ImageData != null)
            {
                imagePath = saveImage(request, id);

            }

            var location = Location.Create(request.Latitude, request.Longitude);
            try
            {
                
                PetContext.Locations.Add(location);
                await PetContext.SaveChangesAsync(cancellationToken);
                locationID = location.Id;
            }
            catch (DbUpdateException)
            {
                locationID = PetContext.Locations.Where(l => l.Latitude == request.Latitude && l.Longitude == request.Longitude).Select(l => l.Id).FirstOrDefault();
                PetContext.Locations.Remove(location);
            }
            try
            {
                var pet = Pet.Create(id, request.Name, request.Species, request.Genre, request.Username, request.Description, request.BirthDate, locationID, imagePath);
                PetContext.Pets.Add(pet);
                await PetContext.SaveChangesAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {
                succes = false;
            }

            response.Add("succes", succes);
            return response;

            }
        private string saveImage(CreatePet request, Guid  id)
        {
            string imagePath = "PetsImages\\" + id + ".jpg";
            var imageDataByteArray = Convert.FromBase64String(request.ImageData);
            var imageDateStream = new MemoryStream(imageDataByteArray);
            imageDateStream.Position = 0;
            FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);
            imageDateStream.WriteTo(file);
            imagePath = Path.GetFullPath(imagePath);
            file.Close();
            imageDateStream.Close();
            return imagePath;
        }
    }
}
