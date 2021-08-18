using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class TokenService : ITokenService
    {

        private const string KEY = "be187b09f156ed142635484b81145a13";

        public string GenerateToken(Costumer costumer)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            //TODO: Passar a Key pelas variáveis ou pelo resource
            var key = Encoding.ASCII.GetBytes(KEY);

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
