using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface IGetPersonComponent
    {
        Task<Library.Entities.Person> Execute(int id);
    }

}
