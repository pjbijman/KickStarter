using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using static KickStarter.ServiceLayer.Tests.Helpers.Dummies;

namespace KickStarter.ServiceLayer.Tests.Controller.api
{

    public class PersonController_Tests : XunitTestBase
    {
        //Initialize AutoMapper and object setup is done in the base constructor

        [Fact]
        public async Task GetPersonByIdAsync_Should_return_OkObjectResult_with_valid_id()
        {
            // Setup
            Guid personId = Guid.NewGuid();
            _getPersonComponent.Setup(x => x.GetPersonByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(DummieInstance.ValidInstance)));

            //Act
            var result = await personController.GetPersonByIdAsync(personId);
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetPersonByIdAsync(personId), Times.Once);
        }

        [Fact]
        public async Task GetPersonByIdAsync_Should_return_StatusCodeResult_204_when_no_person_found()
        {
            // Setup
            Guid personId = Guid.NewGuid();
            _getPersonComponent.Setup(x => x.GetPersonByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(Dummies.DummieInstance.NullObject)));

            // Act
            var result = await personController.GetPersonByIdAsync(personId);
            var expectedType = new StatusCodeResult(204).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetPersonByIdAsync(personId), Times.Once);
        }

        [Fact]
        public async Task GetPersonsAsync_Should_return_StatusCodeResult_204_when_no_records_found()
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersonsAsync()).Returns(Task.FromResult(Dummies.GetPeronList(DummieInstance.NullObject)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new StatusCodeResult(204).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersonsAsync(), Times.Once);
        }

        [Fact]
        public async Task GetPersonsAsync_Should_return_NoContentResult_when_no_records_found()
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersonsAsync()).Returns(Task.FromResult(Dummies.GetPeronList(DummieInstance.NewInstance)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new NoContentResult().GetType();
            var actualType = result.GetType();

            // Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersonsAsync(), Times.Once);
        }

        [Fact]
        public async Task GetPersonsAsync_Should_return_OkObjectResult_when_records_found()
        {
            //Setup
            _getPersonComponent.Setup(x => x.GetAllPersonsAsync()).Returns(Task.FromResult(Dummies.GetPeronList(DummieInstance.ValidInstance)));

            //Act
            var result = await personController.GetPersonsAsync();
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _getPersonComponent.Verify(x => x.GetAllPersonsAsync(), Times.Once);
        }

        [Fact]
        public async Task SavePersonAsync_Should_Return_OkObjectResult_when_save_successfull()
        {
            //Setup
            _savePersonComponent.Setup(x => x.SavePersonAsync(It.IsAny<Person>())).Returns(Task.FromResult(Dummies.GetDummiePerson(DummieInstance.NewInstance)));
            _getPersonComponent.Setup(x => x.GetPersonByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(DummieInstance.NewInstance)));
            //Act
            var result = await personController.SavePersonAsync(Dummies.GetDummiePersonModel(DummieInstance.NewInstance));
            var expectedType = new OkObjectResult(result).GetType();
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
            //Check if the execute was called at least once on the controller method
            _savePersonComponent.Verify(x => x.SavePersonAsync(It.IsAny<Person>()), Times.Once);
            _getPersonComponent.Verify(x => x.GetPersonByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

    }

}

