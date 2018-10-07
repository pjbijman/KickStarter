using System;
using System.Threading.Tasks;
using KickStarter.Framework.Query;

namespace KickStarter.DataLayer.DI
{
    public interface IDataRepository<T> where T : class
    {
        Guid InstanceGuid { get; }
        T Add(T entity);
        T AddOrUpdate(T entity);
        T Attach(T entity);
        T Update(T entity);
        T Remove(T entity);
        void RemoveRange(T[] entities);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, QueryCriteria<T> queryCriteria);
        Task<QueryResult<T>> QueryAsync(QueryCriteria<T> queryCriteria);
        Task<int> CountAsync(QueryCriteria<T> queryCriteria);
    }
}