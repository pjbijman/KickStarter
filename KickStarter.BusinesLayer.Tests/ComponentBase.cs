using KickStarter.BusinessLayer.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace KickStarter.BusinesLayer.Tests
{
    public class ComponentBase : IDisposable
    {
        protected readonly Mock<IGetPersonsComponent> _getPersonComponent = new Mock<IGetPersonsComponent>();
        protected readonly Mock<ISavePersonComponent> _savePersonComponent = new Mock<ISavePersonComponent>();
        protected readonly Mock<IDeletePersonComponent> _deletePersonComponent = new Mock<IDeletePersonComponent>();

        public ComponentBase()
        {
            new Lazy<IGetPersonsComponent>(_getPersonComponent.Object);
            new Lazy<ISavePersonComponent>(_savePersonComponent.Object);
            new Lazy<IDeletePersonComponent>(_deletePersonComponent.Object);
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
