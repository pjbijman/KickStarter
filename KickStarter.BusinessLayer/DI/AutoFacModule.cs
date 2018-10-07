using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace QuotationTool.BusinessLayer.DI
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("QuotationTool.BusinessLayer."))
                .Select(Assembly.LoadFrom);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new KickStarter.DataLayer.DI.AutoFacModule());
        }
    }
}