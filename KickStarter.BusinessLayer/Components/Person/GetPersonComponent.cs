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

        private readonly IPersonsRepository _personsRepository;

        public GetPersonsComponent(IUnitOfWork unitOfWork,
           IPersonsRepository repository)
           : base(unitOfWork)
        {
            _personsRepository = repository;
        }

        public async Task<List<Library.Entities.Person>> GetAllPersonsAsync()
        {
            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithoutTracking(); // readonly query

            var persons = (await _personsRepository.QueryAsync(queryCriteria)).Items.ToList();

            return persons;
        }

        public async Task<Library.Entities.Person> GetPersonByIdAsync(Guid id)
        {
            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithFilter(a => a.Id == id)
                .WithoutTracking();

            return (await _personsRepository.QueryAsync(queryCriteria)).Items.FirstOrDefault();
        }
    }


}
