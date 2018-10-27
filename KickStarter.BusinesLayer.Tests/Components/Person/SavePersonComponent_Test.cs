using KickStarter.ServiceLayer.Tests.Helpers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using static KickStarter.ServiceLayer.Tests.Helpers.Dummies;

namespace KickStarter.BusinesLayer.Tests.Components.Person
{
    public class SavePersonComponent_Test : ComponentBase
    {

        [Fact]
        public async void SavePersonAsync_with_valid_id_should_return_a_Person()
        {
            // Setup
            Guid personId = Guid.NewGuid();

            _savePersonComponent.Setup(x => x.SavePersonAsync(It.IsAny<Library.Entities.Person>())).Returns(Task.FromResult(Dummies.GetDummiePerson(DummieInstance.ValidInstance)));

            // Act
            var result = await _savePersonComponent.Object.SavePersonAsync(Dummies.GetDummiePerson(DummieInstance.ValidInstance));

            var expectedType = typeof(Library.Entities.Person); // TODO: Should be a Task return
            var actualType = result.GetType();

            //Assert
            Assert.True(expectedType.Equals(actualType));
        }
    }
}
