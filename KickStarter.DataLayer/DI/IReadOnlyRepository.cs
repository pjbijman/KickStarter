using System;
using System.Threading.Tasks;
using KickStarter.Library.Interfaces;
using KickStarter.Framework.Query;

namespace KickStarter.DataLayer.DI
{
    public interface IReadOnlyRepository<T> : IDisposable where T : class, IIdentifiable
    {
        Task<QueryResult<T>> FindAllAsync();

        Task<T> FindByIdAsync(int id);
    }
}