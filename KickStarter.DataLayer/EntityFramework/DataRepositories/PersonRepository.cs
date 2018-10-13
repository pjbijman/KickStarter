using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KickStarter.DataLayer.EntityFramework.DataRepositories
{
    public class PersonRepository : DataRepository<Person>, IPersonsRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Task GetByIdAsync(Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}
