using KickStarter.BusinessLayer.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using KickStarter.BusinessLayer.Components.Person;
using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using KickStarter.DataLayer.EntityFramework;

namespace KickStarter.BusinesLayer.Tests
{
    public class ComponentBase : IDisposable
    {
        protected readonly Mock<IGetPersonsComponent> _getPersonComponent = new Mock<IGetPersonsComponent>();
        protected readonly Mock<ISavePersonComponent> _savePersonComponent = new Mock<ISavePersonComponent>();
        protected readonly Mock<IDeletePersonComponent> _deletePersonComponent = new Mock<IDeletePersonComponent>();

        protected readonly Mock<IPersonsRepository> _personDataRepository = new Mock<IPersonsRepository>();
        protected readonly Mock<IUnitOfWork> _IUnitOfWork = new Mock<IUnitOfWork>();
        protected readonly Mock<IDataContext> _IDataContext = new Mock<IDataContext>();

        public ComponentBase()
        {
            new Lazy<IGetPersonsComponent>(_getPersonComponent.Object);
            new Lazy<ISavePersonComponent>(_savePersonComponent.Object);
            new Lazy<IDeletePersonComponent>(_deletePersonComponent.Object);
            new Lazy<IUnitOfWork>(_IUnitOfWork.Object);
        }

        public bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }

        public void Dispose()
        {

        }
    }
}
