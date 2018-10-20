using Kickstarter.DataLayer.EntityFramework.Helpers;
using KickStarter.DataLayer.DI;
using KickStarter.Framework.Query;
using KickStarter.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KickStarter.DataLayer.EntityFramework.DataRepositories
{
    public class DataRepository<T> : IDataRepository<T> where T : BaseEntity
    {
        public DataRepository(DataContext dataContext)
        {
            InstanceGuid = Guid.NewGuid();
            DataContext = dataContext;
            DataSet = DataContext.Set<T>();
        }

        protected DataContext DataContext { get; set; }
        protected DbSet<T> DataSet { get; set; }
        public Guid InstanceGuid { get; protected set; }

        public T Add(T entity)
        {
            return DataSet.Add(entity).Entity;

        }

        public T AddOrUpdate(T entity)
        {
            // Check if exists
            T chk = DataSet.Where(e => e.Id == entity.Id).FirstOrDefault();

            if (chk != null) return Update(entity);

            return Add(entity);
        }

        public T Attach(T entity)
        {
            var updatedEntity = DataSet.Attach(entity).Entity;

            return updatedEntity;
        }

        public async Task<int> CountAsync(QueryCriteria<T> queryCriteria)
        {
            var queryResult = new QueryResult<T>();
            var dataSet = queryCriteria.AsNoTracking ? DataSet.AsNoTracking() : DataSet;
            var resultCount = await dataSet.ApplyQueryCriteria(queryCriteria, queryResult).CountAsync();

            return resultCount;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await GetByIdAsync(id, new QueryCriteria<T>());
        }

        public async Task<T> GetByIdAsync(Guid id, QueryCriteria<T> queryCriteria)
        {
            var dataSet = queryCriteria.AsNoTracking ? DataSet.AsNoTracking() : DataSet;
            var entity = await dataSet.Where(e => e.Id == id).ApplyQueryCriteria(queryCriteria).SingleOrDefaultAsync();

            return entity;
        }

        public async Task<QueryResult<T>> QueryAsync(QueryCriteria<T> queryCriteria)
        {
            var queryResult = new QueryResult<T>();
            var dataSet = queryCriteria.AsNoTracking ? DataSet.AsNoTracking() : DataSet;
            LoadRelatedEntities(queryCriteria);
            queryResult.Items = await dataSet.ApplyQueryCriteria(queryCriteria, queryResult).ToListAsync();

            return queryResult;
        }

        public T Remove(T entity)
        {
            var updatedEntity = DataSet.Remove(entity);

            return updatedEntity.Entity;
        }

        public void RemoveRange(T[] entities)
        {
            DataSet.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            var updatedEntity = DataSet.Update(entity);
            DataContext.SaveChanges();//TODO: for testing check if neccesary
            return updatedEntity.Entity;
        }

        public virtual void LoadRelatedEntities(QueryCriteria<T> queryCriteria)
        {
        }
    }
}