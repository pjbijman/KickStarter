using KickStarter.Library.Entities;
using KickStartrer.Service.ClientModels;
using KickStartrer.Service.Conversions;
using Xunit;

namespace KickStarter.ServiceLayer.Tests.Conversions
{
    public class PersonModelToPersonTypeConverter_Tests : XunitTestBase
    {
        [Fact]
        public void Does_Convert_Returns_a_Person_from_PersonModel()
        {

            var source = Helpers.Dummies.GetDummiePersonModel(Helpers.Dummies.DummieInstance.ValidInstance);
            var destination = Helpers.Dummies.GetDummiePerson(Helpers.Dummies.DummieInstance.ValidInstance);


            var conv = new PersonModelToPersonTypeConverter();
            var result = conv.Convert(source, destination, resolutionContext);

            Assert.IsType<Person>(result);

            Assert.True(result.FirstName == destination.FirstName);
            Assert.True(result.MiddleName == destination.MiddleName);
            Assert.True(result.Insertion == destination.Insertion);
            Assert.True(result.LastName == destination.LastName);
            Assert.True(result.Suffix == destination.Suffix);
            //Assert.True(result.FirstName.Equals(destination.FirstName));
            Assert.True(result.Gender.Equals(destination.Gender));
            Assert.True(result.DateOfBirth.Equals(destination.DateOfBirth));
            Assert.True(result.SocialSegurityNumber == destination.SocialSegurityNumber);
            Assert.True(result.Description == destination.Description);

            Assert.True(result.Image.Length.Equals(destination.Image.Length));
        }

        [Fact]
        public void Does_Convert_Returns_a_PersonModel_from_Person()
        {

            var source = Helpers.Dummies.GetDummiePerson(Helpers.Dummies.DummieInstance.ValidInstance);
            var destination = Helpers.Dummies.GetDummiePersonModel(Helpers.Dummies.DummieInstance.ValidInstance);

            var conv = new PersonModelToPersonTypeConverter();
            var result = conv.Convert(source, destination, resolutionContext);

            Assert.IsType<PersonModel>(result);

            Assert.True(result.FirstName == destination.FirstName);
            Assert.True(result.MiddleName == destination.MiddleName);
            Assert.True(result.Insertion == destination.Insertion);
            Assert.True(result.LastName == destination.LastName);
            Assert.True(result.Suffix == destination.Suffix);
            //Assert.True(result.FirstName.Equals(destination.FirstName));
            Assert.True(result.Gender.Equals(destination.Gender));
            Assert.True(result.DateOfBirth.Equals(destination.DateOfBirth));
            Assert.True(result.SocialSegurityNumber == destination.SocialSegurityNumber);
            Assert.True(result.Description == destination.Description);

            Assert.True(result.Image.Length.Equals(destination.Image.Length));
        }
    }
}
