using AutoMapper;
using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Tests.Resolvers;
using KickStartrer.Service.Controllers.api;
using Moq;
using System;

namespace KickStarter.ServiceLayer.Tests
{

    public class XunitTestBase : IDisposable
    {
        // Person
        protected readonly Mock<IReadOnlyRepository<Person>> _persosnRepository = new Mock<IReadOnlyRepository<Person>>();
        protected readonly Mock<IGetPersonsComponent> _getPersonComponent = new Mock<IGetPersonsComponent>();
        protected readonly Mock<ISavePersonComponent> _savePersonComponent = new Mock<ISavePersonComponent>();
        protected readonly Mock<IDeletePersonComponent> _deletePersonComponent = new Mock<IDeletePersonComponent>();

        protected readonly Mock<IMappingOperationOptions> _IMappingOperationOptions = new Mock<IMappingOperationOptions>();
        protected readonly Mock<IRuntimeMapper> _IRuntimeMapper = new Mock<IRuntimeMapper>();


        // Controllers
        public PersonController personController;
        public ResolutionContext resolutionContext;

        public XunitTestBase()
        {
            //Resolve the Mapper
            var mp = MapperResolver.Instance;

            resolutionContext = new ResolutionContext(
                 _IMappingOperationOptions.Object,
                 _IRuntimeMapper.Object
                 );

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
