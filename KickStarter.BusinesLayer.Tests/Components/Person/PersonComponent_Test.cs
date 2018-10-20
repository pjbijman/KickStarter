using KickStarter.ServiceLayer.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using KickStarter.Library.Entities;
using KickStarter.BusinessLayer.Components.Interfaces;

namespace KickStarter.BusinesLayer.Tests.Components.Person
{
    public class PersonComponent_Test : ComponentBase
    {
        [Theory]
        [InlineData(1)]
        public void GetPersonById_should_return_a_Persons(int id)
        {
            //var result = _getPersonComponent.Setup(x => x.GetPersonById(It.IsAny<Guid>())).Returns(Task.FromResult(Dummies.GetDummiePerson(id)));

            //var expectedType = new Library.Entities.Person().GetType();
            //var actualType = result.GetType();
            //Assert.True(expectedType.Equals(actualType));
        }

    }
}
