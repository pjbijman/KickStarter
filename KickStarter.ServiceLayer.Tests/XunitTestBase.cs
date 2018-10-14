using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Controllers.api;
using KickStarter.ServiceLayer.Tests.Resolvers;
using Moq;
using System;

namespace KickStarter.ServiceLayer.Tests
{

    public class XunitTestBase : IDisposable
    {
        // Person
        //protected readonly Mock<IReadOnlyRepository<Person>> _personRepository = new Mock<IReadOnlyRepository<Person>>();
        //protected readonly Lazy<IGetPersonComponent> _getPersonComponent = new Lazy<IGetPersonComponent>();

        protected readonly Mock<IReadOnlyRepository<Person>> _persosnRepository = new Mock<IReadOnlyRepository<Person>>();
        protected readonly Mock<IGetPersonsComponent> _getPersonComponent = new Mock<IGetPersonsComponent>();
        protected readonly Mock<ISavePersonComponent> _savePersonComponent=new Mock<ISavePersonComponent>();
        protected readonly Mock<IDeletePersonComponent> _deletePersonComponent = new Mock<IDeletePersonComponent>();

        // Controllers
        public PersonController personController;

        public XunitTestBase()
        {
            //Resolve the Mapper
            var mp = MapperResolver.Instance;

            //Init the Controller(s)
            personController = new PersonController(
               // new Lazy<IReadOnlyRepository<Person>>(_persosnRepository.Object),
                new Lazy<IGetPersonsComponent>(_getPersonComponent.Object),
                new Lazy<ISavePersonComponent>(_savePersonComponent.Object),
                new Lazy<IDeletePersonComponent>(_deletePersonComponent.Object)
                );
        }

        public void Dispose()
        {
            //Dispose repositories
            _persosnRepository.Object.Dispose();

            // Dispose controllers
            personController.Dispose();
        }
    }
}
