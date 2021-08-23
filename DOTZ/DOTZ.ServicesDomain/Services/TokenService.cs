using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AppSettings> _config;


        public TokenService(IOptions<AppSettings> config)
        {
            _config = config;
        }

        public string GenerateToken(Costumer costumer)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
        
            var key = Encoding.ASCII.GetBytes(_config.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{costumer.FirstName} {costumer.LastName}"),
                    new Claim("UserId", costumer.UserId.ToString()),
                    new Claim("FistName", costumer.FirstName),
                    new Claim("LastName", costumer.LastName)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
