using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface ISavePersonComponent
    {
        Task<Library.Entities.Person> SavePerson(Library.Entities.Person person);
    }

}
