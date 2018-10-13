using Autofac;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Kickstarter.BusinessLayer.DI
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("Kickstarter."))
                .Select(Assembly.LoadFrom);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterModule(new KickStarter.DataLayer.DI.AutoFacModule());
        }
    }
}