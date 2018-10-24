using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.Framework.Query;
using KickStarter.Library.Entities;
using System;
using System.Threading.Tasks;

namespace KickStarter.DataLayer.EntityFramework.DataRepositories
{
    /// <summary>
    /// Person data repository
    /// </summary>
    public class PersonRepository : DataRepository<Person>, IPersonsRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
