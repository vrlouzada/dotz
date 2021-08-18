using DOTZ.Domain.Contracts.Repository;
using DOTZ.Repository.Bases;
using DOTZ.Repository.Repositories;
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

            var container = Register.RegisterNamespace<UserRepository>(lifestyle, "Repository");

            container.Register(typeof(IConnection), typeof(Connection), lifestyle);


            return container;
        }

    }
}
