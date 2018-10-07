using System;
using System.Threading.Tasks;

namespace KickStarter.DataLayer.DI
{
    public interface IUnitOfWork : IDisposable
    {
        Guid InstanceGuid { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
