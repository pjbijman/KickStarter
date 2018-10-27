using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DataRepositoryInterfaces;
using KickStarter.DataLayer.DI;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Person
{
    public class SavePersonComponent : BusinessComponent, ISavePersonComponent
    {
        private readonly IPersonsRepository _personRepository;

        public SavePersonComponent(
           IUnitOfWork unitOfWork,
            IPersonsRepository repository)
            : base(unitOfWork)
        {
            _personRepository = repository;
        }

        public async Task<Library.Entities.Person> SavePersonAsync(Library.Entities.Person person)
        {
            // Todo: Add errorhandling
            var updatedPerson = _personRepository.AddOrUpdate(person);

            await UnitOfWork.SaveChangesAsync();

            return updatedPerson;
        }
    }

}
