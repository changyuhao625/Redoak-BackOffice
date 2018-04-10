using Autofac;
using Redoak.Dal.Repository;
using Redoak.Domain.Interface;
using Redoak.Domain.Service;
using Redoak.Model.Models;

namespace Redoak.Backoffice.App_Start.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();
            builder.RegisterType<UserRepository>()
                .As<UserRepository>();
        }
    }
}