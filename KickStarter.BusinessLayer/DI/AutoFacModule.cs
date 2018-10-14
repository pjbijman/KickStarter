using Autofac;
//using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using KickStarter.DataLayer.EntityFramework.DataRepositories;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Kickstarter.BusinessLayer.DI
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                //.Where(filePath => Path.GetFileName(filePath).StartsWith("KickStarter.ServiceLayer."))
                .Select(Assembly.LoadFrom);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterGeneric(typeof(ServiceProvider<>)).As(typeof(System.IServiceProvider<>));
            builder.RegisterGeneric(typeof(ReadOnlyRepository<>)).As(typeof(IReadOnlyRepository<>));
            builder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IDataRepository<>));
        }
    }
}