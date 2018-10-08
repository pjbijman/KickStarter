using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Framework.Query;
using System.Linq;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Person
{
    internal class GetPersonByIdComponent : BusinessComponent, IGetPersonByIdComponent
    {

        private readonly IPersonrRepository _personDataRepository;

        public GetPersonByIdComponent(IUnitOfWork unitOfWork,
           IPersonrRepository repository)
           : base(unitOfWork)
        {
            _personDataRepository = repository;
        }

        public async Task<Library.Entities.Person> Execute(int id)
        {
            var queryCriteria = new QueryCriteria<Library.Entities.Person>()
                .WithoutTracking();

            return (await _personDataRepository.QueryAsync(queryCriteria)).Items.FirstOrDefault();
        }
    }
}
