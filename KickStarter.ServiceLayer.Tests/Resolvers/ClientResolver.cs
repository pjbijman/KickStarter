using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace KickStarter.ServiceLayer.Tests.Resolvers
{
    public class ClientResolver
    {
        private static readonly object clientResolverLock = new object();
        private static Boolean clientInitialized = false;

        public HttpClient Client { get; private set; }

        private static ClientResolver instance;

        public static ClientResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientResolver();
                }
                return instance;
            }
        }

        public ClientResolver()
        {
            lock (clientResolverLock)
            {
                if (!clientInitialized)
                {
                    var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

                    Client = server.CreateClient();
                    clientInitialized = true;
                }
            }
        }
    }
}
