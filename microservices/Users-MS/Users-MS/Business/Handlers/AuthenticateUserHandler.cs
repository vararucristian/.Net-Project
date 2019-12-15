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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Users_MS.Business.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUser, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        public AuthenticateUserHandler(UserContext userContext, IMediator mediator)
        {
            UserContext = userContext;
            _mediator = mediator;

        }

        public async Task<Dictionary<string, object>> Handle(AuthenticateUser request, CancellationToken cancellationToken)
        {
            bool succes = false;
            var response = new Dictionary<string, object>();
            var getResponse = await _mediator.Send(new GetUserByUsernameAndPasswordQuery(request.Username, request.Password));
            var user = (User)getResponse["user"];
            string tokenData;
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("SecretSecretSecretSecretSecretSecret"); // To do a secret conviguration class
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,
                              user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenData = tokenHandler.WriteToken(token);
                succes = true;
                response.Add("Token", tokenData);

            }
            response.Add("succes", succes);
            response.Add("user", user);
            return response;

        }
    }
}
