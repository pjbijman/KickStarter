using KickStarter.BusinessLogic.Services;
using KickStarter.Library.Entities;
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xunit;
namespace KickStarter.BusinessLogic.Tests
{
    public class PersonService_Tests
    {
        [Fact]
        public void Can_PersonService_GetById_Return_a_Person()
        {
            using (var personService = new PersonService())
            {
                Guid personId = Guid.NewGuid();

                var result = personService.GetById(personId);

                var expected = typeof(Person);
                var actual = result.GetType();

                //Check if the correct type was returned.
                Assert.Equal(expected, actual);
            }
        }
    }
}
