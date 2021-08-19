using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Helper;
using DOTZ.Repository.Bases;
using DOTZ.Repository.Repositories;
using DOTZ.ServicesDomain.Services;
using HCI.EasySimpleInjector;
using Microsoft.AspNetCore.Http;
using Moq;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.CrossCutting.IoC
{
    public static class Startup
    {

        public static Container _container;


        public static Container IoC()
        {
            var lifestyle = Lifestyle.Transient;

            var container = new Container();
            Register.RegisterNamespace<UserRepository>(container, lifestyle, "Repository");
            Register.RegisterNamespace<TokenService>(container, lifestyle, "Service");

            container.Register(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            IUserSession userSession = GenerateUserMock();
            container.Register(() => { return userSession; }, lifestyle);

            container.Register(typeof(IConnection), typeof(Connection), lifestyle);


            return container;
        }

        private static IUserSession GenerateUserMock()
        {
            var userSesion = new Mock<IUserSession>();
            userSesion.Setup(_ => _.GetCostumer()).Returns(new Domain.Entity.Costumer() { UserId = 2, FirstName = "Victor", LastName = "Louzada" });
            userSesion.Setup(_ => _.FirstName).Returns("Victor");
            userSesion.Setup(_ => _.UserId).Returns(2);
            return userSesion.Object;
        }
    }
}
