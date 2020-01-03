using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Ms.Data;
using Users_MS.DTO;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Users_MS.Business.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, Dictionary<string, object>>
    {
        private readonly UserContext UserContext;
        private readonly IMediator _mediator;
        private readonly IConfiguration Configuration;
        public AuthenticateUserHandler(UserContext userContext, IMediator mediator, IConfiguration configuration)
        {
            UserContext = userContext;
            _mediator = mediator;
            Configuration = configuration;

        }

        public async Task<Dictionary<string, object>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            bool succes = false;
            var response = new Dictionary<string, object>();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(request.Password);
            SHA256 passwordSHA256 = SHA256.Create();
            byte[] hashValue = passwordSHA256.ComputeHash(passwordBytes);
            string passwordHash = BitConverter.ToString(hashValue);
            passwordHash = passwordHash.Replace("-", "");
            var user = UserContext.Users.Where(u => u.Password == passwordHash && u.UserName == request.Username).FirstOrDefault();

            string tokenData;
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenKeys").GetSection("DefaultKey").Value));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim("Username",
                              "Password")
                };
                var token = new JwtSecurityToken("https://localhost:5001", "https://localhost:5001", claims, DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credentials);
                tokenData = new JwtSecurityTokenHandler().WriteToken(token);
                succes = true;
                response.Add("Token", tokenData);

            }
            response.Add("succes", succes);
            response.Add("user", user);
            return response;

        }



    }
}
