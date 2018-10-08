using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{

    public interface IGetPersonByIdComponent
    {
        Task<Library.Entities.Person> Execute(int id);
    }

}
