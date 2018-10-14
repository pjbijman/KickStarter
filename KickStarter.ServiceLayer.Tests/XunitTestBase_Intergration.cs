using KickStarter.ServiceLayer.Tests.Resolvers;
using System;

namespace KickStarter.ServiceLayer.Tests
{
    public class XunitTestBase_Intergration : IDisposable
    {
        public ClientResolver cl;

        public XunitTestBase_Intergration()
        {
            var cl = ClientResolver.Instance;
        }

        public void Dispose()
        {
            throw new NotImplementedException("Dispose not implemented for XunitTestBase_Intergration");
        }
    }
}
