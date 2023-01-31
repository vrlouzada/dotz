using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Entity;
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

        //[Theory]
        //[InlineData("taynara@hotmail.com", "123456", "123456", "taynara", "Louzada")]
        //public void CreateCostumer(string login, string pass, string passrepeat, string firstName, string lastName)
        //{
        //    var request = new LogonRequest
        //    {
        //        Login = login,
        //        Pass = pass,
        //        PassRepeat = passrepeat,
        //        FirstName = firstName,
        //        LastName = lastName
        //    };

        //    var auth = _accountService.CreateUser(request);

        //    Assert.NotNull(auth);
        //    Assert.NotNull(auth.Token);
        //}
    }
}
