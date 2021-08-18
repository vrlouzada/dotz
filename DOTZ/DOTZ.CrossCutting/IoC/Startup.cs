using DOTZ.Domain.Contracts.Repository;
using DOTZ.Repository.Bases;
using DOTZ.Repository.Repositories;
using DOTZ.ServicesDomain.Services;
using HCI.EasySimpleInjector;
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

            container.Register(typeof(IConnection), typeof(Connection), lifestyle);


            return container;
        }

    }
}
