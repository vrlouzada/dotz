using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Helper;
using DOTZ.Domain.Resources;
using DOTZ.Repository.Bases;
using DOTZ.Repository.Repositories;
using DOTZ.ServicesDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using SimpleInjector;
using System.Diagnostics;

namespace DOTZ.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddScoped<IConnection, Connection>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICostumerRepository, CostumerRepository>();

            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<ITokenService, TokenService>();


            service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<IUserSession, UserSession>();

            return service;
        }


        private static IOptions<AppSettings> GenerateOptions()
        {
            var settings = new Mock<IOptions<AppSettings>>();
            settings.Setup(a => a.Value).Returns(GetSettings());
            return settings.Object;
        }

        private static AppSettings GetSettings()
        {
            var settings = new AppSettings
            {
                Secret = Global.Secret
            };

            return settings;
        }
    }
}
