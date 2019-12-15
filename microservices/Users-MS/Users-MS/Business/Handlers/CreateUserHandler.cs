using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Data;
using Users_MS.DTO;

namespace Users_MS.Business.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;

        public CreateUserHandler(UserContext userContext)
        {
            UserContext = userContext;

        }

        public async Task<Dictionary<string, object>> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            bool succes = true;
            var response = new Dictionary<string, object>();

            
            string imagePath =null;
            if (request.ImageData != null)
            {
                imagePath = "UsersImages\\" + request.UserName + ".jpg";
                var imageDataByteArray = Convert.FromBase64String(request.ImageData);
                var imageDateStream = new MemoryStream(imageDataByteArray);
                imageDateStream.Position = 0;
                FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);
                imageDateStream.WriteTo(file);
                imagePath = Path.GetFullPath(imagePath);
                file.Close();
                imageDateStream.Close();

            }

            var user = User.Create(request.FirstName, request.LastName, request.UserName, request.Email, request.Password, imagePath);
            try
            {
                UserContext.Users.Add(user);
                await UserContext.SaveChangesAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {

                succes = false;

            }
            catch (DbUpdateException)
            {
                succes = false;
                                   
            }


            response.Add("succes", succes);
            response.Add("user", user);
            return response;

        }
    }
}
