using System;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{

    public interface IDeletePersonComponent
    {
        Task<int> DeletePerson(Guid personId);
    }

}
