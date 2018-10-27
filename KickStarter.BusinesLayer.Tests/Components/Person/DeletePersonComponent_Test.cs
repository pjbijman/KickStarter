using KickStarter.ServiceLayer.Tests.Helpers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using static KickStarter.ServiceLayer.Tests.Helpers.Dummies;

namespace KickStarter.BusinesLayer.Tests.Components.Person
{
    public class DeletePersonComponent_Test : ComponentBase
    {

        [Fact]
        public async void DeletePersonAsync_with_valid_id_should_return_int()
        {
            // Todo: Find out how to thest this.
            // Setup
            Guid personId = Guid.NewGuid();
            int outputResult = 0;

            _deletePersonComponent.Setup(x => x.DeletePersonAsync(It.IsAny<Guid>())).Returns(Task.FromResult(outputResult));

            // Act
            var result = await _deletePersonComponent.Object.DeletePersonAsync(personId);

            var expected = typeof(System.Int32); // TODO: Should be a Task return
            var actual = result.GetType();

            //Assert
            Assert.True(expected.Equals(actual));
        }
    }
}
