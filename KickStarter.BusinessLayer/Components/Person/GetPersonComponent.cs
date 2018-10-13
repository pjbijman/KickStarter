using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Framework.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Person
{
    public class GetPersonsComponent : BusinessComponent, IGetPersonsComponent
    {

        private readonly IPersonsRepository _personDataRepository;

        public GetPersonsComponent(IUnitOfWork unitOfWork,
           IPersonsRepository repository)
           : base(unitOfWork)
        {
            _personDataRepository = repository;
        }

        public async Task<List<Library.Entities.Person>> GetAllPersons()
        {
            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithoutTracking(); // readonly query

            var persons = (await _personDataRepository.QueryAsync(queryCriteria)).Items.ToList();

            return persons;
        }

        public async Task<Library.Entities.Person> GetPersonById(Guid id)
        {
            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithFilter(a => a.Id == id)
                .WithoutTracking();

            return (await _personDataRepository.QueryAsync(queryCriteria)).Items.FirstOrDefault();
        }
    }


}
