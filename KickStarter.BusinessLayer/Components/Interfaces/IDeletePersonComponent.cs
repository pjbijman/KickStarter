using System;
using System.Threading.Tasks;

namespace KickStarter.BusinessLayer.Components.Interfaces
{

    public interface IDeletePersonComponent
    {
        Task<int> DeletePersonAsync(Guid personId);
    }

}
