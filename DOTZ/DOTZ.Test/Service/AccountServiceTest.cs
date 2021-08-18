using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class AccountServiceTest
    {

        private readonly IAccountService _accountService;


        public AccountServiceTest()
        {
            var ioc = Startup.IoC();
            _accountService = ioc.GetInstance<IAccountService>();
        }


        [Theory]
        [InlineData("vrlouzada@hotmail.com", "@Abc123456")]
        public void Authenticate(string login, string pass)
        {
            var request = new AuthRequest
            {
                Username = login,
                Password = pass
            };

            var response = _accountService.Authenticate(request);

            Assert.NotNull(response);
            Assert.NotNull(response.Token);
        }

    }
}
