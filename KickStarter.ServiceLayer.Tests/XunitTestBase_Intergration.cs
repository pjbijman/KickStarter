using KickStarter.ServiceLayer.Tests.Resolvers;
using System;

namespace KickStarter.ServiceLayer.Tests
{
    public class XunitTestBase_Intergration : IDisposable
    {
        public ClientResolver clientResolver;

        public XunitTestBase_Intergration()
        {
            clientResolver = ClientResolver.Instance;
        }

        public void Dispose()
        {
            throw new NotImplementedException("Dispose not implemented for XunitTestBase_Intergration");
        }
    }
}
