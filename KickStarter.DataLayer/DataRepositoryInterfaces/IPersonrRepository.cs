using System;
using System.Threading.Tasks;
using KickStarter.Library.Entities;

namespace KickStarter.DataLayer.DataRepositoryInterfaces
{
    public interface IPersonsRepository : IDataRepository<Person>
    {
        //Task GetByIdAsync(Guid id);
    }
}
