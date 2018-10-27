using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Framework.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Person
{
    public class DeletePersonComponent : BusinessComponent, IDeletePersonComponent
    {
        private readonly IPersonsRepository _personDataRepository;

        public DeletePersonComponent(IUnitOfWork unitOfWork,
            IPersonsRepository repository)
            : base(unitOfWork)
        {
            _personDataRepository = repository;
        }

        public async Task<int> DeletePersonAsync(Guid personId)
        {

            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithFilter(a => a.Id == personId)
                .WithoutTracking();

            var person = (await _personDataRepository.QueryAsync(queryCriteria)).Items.FirstOrDefault();
            if (person == null)
            {
                return 0;
            }

            _personDataRepository.Remove(person);

            var output = await UnitOfWork.SaveChangesAsync();
            return output;
        }


    }
}
