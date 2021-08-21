using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class UserRepositoryTest
    {

        private readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var ioc = Startup.IoC();
            _userRepository = ioc.GetInstance<IUserRepository>();
        }

        [Theory]
        [InlineData("vrlouzada@hotmail.com", "@Abc123456")]
        public void GetUser(string login, string pass)
        {
            var user = _userRepository.Get(login, pass);

            Assert.NotNull(user);
            Assert.Equal(login, user.Login);
            Assert.Equal(pass, user.Pass);
        }

        [Theory]
        [InlineData("vrlouzada@gmail.com", "@Abc123456")]
        public void Create(string login, string pass)
        {
            var user = new User { Login = login, Pass = pass };
            var isAdded = _userRepository.Create(user);

            Assert.True(isAdded);
        }

        [Theory]
        [InlineData(2)]
        public void Get(int userId)
        {
            var user = _userRepository.Get(userId);

            Assert.NotNull(user);
        }
    }
}
