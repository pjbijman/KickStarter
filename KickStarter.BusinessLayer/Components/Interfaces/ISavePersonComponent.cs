using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface ISavePersonComponent
    {
        Task<Library.Entities.Person> SavePersonAsync(Library.Entities.Person person);
    }

}
