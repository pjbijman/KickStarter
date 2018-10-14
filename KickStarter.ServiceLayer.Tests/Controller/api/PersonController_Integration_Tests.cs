using KickStarter.ServiceLayer.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KickStarter.ServiceLayer.Tests.Controller.api
{
    public class PersonController_Integration_Tests : XunitTestBase_Intergration
    {

        [Fact]
        public async Task Can_Service_Build_client()
        {
            //Todo: finish test
            //var client = new TestClientProvider().Client;

            // var respons = await client.GetAsync("api/Person/GetPersonsList");
            Assert.True(true);
        }
    }
}
