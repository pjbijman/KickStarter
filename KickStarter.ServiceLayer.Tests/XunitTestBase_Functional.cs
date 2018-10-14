using KickStarter.ServiceLayer.Controllers.api;
using KickStarter.ServiceLayer.Tests.Resolvers;
using System;

namespace KickStarter.ServiceLayer.Tests
{
    public class XunitTestBase_Functional : IDisposable
    {
        // Controllers
        public PersonController personController;
        public AutofacResolver af;


        public XunitTestBase_Functional()
        {
            //Resolve the Mapper
            var mp = MapperResolver.Instance;
            af = AutofacResolver.Instance;
        }

        public void Dispose()
        {
            // Dispose repositories
            //  _persosnRepository..Dispose();
            // Dispose controllers
            // personController.Dispose();
        }
    }
}
