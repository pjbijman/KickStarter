using KickStarter.ServiceLayer.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static KickStarter.ServiceLayer.Tests.Helpers.Dummies;

namespace KickStarter.BusinesLayer.Tests.Components.Person
{
    public class PersonComponent_Test : ComponentBase
    {
        [Fact]
        public async void GetPersonByIdAsync_with_valid_id_should_return_a_Person()
        {
            // Setup
            Guid personId = Guid.NewGuid();

            _getPersonComponent.Setup(x => x.GetPersonByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(DummieInstance.ValidInstance)));

            // Act
            var result = await _getPersonComponent.Object.GetPersonByIdAsync(personId);

            var expectedType = typeof(Library.Entities.Person); // TODO: Should be a Task return
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
        }

        [Fact]
        public async void GetAllPersonsAsync_should_return_a_List_of_Persons()
        {
            // Setup
            Guid personId = Guid.NewGuid();

            _getPersonComponent.Setup(x => x.GetAllPersonsAsync()).Returns(Task.FromResult(Dummies.GetPeronList(DummieInstance.ValidInstance)));

            // Act
            var result = await _getPersonComponent.Object.GetAllPersonsAsync();

            var expectedType = typeof(List<Library.Entities.Person>); // TODO: Should be a Task return
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
        }

    }
}
