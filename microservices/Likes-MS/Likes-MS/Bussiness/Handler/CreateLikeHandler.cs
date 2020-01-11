using Likes_MS.Data;
using Likes_MS.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Likes_MS.Bussiness.Handler
{


    public class CreateLikeHandler : IRequestHandler<CreateLike, Dictionary<string, object>>
    {
        private readonly LikeContext LikeContext;
        private static readonly HttpClient client = new HttpClient();
        public CreateLikeHandler(LikeContext likeContext)
        {
            LikeContext = likeContext;
        }

        private async Task<string> GetEmailAddressAsync(string username)
        {
            string response = await client.GetStringAsync("https://localhost:5001/api/users/username");
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(response);

            return userResponse.user.Email;
        }

        private bool SendEmail(string eMail, string username)
        {
            bool emailSent = true;
            try
            {
                string templatePath = "..\\..\\..\\templates\\mail.html";
                string messageBody = System.IO.File.ReadAllText(templatePath);
                messageBody = messageBody.Replace("{username}", username);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("happypet.application@gmail.com");
                message.To.Add(new MailAddress(eMail));
                message.Subject = "New Like";
                message.IsBodyHtml = true;
                message.Body = messageBody;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("happypet.application@gmail.com", "happy12#pet");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception)
            {
                emailSent = false;
            }

            return emailSent;
        }

        public async Task<Dictionary<string, object>> Handle(CreateLike request, CancellationToken cancellationToken)
        {
            string requestAddress= "https://localhost:5001/api/users/username/"+request.Username;
            string userResponseString = await client.GetStringAsync(requestAddress);
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseString);
            var response = new Dictionary<string, object>();
            var succes = true;
            var emailSent = SendEmail(userResponse.user.Email, request.Username);
            var like = Like.Create(request.PersonId, request.PetId, request.PersonLike, request.PetLike);
            try
            {

                LikeContext.Likes.Add(like);
                await LikeContext.SaveChangesAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {
                succes = false;
            }

            response.Add("succes", succes);
            response.Add("like", like);
            response.Add("emailSent", emailSent);
            return response;

        }
    }
}
