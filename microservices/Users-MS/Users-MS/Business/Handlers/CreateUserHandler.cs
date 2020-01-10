using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Data;
using Users_MS.DTO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

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
            string errorMessage = "";

            string imagePath = null;
            if (request.ImageData != null)
            {
                imagePath = saveImage(request);

            }

            byte[] passwordBytes = Encoding.ASCII.GetBytes(request.Password);
            SHA256 passwordSHA256 = SHA256.Create();
            byte[] hashValue = passwordSHA256.ComputeHash(passwordBytes);
            string passwordHash = BitConverter.ToString(hashValue);
            passwordHash = passwordHash.Replace("-", "");
            var user = User.Create(request.FirstName, request.LastName, request.UserName, request.Email, passwordHash, imagePath);

            if (CheckEmail(request.Email))
            {
                if (CheckPasswordStreinght(request.Password))
                {
                    if (request.Password == request.ConfirmPassword)
                    {
                        try
                        {
                            UserContext.Users.Add(user);
                            await UserContext.SaveChangesAsync(cancellationToken);
                        }
                        catch (InvalidOperationException e)
                        {
                            succes = false;

                        }
                        catch (DbUpdateException e)
                        {

                            succes = false;
                            errorMessage = e.ToString();
                            if (e.ToString().Contains("'AlternateKey_UserName'"))
                            {
                                errorMessage = "The username is already used!";
                            }
                            else
                            {
                                if (e.ToString().Contains("'AlternateKey_Email'"))
                                {
                                    errorMessage = "The email address is already used!";
                                }
                            }

                        }
                    }
                    else
                    {
                        succes = false;
                        errorMessage = "Passwords dont match";
                    }
                }
                else
                {
                    succes = false;
                    errorMessage = "Sorry ,Your Password most contain at least one capital letter, one lower case letter , one number, one special character, and should be between 6 and 16 chracters!";
                }
            }
            else
            {
                succes = false;
                errorMessage = "Please enter a valid email address";
            }
            response.Add("succes", succes);
            response.Add("user", user);
            response.Add("error_message", errorMessage);
            return response;

        }

        private bool CheckEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private string saveImage(CreateUser request)
        {
            string imagePath = "UsersImages\\" + request.UserName + ".jpg";
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

        private bool CheckPasswordStreinght(string password)
        {
            
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,16}$";
            Match match = Regex.Match(password, pattern);
            if (password != string.Empty && match.Success)
            {
                return true;    
            }
            else
            {
                return false;
            }

        }
    }
}
