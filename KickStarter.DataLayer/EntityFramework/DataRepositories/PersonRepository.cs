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

        /// <summary>
        /// Fetches a Person by its Id async.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Person> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches a person by its Id and criteria async.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="queryCriteria"></param>
        /// <returns></returns>
        public Task<Person> GetByIdAsync(Guid id, QueryCriteria<Person> queryCriteria)
        {
            throw new NotImplementedException();
        }

       
    }
}
