using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;
using IMemoryCache = Redoak.Core.Cache.Interface.IMemoryCache;
using MemoryCache = Redoak.Core.Cache.Service.MemoryCache;

namespace Redoak.Backoffice.Autofac
{
    public class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<RoleStore<IdentityRole>>()
            //    .As<IRoleStore<ApplicationRole>>()
            //    .SingleInstance();

            //builder.RegisterType<RoleValidator<IdentityRole>>()
            //    .As<RoleValidator<ApplicationRole>>()
            //    .SingleInstance();

            //builder.RegisterType<RoleManager<IdentityRole>>()
            //    .SingleInstance();

            builder.RegisterType<MemoryCache>()
                .WithParameter("optionsAccessor", new MemoryCacheOptions())
                .As<IMemoryCache>()
                .SingleInstance();

            builder.RegisterType<CacheService>()
                //.WithParameters(new List<Parameter>()
                //{
                //    new NamedParameter("roleManager", new RoleManager<ApplicationRole>())
                //})
                .As<ICacheService>()
                .SingleInstance();
            //RoleManager<ApplicationRole> roleManager)
            base.Load(builder);
        }
    }
}