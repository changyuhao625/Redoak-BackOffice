using Autofac;
using Redoak.Dal.Repository;
using Redoak.Domain.Interface;
using Redoak.Domain.Service;

namespace Redoak.Backoffice.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseService>()
                .SingleInstance();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();

            builder.RegisterType<ManageService>()
                .As<IManageService>()
                .SingleInstance();

            builder.RegisterType<UserRoleService>()
                .As<IUserRoleService>()
                .SingleInstance();

            builder.RegisterType<UserRepository>()
                .As<UserRepository>();
        }
    }
}