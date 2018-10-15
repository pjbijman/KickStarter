using Xunit;

namespace KickStarter.ServiceLayer.Tests.Controller.api
{
    public class PersonController_Functional_Tests : XunitTestBase_Functional
    {
 
        [Theory]
        [InlineData(1)]
        public  void Does_SavePerson_Inserts_a_Person(int type)
        {
            //Todo: finish test
            //serviceResolver.
            //using (var scope = af.Container.BeginLifetimeScope())
            //{
            //    var unitOfWork = scope.Resolve<IUnitOfWork>();
            //    var personController = scope.Resolve<IPersonController>();
            //    await personController.SavePerson(Dummies.GetDummiePersonModel(type));
            //}
            Assert.True(true);
        }
    }
}
