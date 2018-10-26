using KickStarter.ServiceLayer.Tests.Helpers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace KickStarter.BusinesLayer.Tests.Components.Person
{
    public class PersonComponent_Test : ComponentBase
    {
        [Theory]
        [InlineData(1)]
        public void GetPersonById_should_return_a_Persons(int id)
        {
            //Todo: Finish tests.
            var result = _getPersonComponent.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            var expectedType = typeof(Task<Library.Entities.Person>);
            var actualType = result.GetType();

            Assert.True(expectedType.Equals(actualType));
        }

    }
}
