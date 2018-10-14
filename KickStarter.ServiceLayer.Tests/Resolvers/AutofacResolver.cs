using Autofac;

using System;

namespace KickStarter.ServiceLayer.Tests.Resolvers
{
    public class AutofacResolver
    {
        private static readonly object autofacLock = new object();
        private static Boolean autofacInitialized = false;
        public IContainer Container { get; set; }
        private static AutofacResolver instance;
        public static AutofacResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AutofacResolver();
                }
                return instance;
            }
        }

        public AutofacResolver()
        {
            lock (autofacLock)
            {
                if (!autofacInitialized)
                {
                    var builder = new ContainerBuilder();

                    builder.RegisterModule(new Kickstarter.BusinessLayer.DI.AutoFacModule());
                    builder.RegisterModule(new DataLayer.DI.AutoFacModule());

                    builder.RegisterType<DataLayer.EntityFramework.UnitOfWork>().As<DataLayer.DI.IUnitOfWork>();
                    builder.RegisterType<DataLayer.EntityFramework.DataContext>().As<DataLayer.EntityFramework.IDataContext>();

                    builder.RegisterType<BusinessLayer.Components.BusinessComponent>().As<BusinessLayer.Components.Interfaces.IBusinessComponent>();

                    builder.RegisterType<ServiceLayer.Controllers.api.PersonController>().As<ServiceLayer.Controllers.api.Interfaces.IPersonController>();
                    builder.RegisterType<BusinessLayer.Components.Person.SavePersonComponent>().As<BusinessLayer.Components.Interfaces.ISavePersonComponent>();
                    builder.RegisterType<BusinessLayer.Components.Person.GetPersonsComponent>().As<BusinessLayer.Components.Interfaces.IGetPersonsComponent>();
                    builder.RegisterType<BusinessLayer.Components.Person.DeletePersonComponent>().As<BusinessLayer.Components.Interfaces.IDeletePersonComponent>();

                    Container = builder.Build();

                    autofacInitialized = true;
                }
            }
        }
    }
}
