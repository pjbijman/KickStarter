using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface IGetPersonsComponent
    {
        Task<Library.Entities.Person> GetPersonByIdAsync(Guid id);

        Task<List<Library.Entities.Person>> GetAllPersonsAsync();
    }

}
