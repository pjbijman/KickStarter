using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace KickStarter.ServiceLayer.Tests.Controller.api
{

    public class PersonController_Tests : XunitTestBase
    {
        //Initialize AutoMapper and object setup is done in the base constructor

        [Theory]
        [InlineData(1)]
        public async Task GetPersonById_Should_return_OkObjectResult_with_valid_id(int id)
        {
            // Setup
            Guid personId = Guid.NewGuid();
            _getPersonComponent.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            //Act
            var result = await personController.GetPersonById(personId);
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetPersonById(personId), Times.Once);
        }

        [Theory]
        [InlineData(-1)]
        public async Task GetPersonById_Should_return_StatusCodeResult_204_when_no_person_found(int id)
        {
            // Setup
            Guid personId = Guid.NewGuid();
            _getPersonComponent.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            // Act
            var result = await personController.GetPersonById(personId);
            var expectedType = new StatusCodeResult(204).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetPersonById(personId), Times.Once);
        }

        [Theory]
        [InlineData(-1)]
        public async Task GetAllPersons_Should_return_StatusCodeResult_204_when_no_records_found(int type)
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersons()).Returns(Task.FromResult(Dummies.GetPeronList(type)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new StatusCodeResult(204).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersons(), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        public async Task GetAllPersons_Should_return_NoContentResult_when_no_records_found(int type)
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersons()).Returns(Task.FromResult(Dummies.GetPeronList(type)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new NoContentResult().GetType();
            var actualType = result.GetType();

            // Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersons(), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetAllPersons_Should_return_OkObjectResult_when_records_found(int type)
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersons()).Returns(Task.FromResult(Dummies.GetPeronList(type)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersons(), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public async Task SaveUser_Should_Return_OkObjectResult_when_save_successfull(int type)
        {
            //Setup
            _savePersonComponent.Setup(x => x.SavePerson(It.IsAny<Person>())).Returns(Task.FromResult(Dummies.GetDummiePerson(type)));
            _getPersonComponent.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(type)));
            //Act
            var result = await personController.SavePerson(Dummies.GetDummiePersonModel(type));
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _savePersonComponent.Verify(x => x.SavePerson(It.IsAny<Person>()), Times.Once);
            _getPersonComponent.Verify(x => x.GetPersonById(It.IsAny<Guid>()), Times.Once);
        }

    }

}

