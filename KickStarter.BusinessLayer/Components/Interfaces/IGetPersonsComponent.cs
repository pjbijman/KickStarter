using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface IGetPersonsComponent
    {
        Task<Library.Entities.Person> GetPersonById(Guid id);
        Task<List<Library.Entities.Person>> GetAllPersons();
    }

}
