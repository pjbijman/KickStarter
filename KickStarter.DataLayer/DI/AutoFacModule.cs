using Autofac;
using KickStarter.DataLayer.EntityFramework.DataRepositories;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KickStarter.DataLayer.DI
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("KickStarter."))
                .Select(Assembly.LoadFrom)
                .ToArray();

            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ReadOnlyRepository<>)).As(typeof(IReadOnlyRepository<>));
            builder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IDataRepository<>));
        }
    }
}