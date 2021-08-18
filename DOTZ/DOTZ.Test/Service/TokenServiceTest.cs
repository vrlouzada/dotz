using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class TokenServiceTest
    {

        private readonly ITokenService _tokenService;


        public TokenServiceTest()
        {
            var ioc = Startup.IoC();
            _tokenService = ioc.GetInstance<ITokenService>();
        }


        [Theory]
        [InlineData(1, "Victor", "Louzada")]
        public void GetToken(int userId, string firstName, string lastName)
        {
            var costumer = new Costumer
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName
            };

            var token = _tokenService.GenerateToken(costumer);

            Assert.NotNull(token);
        }

    }
}
