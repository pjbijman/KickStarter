using System;
using System.Threading.Tasks;
using KickStarter.Framework.Query;
using KickStarter.Library.Entities;

namespace KickStarter.DataLayer.DI
{
    public interface IDataRepository<T> where T : BaseEntity
    {
        Guid InstanceGuid { get; }
        T Add(T entity);
        T AddOrUpdate(T entity);
        T Attach(T entity);
        T Update(T entity);
        T Remove(T entity);
        void RemoveRange(T[] entities);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id, QueryCriteria<T> queryCriteria);
        Task<QueryResult<T>> QueryAsync(QueryCriteria<T> queryCriteria);
        Task<int> CountAsync(QueryCriteria<T> queryCriteria);
    }
}