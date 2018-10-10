using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Servives.ClientModels;
using KickStarter.ServiceLayer.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace KickStarter.ServiceLayer.Tests.Controller.api
{

    public class PersonController_Tests : XunitTestBase
    {
        //Initialize AutoMapper and object setup is done in the base constructor

        [Theory]
        [InlineData(1)]
        public async Task GetPersonById_Shuld_return_OkObjectResult_with_valid_id(int id)
        {
            // Setup
             _getPersonComponent.Setup(x => x.Execute(It.IsAny<int>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            var result = await personController.GetPersonById(id);

            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();
            Assert.True(expectedType.Equals(actualType));

            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.Execute(id), Times.Once);
        }

        [Theory]
        [InlineData(-1)]
        public async Task GetPersonById_Shuld_return_StatusCodeResult_204_when_no_person_found(int id)
        {
            // Setup
            _getPersonComponent.Setup(x => x.Execute(It.IsAny<int>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            var result = await personController.GetPersonById(id);

            var expectedType = new StatusCodeResult(204).GetType();
            var actualType = result.GetType();
            Assert.True(expectedType.Equals(actualType));

            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.Execute(id), Times.Once);
        }
    }

}

